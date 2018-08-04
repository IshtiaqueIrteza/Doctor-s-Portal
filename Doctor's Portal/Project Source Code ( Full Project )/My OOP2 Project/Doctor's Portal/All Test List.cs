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
    public partial class All_Test_List : Form
    {
        Hospital_DatabaseDataContext h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");

        public All_Test_List()
        {
            InitializeComponent();
        }

        private void All_Test_List_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = h.Test_Lists;
        }

        private void GridViewUpdate()
        {
            h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = h.Test_Lists;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test_List a = new Test_List();

            if (textBox2.Text != string.Empty)
            {
                a.Name = textBox2.Text;
                h.Test_Lists.InsertOnSubmit(a);
                h.SubmitChanges();
                GridViewUpdate();
            }
            else
            {
                MessageBox.Show("Please insert Name of Test !!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                int parsedValue;

                if (!int.TryParse(textBox1.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value for Test ID !!");
                }
                else
                {
                    var x = from a in h.Test_Lists
                            where a.Id == int.Parse(textBox1.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        x.FirstOrDefault().Name = textBox2.Text;
                        h.SubmitChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill Up Both ID & Name Field !!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox2.Text != string.Empty)
            {
                var x = from a in h.Test_Lists
                        where a.Name == textBox2.Text
                        select a;

                if (!x.Any())
                {
                    MessageBox.Show("Nothing Found !!!");
                }
                else
                {
                    foreach (Test_List m in x)
                    {
                        h.Test_Lists.DeleteOnSubmit(m);
                    }

                    h.SubmitChanges();
                    GridViewUpdate();

                    textBox1.Text = textBox2.Text = string.Empty;
                }
            }
            else if ((textBox1.Text != string.Empty && textBox2.Text == string.Empty) || (textBox1.Text != string.Empty && textBox2.Text != string.Empty))
            {
                int parsedValue;

                if (!int.TryParse(textBox5.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value for ID !");
                }
                else
                {
                    var x = from a in h.Test_Lists
                            where a.Id == int.Parse(textBox1.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        foreach (Test_List m in x)
                        {
                            h.Test_Lists.DeleteOnSubmit(m);
                        }

                        h.SubmitChanges();
                        GridViewUpdate();

                        textBox1.Text = textBox2.Text = string.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("Insert a Test Name or ID to Delete it !!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty && textBox5.Text == string.Empty)
            {
                MessageBox.Show("Please insert a Name or Id To Search !!!");
            }
            else if (textBox3.Text != string.Empty && textBox5.Text == string.Empty)
            {

                var x = from a in h.Test_Lists
                        where a.Name == textBox3.Text
                        select a;

                if (!x.Any())
                {
                    MessageBox.Show("Nothing Found !!!");
                }
                else
                {
                    textBox1.Text = (x.First().Id).ToString();
                    textBox2.Text = x.FirstOrDefault().Name;
                    dataGridView1.DataSource = x.ToList();
                }
            }
            else if (textBox3.Text == string.Empty && textBox5.Text != string.Empty)
            {
                int parsedValue;

                if (!int.TryParse(textBox5.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value !");
                }
                else
                {
                    var x = from a in h.Test_Lists
                            where a.Id == int.Parse(textBox5.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        textBox1.Text = (x.First().Id).ToString();
                        textBox2.Text = x.FirstOrDefault().Name;
                        dataGridView1.DataSource = x.ToList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Insert either a Name or a Id !!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = string.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = string.Empty;
        }
    }
}
