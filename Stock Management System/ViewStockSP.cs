using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stock_Management_System
{
    public partial class ViewStockSP : Form
    {
        public ViewStockSP()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SalesPersonPanel form13 = new SalesPersonPanel();
            form13.lblSPNIC.Text = lblSPNIC.Text;
            form13.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text == "")
            {
                MessageBox.Show("Please enter Item Code!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("viewStock", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemCode", txtItemID.Text);

                    dgvStock.DataSource = null;
                    dgvStock.Rows.Clear();

                    SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    dAdapter.Fill(ds);
                    dgvStock.ReadOnly = true;
                    dgvStock.DataSource = ds.Tables[0];
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text == "")
            {
                MessageBox.Show("Please enter Item Code!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                RequestItem_SP form7 = new RequestItem_SP();
                form7.lblSPNIC.Text = lblSPNIC.Text;
                form7.txtRItemCode.Text = txtItemID.Text;
                form7.Show();
                this.Hide();
            }
        }
    }
}
