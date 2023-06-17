using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System
{
    public partial class ManagerPanel : Form
    {
        public ManagerPanel()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form9 = new Form1();
            form9.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddSP form4 = new AddSP();
            form4.lblMID.Text = lblMID.Text;
            form4.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewSP form5 = new ViewSP();
            form5.lblMID.Text = lblMID.Text;
            form5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewStock form6 = new ViewStock();
            form6.lblMID.Text = lblMID.Text;
            form6.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            RequestItem form7 = new RequestItem();
            form7.lblMID.Text = lblMID.Text;
            form7.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ViewOrders form8 = new ViewOrders();
            form8.lblMID.Text = lblMID.Text;
            form8.Show();
            this.Hide();
        }
    }
}
