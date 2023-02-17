using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace lmitp
{
    //todo: connect it with the data base and create the insert function 
    public partial class dashboardform : Form
    {
        SQLiteConnection con;
        public dashboardform()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dashboardform_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate= DateTime.Now.AddDays(1);
            chkC1.Checked = true;
            con = new SQLiteConnection("Data Source=farmSheet.db,Version=3;");
            
            
            
           

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


        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked)
            {
                bnsNumb.Enabled= true;
                bnsType.Enabled= true;
            }
            else
            {
                bnsNumb.Enabled= false;
                bnsType.Enabled= false;
                bnsType.Text = "-اختار--";
                bnsNumb.Value= 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            //check if text forms empty  
            if (string.IsNullOrEmpty(custName.Text))
            {
                errCustName.ForeColor = Color.Red;
                errCustName.Text = "*";
                flag += 1;
            }
            else
            {
                flag -= 1;
                errCustName.Text += "";
            }
            if (string.IsNullOrEmpty(phoneNumb.Text))
            {
                errCustNumb.ForeColor = Color.Red;
                errCustNumb.Text = "*";
                flag += 1;
            }
            else
            {
                flag -= 1;
                errCustNumb.Text = "";
            }
            if (string.IsNullOrEmpty(region.Text))
            {
                errCustLocation.ForeColor = Color.Red;
                errCustLocation.Text = "*";
                flag += 1;
            }
            else
            {
                flag -= 1;
                errCustLocation.Text = "";
            }
            if (string.IsNullOrEmpty(cost.Text))
            {
                errCost.ForeColor = Color.Red;
                errCost.Text = "*";
                flag += 1;
            }
            else
            {
                flag -= 1;
                errCost.Text = "";
            }
            //////////////////////
          

            if (flag == -4)
            {

                flag = 0;
               
                    string  sql = "INSERT INTO  customerData (Name,phoneNumb,Location,Date,Cost,BnsType,BnsNumb,c1,b1,bh,bq,p3) VALUES " +
                    "('" + custName.Text.ToString() + "','" + phoneNumb.Text.ToString() + "','" + region.Text.ToString() + "','" + dateTimePicker1.Value.ToString("d") + "'," +
                    ""+cost.Text.ToString()+","+bnsType.SelectedIndex.ToString()+","+bnsNumb.Value.ToString()+","+cartkg1.Value.ToString()+"," +
                    ""+bolstkg1.Value.ToString()+","+bolstkgHalf.Value.ToString()+","+bolstkgQuart.Value.ToString()+","+kg3.Value.ToString()+");";
                con.Open();
                SQLiteCommand cmd= new SQLiteCommand(sql,con);
                int done=cmd.ExecuteNonQuery();
                if (done!=0)
                {
                    MessageBox.Show(done.ToString());
                }
            }

        }

        private void chkC1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB1.Checked || chkBH.Checked || chkBQ.Checked || chkP3.Checked)
            {
                if (chkC1.Checked)
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
            else
            {
                cartkg1.Enabled = true;
                cartkg1.Value = 1;
                chkC1.Checked = true;

            }
        }

        private void chkB1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkC1.Checked || chkBH.Checked || chkBQ.Checked || chkP3.Checked)
            {
                if (chkB1.Checked)
                {
                    bolstkg1.Enabled = true;
                    bolstkg1.Value = 1;
                }
                else
                {
                    bolstkg1.Enabled = false;
                    bolstkg1.Value = 0;
                }
            }
            else
            {
                chkB1.Checked = true;

            }
        }

        private void chkBH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB1.Checked || chkC1.Checked || chkBQ.Checked || chkP3.Checked) { 
                if (chkBH.Checked)
            {
                bolstkgHalf.Enabled = true;
                bolstkgHalf.Value = 1;
            }
            else
            {
                bolstkgHalf.Enabled = false;
                bolstkgHalf.Value = 0;
            }
            }
            else
            {
                chkBH.Checked = true;

            }
        }

        private void chkBQ_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB1.Checked || chkBH.Checked || chkC1.Checked || chkP3.Checked)
            {
                if (chkBQ.Checked)
                {
                    bolstkgQuart.Enabled = true;
                    bolstkgQuart.Value = 1;
                }
                else
                {
                    bolstkgQuart.Enabled = false;
                    bolstkgQuart.Value = 0;
                }
            }
            else
            {
                chkBQ.Checked = true;

            }
        }

        private void chkP3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB1.Checked || chkBH.Checked || chkBQ.Checked || chkC1.Checked)
            {
                if (chkP3.Checked)
                {
                    kg3.Enabled = true;
                    kg3.Value = 1;
                }
                else
                {
                    kg3.Enabled = false;
                    kg3.Value = 0;
                }
            }
            else {
                chkP3.Checked = true;
            }
        }

        private void cost_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void phoneNumb_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
