using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace lmitp
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            timer1.Enabled=true;
            timer1.Interval=1000;
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
            timer1.Start();
            
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
            loadform(new dashboardform());
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            loadform(new employeeform());
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            loadform(new reportsform());
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelheader_Paint(object sender, PaintEventArgs e)
        {

        }

        // to make the screen moveable 
        bool drag = false;
        Point startP;
        private void panelheader_MouseDown(object sender, MouseEventArgs e)
        {
            drag= true;
            startP= new Point(e.X,e.Y);
            
        }

        private void panelheader_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point point= PointToScreen(e.Location);
                this.Location= new Point(point.X-startP.X, point.Y-startP.Y);
            }
        }

        private void panelheader_MouseUp(object sender, MouseEventArgs e)
        {
            drag=false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("T");
        }
    }
}
