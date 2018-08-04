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
    public partial class Unregister_Form : Form
    {
        Hospital_DatabaseDataContext h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");

        public Unregister_Form()
        {
            InitializeComponent();
        }

        private void Unregister_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = h.Doctor_s_Lists;
        }

        private void GridViewUpdate()
        {
            h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = h.Doctor_s_Lists;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int parsedValue;

                if (!int.TryParse(textBox1.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value for Dr. ID !!");
                }
                else
                {
                    var x = from a in h.Doctor_s_Lists
                            where a.Id == int.Parse(textBox1.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        textBox2.Text = (x.FirstOrDefault().Name).ToString();
                        dataGridView1.DataSource = x.ToList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please insert an ID to Find a Dr.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int parsedValue;

                if (!int.TryParse(textBox1.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value for Dr. ID !!");
                }
                else
                {
                    var x = from a in h.Doctor_s_Lists
                            where a.Id == int.Parse(textBox1.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        foreach (Doctor_s_List m in x)
                        {
                            h.Doctor_s_Lists.DeleteOnSubmit(m);
                        }

                        h.SubmitChanges();
                        GridViewUpdate();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please insert an ID to Delete a Record.");
            }
        }
    }
}
