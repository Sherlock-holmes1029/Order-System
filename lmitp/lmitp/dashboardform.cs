using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmitp
{
    public partial class dashboardform : Form
    {
        public dashboardform()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dashboardform_Load(object sender, EventArgs e)
        {
            handingdate.MinDate= DateTime.Now.AddDays(1);
            chkBig.Checked = true;
            
        }

        private void cost_TextChanged(object sender, EventArgs e)
        {

        }

        private void cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void chkBig_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBig.Checked)
            {
              
                cartkg1.Enabled = true;
                cartkg1.Value = 1;
            
            }
            else
            {
                
                cartkg1.Enabled = false;
                cartkg1.Value = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                bolstkg1.Enabled= true;
                bolstkg1.Value = 1;
            }
            else
            {
                bolstkg1.Enabled= false;
                bolstkg1.Value = 0;
            }
        }

        private void chkSml_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSml.Checked)
            {
                bolstkgHalf.Enabled = true;
                bolstkgHalf.Value = 1;
            }
            else
            {
                bolstkgHalf.Enabled= false;
                bolstkgHalf.Value = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                bolstkgQuart.Enabled= true;
                bolstkgQuart.Value = 1;
            }
            else
            {
                bolstkgQuart.Enabled= false;
                bolstkgQuart.Value = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                kg3.Enabled= true;
                kg3.Value = 1;
            }
            else
            {
                kg3.Enabled= false;
                kg3.Value = 0;
            }
        }
    }
}
