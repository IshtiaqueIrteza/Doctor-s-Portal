using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Doctor_s_Portal
{
    public partial class Registration_Form : Form
    {
        Hospital_DatabaseDataContext h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");

        public Registration_Form()
        {
            InitializeComponent();
            textBox10.Text = "1234";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg|*.jpg";

            DialogResult res = openFileDialog1.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty && textBox7.Text != string.Empty && textBox8.Text != string.Empty && textBox9.Text != string.Empty && textBox10.Text != string.Empty)
            {
                if (radioButton1.Checked || radioButton2.Checked)
                {
                    Doctor_s_List a = new Doctor_s_List();
                    a.Id = int.Parse(textBox1.Text);
                    a.Name = textBox2.Text;
                    a.Date_Of_Birth = Convert.ToDateTime(textBox3.Text);
                    a.Date_Joined = Convert.ToDateTime(textBox4.Text);
                    a.Designation = textBox5.Text;
                    a.Specialty = textBox6.Text;
                    a.Mobile_No_ = textBox7.Text;
                    a.Address = textBox8.Text;
                    a.Username = textBox9.Text;
                    a.Password = textBox10.Text;

                    if (radioButton1.Checked)
                    {
                        a.Gender = "Male";
                    }
                    else
                    {
                        a.Gender = "Female";
                    }

                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                            a.Image = binary;
                        }

                        h.Doctor_s_Lists.InsertOnSubmit(a);
                        h.SubmitChanges();

                        MessageBox.Show("Registration Completed Successfully");
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Registration error !! Please insert your information in proper way !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select your Gender");
                }
            }
            else
            {
                MessageBox.Show("Please provide all Information");
            }
        }

        private void Registration_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
