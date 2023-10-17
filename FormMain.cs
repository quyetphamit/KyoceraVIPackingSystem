using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KyoceraVIPackingSystem.Business;
using KyoceraVIPackingSystem.SystemInfo;

namespace KyoceraVIPackingSystem
{
    public enum MessageMode
    {
        LOCK, ERR, NONE
    }

    public partial class FormMain : Form
    {
        Dictionary<string, string> _cookies = new Dictionary<string, string>();
        public FormMain()
        {
            InitializeComponent();
            Display();
        }

        private void SaveData(object sender, RunWorkerCompletedEventArgs e)
        {
            var boardNo = txtBarcode.Text;
            this.Enabled = true;
            txtBarcode.ResetText();
            txtMac.ResetText();
            txtMac.Enabled = false;
            txtBarcode.Enabled = true;
            txtBarcode.Focus();
            var entity = e.Result as MsgEnity;
            if (entity.Type == MessageMode.LOCK)
            {
                DisplayMessage("NG", entity.msg);
                new frmLockSystem(entity.msg).ShowDialog();
            }
            else if (entity.Type == MessageMode.ERR)
            {
                DisplayMessage("NG", entity.msg);
            }
            else
            {
                DateTime dateServer = SingletonHelper.PVSInstance.GetDateTime();
                var kyoEntity = new ERPService.KYOCERAEntity()
                {
                    ProductionID = boardNo,
                    LineID = 1,
                    Soft_Ver = AppInfo.GetRunningVersion(),
                    BoxID = UsapHelper.BoxID,
                    ModelID = UsapHelper.Model,
                    OrderNo = UsapHelper.OrderNo,
                    ModelName = UsapHelper.Model,
                    DateCheck = dateServer,
                    TimeCheck = dateServer.ToString("HH:mm:ss tt"),
                    OperatorCode = UserInfo.UserName,
                    OperatorName = UserInfo.FullName,
                    JudgeResult = chkOK.Checked == true ? "OK" : "NG",
                    Shipping = false,
                    DownloadStatus = string.IsNullOrEmpty(txtMac.Text) ? "NG" : "OK"
                };
                Ultils.CreateFileLog(UsapHelper.Model, boardNo, "P", "VI2_KYD", SingletonHelper.PVSInstance.GetDateTime());
                var linkErr = UmesHelper.GetLinkErr(boardNo);
                if (!string.IsNullOrEmpty(linkErr))
                {
                    DisplayMessage("NG", linkErr);
                    return;
                }
                SingletonHelper.ERPInstance.KyoSaveBoard("", kyoEntity);
                ViewQty();
                var boxInfo = SingletonHelper.ERPInstance.KyoGetMac(UsapHelper.BoxID);
                dataGridView1.DataSource = boxInfo.OrderByDescending(r => r.DateCheck).ThenByDescending(r => r.TimeCheck).ToList();
                DatagridViewPerformance();
                lblQuantity.Text = $"{boxInfo.Count()}/{Convert.ToInt32(UsapHelper.BoxQty)}";
                if (boxInfo.Count() >= Convert.ToInt32(UsapHelper.BoxQty))
                {
                    DisplayMessage("WARNING", $"Thùng [{UsapHelper.BoxID}] đã đầy. Vui lòng lấy thùng khác!");
                    btnReset.PerformClick();
                }
                else
                {
                    DisplayMessage("OK", "Success!");
                    txtBarcode.Focus();
                }
            }
        }

        private void CheckData(object sender, DoWorkEventArgs e)
        {
            var boardNo = e.Argument.ToString();
            UmesHelper.FindUmes(boardNo);
            UmesHelper.RemoveRepair();
            foreach (var msg in Validator.GetMsgErr(boardNo, txtMac.Text))
            {

                e.Result = msg;
                return;
            }
            e.Result = new MsgEnity() { msg = "", Type = MessageMode.NONE };
        }

        void Display()
        {
            lblRunVersion.Text = AppInfo.GetRunningVersion();
            dataGridView1.AutoGenerateColumns = false;
            cbbSearchOption.BeginUpdate();
            cbbSearchOption.Items.Add("BoxID");
            cbbSearchOption.Items.Add("BoardNo");
            cbbSearchOption.EndUpdate();
            cbbSearchOption.SelectedIndex = 0;
        }

        public void ResetApplication()
        {
            lblRule.Text = "N/A";
            lblCurrentItem.Text = "N/A";
            lblQuantity.Text = "0/0";
            dataGridView1.DataSource = null;
        }

