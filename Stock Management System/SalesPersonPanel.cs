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
    public partial class SalesPersonPanel : Form
    {
        public SalesPersonPanel()
        {
            InitializeComponent();
        }

        private void btnAddViewCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer form10 = new AddCustomer();
            form10.lblSPNIC.Text = lblSPNIC.Text;
            form10.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewStockSP form11 = new ViewStockSP();
            form11.lblSPNIC.Text = lblSPNIC.Text;
            form11.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RequestItem_SP form7 = new RequestItem_SP();
            form7.lblSPNIC.Text = lblSPNIC.Text;
            form7.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewOrderSP form15 = new ViewOrderSP();
            form15.lblSPNIC.Text = lblSPNIC.Text;
            form15.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrderSP form14 = new AddOrderSP();
            form14.lblSPNIC.Text = lblSPNIC.Text;
            form14.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStock form16 = new AddStock();
            form16.lblSPNIC.Text = lblSPNIC.Text;
            form16.Show();
            this.Hide();
        }
    }
}
