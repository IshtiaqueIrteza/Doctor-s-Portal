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
    public partial class Admin_Panel : Form
    {
        public Admin_Panel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            All_Medicine_List m = new All_Medicine_List();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            All_Disease_List d = new All_Disease_List();
            d.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            All_Symptom_List s = new All_Symptom_List();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            All_Test_List t = new All_Test_List();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration_Form r = new Registration_Form();
            r.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Unregister_Form u = new Unregister_Form();
            u.Show();
        }
    }
}
