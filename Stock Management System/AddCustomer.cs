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
    public partial class AddCustomer : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

        public AddCustomer()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAddress.Text=="" || txtCusID.Text=="" || txtEmail.Text=="" || txtMobile.Text=="" || txtName.Text=="" )
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "INSERT INTO  dbo.[Customer](Cus_ID, Full_Name, Email, Address, Contact) " + " VALUES ('" + txtCusID.Text + "','" + txtName.Text + "','" + txtEmail.Text + "','" + txtAddress.Text + "','" + txtMobile.Text + "')";
                    String cmd2 = "INSERT INTO  dbo.[SalesPerson_Customer](NIC, Cus_ID) " + " VALUES ('" + lblSPNIC.Text + "','" + txtCusID.Text + "')";

                    SqlCommand command = new SqlCommand(cmd, connection);
                    SqlCommand command2 = new SqlCommand(cmd2, connection);

                    int i = command.ExecuteNonQuery();
                    int j = command2.ExecuteNonQuery();

                    if (i != 0 && j != 0 )
                    {
                        txtCusID.ResetText();
                        txtName.ResetText();
                        txtEmail.ResetText();
                        txtAddress.ResetText();
                        txtMobile.ResetText();
                        connection.Close();

                        MessageBox.Show("Customer Added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Data not Saved");
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchCusID.Text == "")
            {
                MessageBox.Show("Please enter Customer ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "Select * FROM Customer WHERE Cus_ID='" + txtSearchCusID.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);


                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    dgvCus.DataSource = null;
                    dgvCus.Rows.Clear();

                    SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    dAdapter.Fill(ds);
                    dgvCus.ReadOnly = true;
                    dgvCus.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearchCusID.Text == "")
            {
                MessageBox.Show("Please enter Customer ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "DELETE  FROM Customer WHERE Cus_ID='" + txtSearchCusID.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        txtCusID.ResetText();
                        txtName.ResetText();
                        txtEmail.ResetText();
                        txtAddress.ResetText();
                        txtMobile.ResetText();
                        connection.Close();

                        MessageBox.Show("Customer Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Data not Deleted");
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtCusID.Text == "" || txtEmail.Text == "" || txtMobile.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "UPDATE dbo.[Customer] SET Full_Name='" + txtName.Text + "', Email='" + txtEmail.Text + "', Address='" + txtAddress.Text + "', Contact='" + txtMobile.Text + "' WHERE Cus_ID='" + txtCusID.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0 )
                    {
                        txtCusID.ResetText();
                        txtName.ResetText();
                        txtEmail.ResetText();
                        txtAddress.ResetText();
                        txtMobile.ResetText();

                        connection.Close();
                        MessageBox.Show("Updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvCus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                txtCusID.ReadOnly = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCus.Rows[e.RowIndex];
                    txtCusID.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    txtEmail.Text = row.Cells[2].Value.ToString();
                    txtAddress.Text = row.Cells[3].Value.ToString();
                    txtMobile.Text = row.Cells[4].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCusID.ResetText();
            txtName.ResetText();
            txtEmail.ResetText();
            txtAddress.ResetText();
            txtMobile.ResetText();
            txtSearchCusID.ResetText();

            dgvCus.DataSource = null;
            dgvCus.Rows.Clear();

            btnSave.Enabled = true;
            txtCusID.ReadOnly = false;

        }
    }
}
