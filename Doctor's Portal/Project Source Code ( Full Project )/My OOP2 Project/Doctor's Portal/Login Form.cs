using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor_s_Portal
{
    public partial class Login : Form
    {
        Hospital_DatabaseDataContext h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");

        byte flag = 0;

        public Login()
        {
            InitializeComponent();
            panel1.Hide();
        }

        private void Doctor_Click(object sender, EventArgs e)
        {
            flag = 1;
            this.panel1.Location = new System.Drawing.Point(15, 209);
            Reset_All();
            panel1.Show();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            flag = 2;
            this.panel1.Location = new System.Drawing.Point(375, 209);
            Reset_All();
            panel1.Show();
        }

        private void Employee_Click(object sender, EventArgs e)
        {
            flag = 3;
            this.panel1.Location = new System.Drawing.Point(710, 209);
            Reset_All();
            panel1.Show();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Reset_All();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                var x = from a in h.Doctor_s_Lists
                        where (a.Username == textBox1.Text) && (a.Password == textBox2.Text)
                        select a;

                if (!x.Any())
                {
                    MessageBox.Show("Please use Valid Information !");
                }
                else
                {
                    Doctor_s_Panel p = new Doctor_s_Panel(x.First().Id);
                }
            }
            else if (flag == 2)
            {
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    if (textBox1.Text == "1" && textBox2.Text == "1")
                    {
                        Admin_Panel p = new Admin_Panel();
                        p.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Use Valid Identification !!");
                    }
                }
                else
                {
                    MessageBox.Show("You need to FillUp required Information");
                }
            }
            else if (flag == 3)
            {
                //
            }
        }

        private void Reset_All()
        {
            textBox1.Text = textBox2.Text = string.Empty;
        }
    }
}
