using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessLogic;

namespace PresentationLayer
{
    public partial class Form4 : Form
    {
        private AwardLogic awardLogic = new AwardLogic();
        public Form4()
        {
            InitializeComponent();
            dataGridView1.DataSource = awardLogic.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            awardLogic.Add(new Award(textBox1.Text));
            dataGridView1.DataSource = awardLogic.GetAll();
        }
    }
}