        void DisplayMessage(string status, string message)
        {
            Color backColor = new Color();
            Color foreColor = new Color();
            switch (status)
            {
                case "OK":
                    backColor = Color.DarkGreen;
                    foreColor = Color.White;
                    break;
                case "NG":
                    backColor = Color.DarkRed;
                    foreColor = Color.White;
                    break;
                case "WARNING":
                    backColor = Color.DarkOrange;
                    foreColor = Color.White;
                    break;
                default:
                    backColor = Color.White;
                    foreColor = Color.FromArgb(192, 64, 0);
                    break;
            }
            this.BeginInvoke(new Action(() => { lblStatus.Text = status; }));
            this.BeginInvoke(new Action(() => { lblStatus.BackColor = backColor; }));
            this.BeginInvoke(new Action(() => { lblStatus.ForeColor = foreColor; }));

            this.BeginInvoke(new Action(() => { lblMessge.Text = message; }));
            this.BeginInvoke(new Action(() => { lblMessge.BackColor = backColor; }));
            this.BeginInvoke(new Action(() => { lblMessge.ForeColor = foreColor; }));
        }
        void ViewQty()
        {
            //var finishQty = SingletonHelper.ERPInstance.KyoGetQty(UsapHelper.BCLBFLM.TN_NO.Right(10));
            lblWoQty.Text = string.Format("{0}/{1}", SingletonHelper.ERPInstance.KyoGetQty(UsapHelper.OrderNo), UsapHelper.WoQty);
        }
        void ViewBoxItems()
        {
            lblWoQty.Text = string.Format("{0}/{1}", PackingHelper.WoQty, UsapHelper.WoQty);
            lblFCT.Text = UsapHelper.CheckMac ? "Check FCT" : "Not check FCT";
            lblModel.Text = UsapHelper.Model;
            lblQuantity.Text = $"{PackingHelper.BoxQty}/{UsapHelper.BoxQty}";
            lblWo.Text = UsapHelper.OrderNo;
            dataGridView1.DataSource = PackingHelper.BoxItems != null ? PackingHelper.BoxItems : null;
            DatagridViewPerformance();
        }
        private void chkOK_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkOK.Checked && !chkNG.Checked)
            {
                txtBarcode.ResetText();
                txtBarcode.Enabled = false;
            }
            if (chkOK.Checked == true)
            {
                txtBarcode.Enabled = true;
                chkNG.Checked = false;
                txtBoxID.Enabled = false;
                txtBarcode.ResetText();
                txtBarcode.Focus();
            }
        }

        private void chkNG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNG.Checked == true)
            {
                txtBarcode.Enabled = true;
                chkOK.Checked = false;
                txtBoxID.Enabled = false;
                txtBarcode.ResetText();
                txtBarcode.Focus();
            }
            if (!chkOK.Checked && !chkNG.Checked)
            {
                txtBarcode.ResetText();
                txtBarcode.Enabled = false;
            }
        }

        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string boxId = txtBoxID.Text.Trim();
                if (string.IsNullOrEmpty(boxId))
                {
                    return;
                }
                lblFCT.ResetText();
                UsapHelper.FindBoxID(boxId);
                if (!UsapHelper.Exist)
                {
                    DisplayMessage("NG", $"[{boxId}] không tồn tại trên hệ thống.\nVui lòng nhập lại!");
                    ResetApplication();
                    txtBoxID.ResetText();
                    txtBoxID.Focus();
                    return;
                }
                PackingHelper.GetBoxItems(boxId);
                ViewBoxItems();
                if (PackingHelper.IsFinish)
                {
                    DisplayMessage("OK", $"[{boxId}] đã bắn đầy.\nVui lòng bắn BoxID khác!");
                    txtBoxID.ResetText();
                    txtBoxID.Focus();
                }
                else
                {
                    DisplayMessage("OK", $"[{boxId}] OK!");
                    txtBoxID.SelectAll();
                    chkOK.Enabled = chkNG.Enabled = true;
                    chkOK.Checked = true;
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có thực sự muốn đóng hay không!",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string boardNo = txtBarcode.Text;
                if (string.IsNullOrEmpty(boardNo))
                {
                    return;
                }
                if (!chkOK.Checked && !chkNG.Checked)
                {
                    DisplayMessage("NG", "Chưa chọn trạng thái của mạch.\nVui lòng nhập lại!");
                    return;
                }
                if (chkNG.Checked)
                {
                    Ultils.CreateFileLog(UsapHelper.Model, boardNo, "F", "VI2_KYD", SingletonHelper.PVSInstance.GetDateTime());
                    DisplayMessage("NG", $"{boardNo} NG");
                    txtBarcode.ResetText();
                    txtBarcode.Focus();
                }
                else
                {
                    txtBarcode.Enabled = false;
                    if (UsapHelper.CheckMac)
                    {
                        txtMac.ResetText();
                        txtMac.Enabled = true;
                        txtMac.Focus();
                    }
                    else
                    {
                        this.Enabled = false;
                        txtMac.Enabled = false;
                        var worker = new BackgroundWorker();
                        worker.DoWork += new DoWorkEventHandler(CheckData);
                        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SaveData);
                        worker.RunWorkerAsync(argument: boardNo);
                    }
                }
            }
        }

        private void DoWork()
        {
            var boardNo = txtBarcode.Text.Trim();
            UmesHelper.FindUmes(boardNo);
            UmesHelper.RemoveRepair();
            foreach (var msg in Validator.GetMsgErr(boardNo, txtMac.Text))
            {
                DisplayMessage("FAIL", msg.msg);
                //e.Result = msg;
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxID.Enabled = true;
            txtBoxID.ResetText();
            lblWo.ResetText();
            txtBarcode.ResetText();
            txtBarcode.Enabled = false;
            txtMac.ResetText();
            txtMac.Enabled = false;
            lblModel.ResetText();
            lblQuantity.Text = "0/0";
            lblRule.Text = "N/A";
            lblCurrentItem.Text = "N/A";
            chkOK.Checked = false;
            chkNG.Checked = false;
            chkOK.Enabled = chkNG.Enabled = false;
            dataGridView1.DataSource = null;
            DisplayMessage("N/A", "no results");
            lblWoQty.ResetText();
            txtBoxID.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = cbbSearchOption.Text;
            string key = txtSearchKey.Text;
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }
            var data = new List<ERPService.KYOCERAEntity>();
            switch (value)
            {
                case "BoxID":
                    var boxIDs = SingletonHelper.ERPInstance.KyoGetMac(key);
                    data = boxIDs != null ? boxIDs.ToList() : null;
                    _cookies.Remove(value);
                    _cookies.Add("BoxID", key);
                    break;
                case "BoardNo":
                    var boardNos = SingletonHelper.ERPInstance.KyoGetBoard(key);
                    data = boardNos != null ? new List<ERPService.KYOCERAEntity>() { boardNos } : null;
                    _cookies.Remove(value);
                    _cookies.Add("BoardNo", key);
                    break;
                default:
                    break;
            }

            dataGridView1.DataSource = data;
            DatagridViewPerformance();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string judge = dataGridView1.Rows[i].Cells["Column4"].Value.ToString();
                if (judge == "OK")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                if (judge == "NG")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void DatagridViewPerformance()
        {
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void cboValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchKey.SelectAll();
            txtSearchKey.Focus();
            var searchOption = cbbSearchOption.Text;
            txtSearchKey.Text = _cookies.ContainsKey(searchOption) ? _cookies[searchOption] : "";
            txtSearchKey.SelectAll();
            txtSearchKey.Focus();
        }

        private void txtSearchKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn không có quyền xóa dữ liệu!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    if (MessageBox.Show("Bạn có chắc muốn xóa bản mạch này không?", "Xóa bản ghi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            //        DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            //        string boardNo = Convert.ToString(selectedRow.Cells["Column1"].Value);
            //        string boxId = Convert.ToString(selectedRow.Cells["Column3"].Value);
            //        try
            //        {
            //            SingletonHelper.PVSInstance.KyoRemoveBoard(boardNo);
            //            MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            UpdateGui(boxId);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Lỗi!\n{ex.Message}", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void MenuItemAllBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn không có quyền xóa dữ liệu!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            //    string boxId = Convert.ToString(selectedRow.Cells["Column3"].Value);
            //    if (MessageBox.Show($"Bạn có chắc muốn xóa tất bản mạch trong thùng [{boxId}] này không?", "Xóa bản ghi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            var data = SingletonHelper.PVSInstance.KyoGetMac(boxId);
            //            foreach (var item in data)
            //            {
            //                SingletonHelper.PVSInstance.KyoRemoveBoard(item.ProductionID);
            //            }
            //            MessageBox.Show($"Xóa tất cả bản mạch trong thùng [{boxId}] thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            dataGridView1.DataSource = null;
            //            dataGridView1.Refresh();
            //            lblQuantity.Text = $"0/{(int)UsapHelper.BCLBFLM.OS_QTY}";
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Lỗi!\n{ex.Message}", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void MenuItemCopyCell_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var data = dataGridView1.SelectedCells[0].Value.ToString();
                //int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                //string boardNo = Convert.ToString(selectedRow.Cells["Column1"].Value);
                //Clipboard.SetText(boardNo);
                Clipboard.SetText(data);
            }
        }

        private void txtMac_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtMac.Text))
                {
                    return;
                }
                this.Enabled = false;
                DisplayMessage("N/A", "Waiting...");
                var worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(CheckData);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SaveData);
                worker.RunWorkerAsync(argument: txtBarcode.Text);
            }
        }
    }
}
