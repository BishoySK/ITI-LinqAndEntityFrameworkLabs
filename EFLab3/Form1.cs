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

namespace EFLab3
{
    public partial class Form1 : Form
    {
        Model1 Ent = new Model1();  
        public Form1()
        {
            InitializeComponent();
        }
        private void load()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text=textBox5.Text= "";
            var dept = from d in Ent.departments
                       select d.id;

            foreach (var item in dept)
            {
                comboBox1.Items.Add(item);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ID = int.Parse(comboBox1.Text);

            department dept = Ent.departments.Find(ID);

            if (dept != null)
            {
                textBox1.Text = dept.id.ToString();
                textBox2.Text = dept.name;
                comboBox2.Items.Clear();
                foreach (empolyee emp in dept.empolyees)
                {
                    comboBox2.Items.Add(emp.id);
                }
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(comboBox1.Text);

            empolyee emp = Ent.empolyees.Find(id);

            textBox3.Text=emp.deptid.ToString();
            textBox4.Text = emp.name;
            textBox5.Text = emp.id.ToString();


        }

        private void button1_Click(object sender, EventArgs e)//add_dept
        {
            department dpt = new department();

            var id = int.Parse(textBox1.Text);

            department dept = Ent.departments.Find(id);

            if(dept == null )
            {
                dpt.id = int.Parse(textBox1.Text);
                dpt.name = textBox2.Text;
                Ent.departments.Add(dpt);
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }

        private void button2_Click(object sender, EventArgs e)//update_dept
        {
            var id = int.Parse(comboBox1.Text);

            department dpt = Ent.departments.Find(id);
            if( dpt != null)
            {
                dpt.name = textBox2.Text;
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }

            load();
        }

        private void button3_Click(object sender, EventArgs e)//remove_dept
        {
            department dept = Ent.departments.Find(int.Parse(comboBox1.Text));

            if( dept != null )
            {
                foreach(empolyee emp in dept.empolyees)
                {
                    Ent.empolyees.Remove(emp);
                }
                Ent.SaveChanges();
                Ent.departments.Remove(dept);
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }

        private void button4_Click(object sender, EventArgs e)//add_emp
        {
            empolyee emp = new empolyee();

            empolyee empl = Ent.empolyees.Find(int.Parse(textBox5.Text.ToString()));

            department dpt = Ent.departments.Find(int.Parse(textBox1.Text.ToString()));
            if(dpt != null)
            {
                if (empl == null)
                {
                    emp.id = int.Parse(textBox5.Text.ToString());
                    emp.name = textBox4.Text;
                    emp.deptid = int.Parse(textBox3.Text.ToString());
                    Ent.empolyees.Add(emp);
                    Ent.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Available empolyee ID");
                }
            }
            else
            {
                MessageBox.Show("Not available department");
            }

            load();
        }

        private void button5_Click(object sender, EventArgs e)//update_emp
        {
            empolyee emp = Ent.empolyees.Find(int.Parse(textBox5.Text));

            if( emp != null)
            {
                emp.deptid= int.Parse(textBox3.Text.ToString());
                emp.name=textBox4.Text;
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Available empolyee ID");
            }
            load();
        }

        private void button6_Click(object sender, EventArgs e)//remove_emp
        {
            empolyee emp = Ent.empolyees.Find(int.Parse(textBox5.Text));

            if (emp != null)
            {
                Ent.empolyees.Remove(emp);
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Available empolyee ID");
            }
            load();
        }
    }
}
