using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyoceraVIPackingSystem
{
    public partial class frmWaitForm : Form
    {
        public Action Worker { get; set; }
        public frmWaitForm(Action worker)
        {
            InitializeComponent();
            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            System.Threading.Tasks.Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
