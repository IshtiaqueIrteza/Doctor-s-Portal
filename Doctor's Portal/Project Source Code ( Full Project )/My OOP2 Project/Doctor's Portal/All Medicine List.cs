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
    public partial class All_Medicine_List : Form
    {
        Hospital_DatabaseDataContext h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");

        public All_Medicine_List()
        {
            InitializeComponent();
        }

        private void All_Medicine_List_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = h.Medicine_Lists;
        }

        private void GridViewUpdate()
        {
            h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = h.Medicine_Lists;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Medicine_List a = new Medicine_List();

            if (textBox2.Text != string.Empty && textBox1.Text != string.Empty && textBox4.Text != string.Empty)
            {
                a.Name = textBox2.Text;
                a.Manufacturer = textBox1.Text;
                a.Retail_Price_Tk__ = float.Parse(textBox4.Text);
                h.Medicine_Lists.InsertOnSubmit(a);
                h.SubmitChanges();
                GridViewUpdate();
            }
            else
            {
                MessageBox.Show("Please insert all necessary Information !!!");
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

                var x = from a in h.Medicine_Lists
                        where a.Name == textBox3.Text
                        select a;

                if (!x.Any())
                {
                    MessageBox.Show("Nothing Found !!!");
                }
                else
                {
                    textBox2.Text = x.FirstOrDefault().Name;
                    textBox1.Text = x.First().Manufacturer;
                    textBox4.Text = (x.First().Retail_Price_Tk__).ToString();
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
                    var x = from a in h.Medicine_Lists
                            where a.Id == int.Parse(textBox5.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        textBox2.Text = x.FirstOrDefault().Name;
                        textBox1.Text = x.First().Manufacturer;
                        textBox4.Text = (x.First().Retail_Price_Tk__).ToString();
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
            textBox2.Text = textBox1.Text = textBox4.Text = string.Empty;
            GridViewUpdate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text = textBox4.Text = textBox3.Text = textBox5.Text = string.Empty;
            GridViewUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox1.Text != string.Empty && textBox4.Text != string.Empty)
            {

                var x = from a in h.Medicine_Lists
                        where a.Name == textBox2.Text
                        select a;

                if (!x.Any())
                {
                    MessageBox.Show("Nothing Found !!!");
                }
                else
                {
                    float parsedValue;

                    if (!float.TryParse(textBox4.Text, out parsedValue))
                    {
                        MessageBox.Show("Please insert only numeric value on Price Field !!");
                    }
                    else
                    {
                        x.FirstOrDefault().Name = textBox2.Text;
                        x.First().Manufacturer = textBox1.Text;
                        x.First().Retail_Price_Tk__ = float.Parse(textBox4.Text);
                        h.SubmitChanges();
                    }
                   
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty)
            {
                var x = from a in h.Medicine_Lists
                        where a.Name == textBox2.Text
                        select a;

                if (!x.Any())
                {
                    MessageBox.Show("Nothing Found !!!");
                }
                else
                {
                    foreach (Medicine_List m in x)
                    {
                        h.Medicine_Lists.DeleteOnSubmit(m);
                    }

                    h.SubmitChanges();
                    GridViewUpdate();
                }
            }
            else
            {
                MessageBox.Show("Insert a Medicine Name to Delete it !!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != string.Empty)
            {
                int parsedValue;

                if (!int.TryParse(textBox5.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value !");
                }
                else
                {
                    var x = from a in h.Medicine_Lists
                            where a.Id == int.Parse(textBox5.Text)
                            select a;

                    if (!x.Any())
                    {
                        MessageBox.Show("Nothing Found !!!");
                    }
                    else
                    {
                        foreach (Medicine_List m in x)
                        {
                            h.Medicine_Lists.DeleteOnSubmit(m);
                        }

                        h.SubmitChanges();
                        GridViewUpdate();
                    }
                }
            }
            else
            {
                MessageBox.Show("Insert a Medicine Name to Delete it !!!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != string.Empty)
            {
                int parsedValue;

                if (!int.TryParse(textBox5.Text, out parsedValue))
                {
                    MessageBox.Show("Please insert only numeric value for Id !");
                }
                else
                {
                    if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox4.Text != string.Empty)
                    {
                        var x = from a in h.Medicine_Lists
                                where a.Id == int.Parse(textBox5.Text)
                                select a;

                        if (!x.Any())
                        {
                            MessageBox.Show("Nothing Found !!!");
                        }
                        else
                        {
                            float parsedValue1;

                            if (!float.TryParse(textBox4.Text, out parsedValue1))
                            {
                                MessageBox.Show("Please insert only numeric value on Price Field !!");
                            }
                            else
                            {
                                x.FirstOrDefault().Name = textBox2.Text;
                                x.First().Manufacturer = textBox1.Text;
                                x.First().Retail_Price_Tk__ = float.Parse(textBox4.Text);
                                h.SubmitChanges();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Up Every Required Field");
                    }
                   

                }
            }
            else
            {
                MessageBox.Show("Insert Medicine Id to Update it !!");
            }
        }
    }
}
