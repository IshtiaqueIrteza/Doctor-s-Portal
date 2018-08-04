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
    public partial class Doctor_s_Panel : Form
    {
        Hospital_DatabaseDataContext h = new Hospital_DatabaseDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\My OOP2 Project\Doctor's Portal\Hospital Database.mdf;Integrated Security=True;Connect Timeout=30");

        AutoCompleteStringCollection Medicine = new AutoCompleteStringCollection();
        AutoCompleteStringCollection Disease = new AutoCompleteStringCollection();
        AutoCompleteStringCollection Test = new AutoCompleteStringCollection();
        AutoCompleteStringCollection Symptom = new AutoCompleteStringCollection();
        
        int Id;
        
        public Doctor_s_Panel(int Id)
        {
            InitializeComponent();
            
            panel5.Hide();
            flowLayoutPanel2.Hide();
            label28.Hide();
            textBox6.Hide();
            button3.Hide();

            flowLayoutPanel3.Hide();
            label29.Hide();
            textBox7.Hide();
            button4.Hide();

            flowLayoutPanel4.Hide();
            label30.Hide();
            textBox8.Hide();
            button5.Hide();

            panel6.Hide();
            
            this.Id = Id;

            AutoCompletedText();

            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox3.Text != string.Empty)
            {
                try
                {
                    Patient_Info p = new Patient_Info();
                    p.Name = textBox1.Text;
                    p.Age = int.Parse(textBox2.Text);
                    p.Blood_Group = textBox3.Text;
                    p.Contact = textBox5.Text;
                    h.Patient_Infos.InsertOnSubmit(p);
                    h.SubmitChanges();

                    var x = from a in h.Patient_Infos
                            where a.Contact == textBox5.Text
                            select a;

                    // label19
                    // 
                    this.label19.Text = "Patient\'s Id :";
                    // 
                    // label20
                    // 
                    this.label20.Text = "Patient\'s Name :";
                    // 
                    // label21
                    // 
                    this.label21.Text = "Age :";
                    // 
                    // label23
                    // 
                    this.label23.Text = "Blood Group :";
                    // 
                    // label24
                    // 
                    this.label24.Text = (x.First().Id).ToString();
                    // 
                    // label25
                    // 
                    this.label25.Text = textBox1.Text;
                    // 
                    // label26
                    // 
                    this.label26.Text = textBox3.Text;
                    // 
                    // label27
                    // 
                    this.label27.Text = textBox2.Text;

                    panel3.Dispose();
                    panel4.Dispose();

                    panel5.Show();

                    flowLayoutPanel2.Show();
                    label28.Show();
                    textBox6.Show();
                    button3.Show();

                    flowLayoutPanel3.Show();
                    label29.Show();
                    textBox7.Show();
                    button4.Show();

                    flowLayoutPanel4.Show();
                    label30.Show();
                    textBox8.Show();
                    button5.Show();

                    panel6.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !! Probably Wrong Format Data Inserted !!");
                }
            }
            else
            {
                MessageBox.Show("Please Fill Up Required Information !");
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = from a in h.Patient_Infos
                    where a.Contact == textBox4.Text
                    select a;

            if (!x.Any())
            {
                MessageBox.Show("Nothing Found");
            }
            else
            {
                label24.Text = (x.First().Id).ToString();
                label25.Text = x.First().Name;
                label26.Text = x.First().Blood_Group;
                label27.Text = (x.First().Age).ToString();
            }
        }

        private void Doctor_s_Panel_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Name = textBox6.Text;
            l.Text = textBox6.Text;

            flowLayoutPanel2.Controls.Add(l);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        void AutoCompletedText()
        {
            var x = from a in h.Medicine_Lists
                    select a.Name;

            foreach (string m in x)
            {
                Medicine.Add(m);
            }

            x = null;

            x = from a in h.Test_Lists
                select a.Name;

            foreach (string m in x)
            {
                Test.Add(m);
            }

            x = null;

            x = from a in h.Disease_Lists
                    select a.Name;

            foreach (string m in x)
            {
                Disease.Add(m);
            }

            x = null;

            x = from a in h.Symptom_Lists
                select a.Name;

            foreach (string m in x)
            {
               Symptom.Add(m);
            }

            //Symptom

            textBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox7.AutoCompleteCustomSource = Symptom;

            //Disease

            textBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox6.AutoCompleteCustomSource = Disease;

            //Test

            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox8.AutoCompleteCustomSource = Test;

            //Medicine

            textBox9.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox9.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox9.AutoCompleteCustomSource = Medicine;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != string.Empty)
            {
                tableLayoutPanel1.RowCount++;
                string[] row = { };
                //
            }
        }
    }
}
