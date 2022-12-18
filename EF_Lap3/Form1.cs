using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EF_Lap3
{
    public partial class Form1 : Form
    {
        Model1 Ent = new Model1();  
        public Form1()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text ="";

            var deptid = from dept in Ent.departments select dept.id;
            
            foreach(var item in deptid)
            {
                comboBox1.Items.Add(deptid.ToString());
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(comboBox1.Text);

            department dept = Ent.departments.Find(id);

            if(dept != null)
            {
                textBox1.Text = dept.id.ToString();
                textBox2.Text = dept.name;

                foreach(empolyee emp in dept.empolyees)
                {
                    comboBox2.Items.Add(emp.id);
                }
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
    }
}
