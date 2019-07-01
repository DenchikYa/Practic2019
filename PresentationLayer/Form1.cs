using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogic.Interface;
using Entities;


namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private IUser userLogic;
        private ISkill awardLogic;

        public Form1(IUser userLogic, ISkill awardLogic)
        {
            this.awardLogic = awardLogic;
            this.userLogic = userLogic;

            InitializeComponent();
            dataGridView1.DataSource = userLogic.GetAll();
            comboBox1.DataSource = userLogic.GetAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userLogic.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User<string> c = (User<string>)comboBox1.SelectedItem;
            dataGridView2.DataSource = awardLogic.GetUserAwards(c.ID);
            
        }
    }
}
