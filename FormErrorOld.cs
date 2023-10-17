using System;
using System.Drawing;
using System.Windows.Forms;

namespace KyoceraVIPackingSystem
{
    public partial class frmErrOld : Form
    {
        string boardNo = null;
        //LeaderConfirmsBLL leaderConfirmsBLL = new LeaderConfirmsBLL();
        //USERS_BLL userBLL = new USERS_BLL();
        public frmErrOld(string message, string ope, string board)
        {
            InitializeComponent();
            txtMessage.Text = message;
            lblOperator.Text = ope;
            boardNo = board;
        }

        private void FormError_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string leader = txtLeader.Text;
            //string password = txtPassword.Text;
            //if (!string.IsNullOrEmpty(txtMessage.Text) &&
            //    !string.IsNullOrEmpty(leader) &&
            //    !string.IsNullOrEmpty(txtNote.Text) && 
            //    !string.IsNullOrEmpty(password))
            //{
            //    var checkLeader = leaderConfirmsBLL.CheckLeaderConfirm(leader, password);
            //    if (checkLeader != null)
            //    {
            //        var log = new ErrorLogs()
            //        {
            //            Message = txtMessage.Text,
            //            LeaderConfirm = checkLeader.FullName,
            //            Note = txtNote.Text,
            //            OperatorInLine = lblOperator.Text,
            //            Date = userBLL.GetDateTime(),
            //            BoardNo = boardNo,
            //            Customer = "KYOCERA"
            //        };

            //        try
            //        {
            //            leaderConfirmsBLL.Insert(log);

            //            this.Dispose();
            //            this.Close();
            //        }
            //        catch (Exception)
            //        {

            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không chính xác. Vui lòng nhập kiểm tra lại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtLeader.Focus();
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng nhập đủ thông tin lỗi. Sau đó lưu lại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtLeader.Focus();
            //    return;
            //}
        }

        private void FormError_Load(object sender, EventArgs e)
        {
            txtLeader.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtMessage.ForeColor == Color.Maroon)
            {
                txtMessage.BackColor = Color.DarkOrange;
                txtMessage.ForeColor = Color.White;
            }
            else
            {
                txtMessage.BackColor = SystemColors.Window;
                txtMessage.ForeColor = Color.Maroon;
            }
        }
    }
}
