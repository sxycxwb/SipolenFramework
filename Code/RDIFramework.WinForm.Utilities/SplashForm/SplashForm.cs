using System;
using System.Windows.Forms;
using System.Threading;

namespace RDIFramework.WinForm.Utilities
{
    public delegate void DelegateCloseSplash();

    /// <summary>
    /// SplashForm
    /// 
    /// </summary>
    public partial class SplashForm : Form
    {
        public static SplashForm instance;
        private DelegateCloseSplash delegateClose;
        private static Thread InstanceCaller = null;

        public SplashForm()
        {
            InitializeComponent();
            // Setup the form
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            this.TransparencyKey = this.BackColor;

            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SplashForm_KeyUp);
            this.MouseDown += new MouseEventHandler(SplashForm_MouseClick);        

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            delegateClose = new DelegateCloseSplash(InternalCloseSplash);
        }
        
        public static void ShowModal()
        {           
            MySplashThreadFunc();
        }

        public static void StartSplash()
        {         
            InstanceCaller = new Thread(new ThreadStart(MySplashThreadFunc));            
            InstanceCaller.Start();
        }

        public static void CloseSplash()
        {
            if (instance == null)
            {
                Thread.Sleep(1000);
            }

            try
            {
                if (instance.InvokeRequired)
                {
                    instance.Invoke(instance.delegateClose);
                }
                else
                {
                    instance.Close();
                    instance.Dispose();
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(500);
            }
            finally
            {
                if (InstanceCaller != null)
                {
                    InstanceCaller.Join();
                }
            }
        }
       
        protected override void Dispose(bool disposing)
        {          
            base.Dispose(disposing);
            instance = null;
        }     

        #region Threading code
        void InternalCloseSplash()
        {
            instance.Close();
            instance.Dispose();
            //this.Close();
            //this.Dispose();
        }

        private static void MySplashThreadFunc()
        {
            instance = new SplashForm();
            instance.TopMost = true;
            instance.ShowDialog();            
        }
        #endregion 


        void SplashForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.InternalCloseSplash();
        }     

        private void SplashForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.InternalCloseSplash();
        }
     
    }
}
