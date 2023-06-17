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
    public partial class ViewOrderSP : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

        public ViewOrderSP()
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

        private void btnSearchCID_Click(object sender, EventArgs e)
        {
            txtSearchOID.ResetText();

            if (txtSearchCID.Text == "")
            {
                MessageBox.Show("Please enter Customer ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "Select * FROM getOrder_withCustomerTV(@CustomerID)";

                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@CustomerID", txtSearchCID.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    dgvView.DataSource = null;
                    dgvView.Rows.Clear();

                    SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    dAdapter.Fill(ds);
                    dgvView.ReadOnly = true;
                    dgvView.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearchOID_Click(object sender, EventArgs e)
        {
            txtSearchCID.ResetText();

            if (txtSearchOID.Text == "")
            {
                MessageBox.Show("Please enter Order ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "Select * FROM Orders WHERE Order_ID='" + txtSearchOID.Text +"';";

                    SqlCommand command = new SqlCommand(cmd, connection);
                    

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    dgvView.DataSource = null;
                    dgvView.Rows.Clear();

                    SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    dAdapter.Fill(ds);
                    dgvView.ReadOnly = true;
                    dgvView.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchCID.ResetText();
            txtSearchOID.ResetText();

            dgvView.DataSource = null;
            dgvView.Rows.Clear();

        }
    }
}
