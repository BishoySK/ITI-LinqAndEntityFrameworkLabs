using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2EF
{
    public partial class Form1 : Form
    {
        EF Ent = new EF();
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)//Update_Empolyee
        {

            int ID = int.Parse(comboBox2.Text);

            var emp = (from empolyee in Ent.empolyees where empolyee.id == ID select empolyee).First();

            if(emp != null)
            {
                emp.name = textBox3.Text;
                emp.deptid = int.Parse(textBox4.Text); 
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }
        private void load()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text =textBox5.Text= "";
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

            if(dept != null)
            {
                textBox1.Text = dept.id.ToString();
                textBox2.Text = dept.name;
                comboBox2.Items.Clear();
                foreach(empolyee emp in dept.empolyees)
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
            var ID =int.Parse(comboBox2.Text);

            empolyee emp = Ent.empolyees.Find(ID);
            
                textBox3.Text = emp.name;
                textBox4.Text = emp.id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//add_department
        {
            department dept = new department();

            var insertedid = int.Parse(textBox1.Text);

            if(insertedid != dept.id)
            {
                dept.id = insertedid;
                dept.name = textBox2.Text;
                Ent.departments.Add(dept);
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }

        private void button2_Click(object sender, EventArgs e)//update_departmednt
        {

            int ID =int.Parse(textBox1.Text);
            
            var Dept = (from d in Ent.departments where d.id == ID select d).First();

            if(Dept != null)
            {
                Dept.name=textBox2.Text;
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }

        private void button3_Click(object sender, EventArgs e)//remove_department
        {


            int ID = int.Parse(textBox1.Text);

            var dept = (from d in Ent.departments where d.id == ID select d).First();

            if(dept != null)
            {
                Ent.departments.Remove(dept);
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }

        private void button4_Click(object sender, EventArgs e)//add_empolyee
        {

            empolyee emp = new empolyee(); //row
            int insertedid = int.Parse(textBox5.Text);
            if (insertedid != emp.id)
            {
                emp.id = insertedid;
                emp.name = textBox3.Text;
                emp.deptid = int.Parse(textBox4.Text);

                Ent.empolyees.Add(emp);//add row on table then collection
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }

        private void button6_Click(object sender, EventArgs e)//delete_empolyee
        {
            int ID = int.Parse(comboBox2.Text);

            var emp =(from empolyee in Ent.empolyees where empolyee.id == ID select empolyee).First();

            if(emp != null)
            {
                Ent.empolyees.Remove(emp);
                Ent.SaveChanges();
            }
            else
            {
                MessageBox.Show("Wrong ID");
            }
            load();
        }


    }
}
