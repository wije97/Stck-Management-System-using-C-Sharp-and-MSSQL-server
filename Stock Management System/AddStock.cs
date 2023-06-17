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
    public partial class AddStock : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

        public AddStock()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtItemCode.Text=="" || txtxWID.Text=="" || txtItemName.Text=="" || txtType.Text=="" || txtDesc.Text=="" || txtPrice.Text=="" || txtQuantity.Text == "")
            {
                MessageBox.Show("Plese Enter All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "INSERT INTO  dbo.[Stock](Item_Code, warehouse_Id, Item_Name, Type, Description, Quantity, Price) " + " VALUES ('" + txtItemCode.Text + "','" + txtxWID.Text + "','" + txtItemName.Text + "','" + txtType.Text + "','" + txtDesc.Text + "','" + txtQuantity.Text + "','" + txtPrice.Text + "')";
                    String cmd2 = "INSERT INTO  dbo.[Sale_Stock](NIC, Item_Code) " + " VALUES ('" + lblSPNIC.Text + "','" + txtItemCode.Text + "')";

                    SqlCommand command = new SqlCommand(cmd, connection);
                    SqlCommand command2 = new SqlCommand(cmd2, connection);

                    int i = command.ExecuteNonQuery();
                    int j = command2.ExecuteNonQuery();

                    if (i != 0 && j != 0)
                    {
                        txtItemCode.ResetText();
                        txtItemName.ResetText();
                        txtDesc.ResetText();
                        txtPrice.ResetText();
                        txtQuantity.ResetText();
                        txtxWID.ResetText();
                        txtType.ResetText();
                        connection.Close();

                        MessageBox.Show("Item Added Successfully");
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
            if (txtSearchICode.Text == "")
            {
                MessageBox.Show("Plese Enter Item Code!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else{
                try
                {
                    connection.Open();

                    String cmd = "Select * FROM Stock WHERE Item_Code='" + txtSearchICode.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);


                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    dgvStockUpdate.DataSource = null;
                    dgvStockUpdate.Rows.Clear();

                    SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    dAdapter.Fill(ds);
                    dgvStockUpdate.ReadOnly = true;
                    dgvStockUpdate.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SalesPersonPanel form13 = new SalesPersonPanel();
            form13.lblSPNIC.Text = lblSPNIC.Text;
            form13.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemCode.ResetText();
            txtItemName.ResetText();
            txtDesc.ResetText();
            txtPrice.ResetText();
            txtQuantity.ResetText();
            txtxWID.ResetText();
            txtType.ResetText();

            dgvStockUpdate.DataSource = null;
            dgvStockUpdate.Rows.Clear();

            btnSave.Enabled = true;
            txtItemCode.ReadOnly = false;
            txtxWID.ReadOnly = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == "" || txtxWID.Text == "" || txtItemName.Text == "" || txtType.Text == "" || txtDesc.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Plese Enter All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "UPDATE dbo.[Stock] SET Item_Name='" + txtItemName.Text + "', Type='" + txtType.Text + "', Description='" + txtDesc.Text + "', Quantity='" + txtQuantity.Text + "', Price='" + txtPrice.Text + "' WHERE Item_Code='" + txtItemCode.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        txtItemCode.ResetText();
                        txtItemName.ResetText();
                        txtDesc.ResetText();
                        txtPrice.ResetText();
                        txtQuantity.ResetText();
                        txtxWID.ResetText();
                        txtType.ResetText();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearchICode.Text == "")
            {
                MessageBox.Show("Plese Enter Item Code!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    connection.Open();

                    String cmd = "DELETE  FROM Stock WHERE Item_Code='" + txtSearchICode.Text + "';";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i != 0)
                    {
                        txtItemCode.ResetText();
                        txtItemName.ResetText();
                        txtDesc.ResetText();
                        txtPrice.ResetText();
                        txtQuantity.ResetText();
                        txtxWID.ResetText();
                        txtType.ResetText();
                        connection.Close();

                        MessageBox.Show("Item Deleted Successfully");
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

        private void dgvStockUpdate_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                txtItemCode.ReadOnly = true;
                txtxWID.ReadOnly = true;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvStockUpdate.Rows[e.RowIndex];
                    txtItemCode.Text = row.Cells[0].Value.ToString();
                    txtxWID.Text = row.Cells[1].Value.ToString();
                    txtItemName.Text = row.Cells[2].Value.ToString();
                    txtType.Text = row.Cells[3].Value.ToString();
                    txtDesc.Text = row.Cells[4].Value.ToString();
                    txtQuantity.Text = row.Cells[5].Value.ToString();
                    txtPrice.Text = row.Cells[6].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
