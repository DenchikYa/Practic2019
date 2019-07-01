using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using Entities;

namespace PresentationLayer
{
    public partial class Form5 : Form
    {
        private UserLogic userLogic = new UserLogic();
        private AwardLogic awardLogic = new AwardLogic();

        public Form5()
        {
            InitializeComponent();
            comboBox1.DataSource = userLogic.GetAll();
            comboBox2.DataSource = awardLogic.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User<string> c = (User<string>)comboBox1.SelectedItem;
            Award a = (Award)comboBox2.SelectedItem;
            awardLogic.presentAward(c.ID, a.ID);
        }
    }
}
