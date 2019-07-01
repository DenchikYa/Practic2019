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
    public partial class Form3 : Form
    {
        private UserLogic userLogic = new UserLogic();

        public Form3()
        {
            InitializeComponent();
            comboBox1.DataSource = userLogic.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User<string> c = (User<string>)comboBox1.SelectedItem;
            userLogic.Remove(c.ID);
            Close();
        }
    }
}
