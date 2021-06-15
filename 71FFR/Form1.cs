using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _71FFR
{
    public partial class Form1 : Form
    {
        static Form1 _obj;

        public static Form1 Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        public Button BtnLogin
        {
            get { return btnLogin; }
            set { btnLogin = value; }
        }

        public Button Button5
        {
            get { return button5; }
            set { button5 = value; }
        }

        public Button Button4
        {
            get { return button4; }
            set { button4 = value; }
        }
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (About uu = new About())
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .70d;
                    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Maximized;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    uu.Owner = formBackground;
                    uu.ShowDialog();

                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLogin.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
            _obj = this;

            UCLogin1 uc = new UCLogin1();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            home uu = new home();
            uu.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uu);
            Menu ui = new Menu();
            ui.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ui);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["home"].BringToFront();
            btnLogin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;
            panelContainer.Controls["home"].BringToFront();
            button5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            panelContainer.Controls["Menu"].BringToFront();
            button4.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.00)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }
    }
}
