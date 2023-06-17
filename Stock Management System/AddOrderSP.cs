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
    public partial class AddOrderSP : Form
    {
        int item_Quantity, item_Price, total_Price, subTotal, quantityUpdate;
        string Items;

        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

        public AddOrderSP()
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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (txtCusID.Text == "" || txtDetails.Text == "" || txtTotalPrice.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (dgvCart.Rows.Count != 1)
                {

                    try
                    {
                        connection.Open();

                        String cmd = "INSERT INTO  dbo.[Orders](Cus_ID, NIC, Details, TotalPrice, Date) " + " VALUES ('" + txtCusID.Text + "','" + lblSPNIC.Text + "','" + txtDetails.Text + "','" + txtTotalPrice.Text + "','" + dtpOrderDate.Text + "')";

                        SqlCommand command = new SqlCommand(cmd, connection);

                        int i = command.ExecuteNonQuery();

                        if (i != 0 )
                        {

                            connection.Close();
                            getOredID();

                            txtCusID.ResetText();
                            txtDetails.ResetText();
                            txtTotalPrice.ResetText();
                            txtItemCode.ResetText();
                            txtQuantity.ResetText();
                            dtpOrderDate.ResetText();
                            cmbItem.ResetText();
                            
                            dgvCart.DataSource = null;
                            dgvCart.Rows.Clear();

                            MessageBox.Show("Order Placed Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Order Faliled!");
                            connection.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    connection.Close();
                }
                
                else
                {
                    MessageBox.Show("Please add items to List!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveCart_Click(object sender, EventArgs e)
        {
            try
            {
                txtDetails.Text = Items;
                txtTotalPrice.Text = subTotal.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void AddOrderSP_Load(object sender, EventArgs e)
        {
            string Sql = "SELECT Item_Name FROM dbo.Stock";
            
            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cmbItem.Items.Add(DR[0]);

            }
            connection.Close();
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (cmbItem.Text == "" || txtItemCode.Text == "" ||  txtQuantity.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    item_Quantity = item_Price = 0;

                    //#################### get Quntity and price from Stock ##################
                    connection.Open();
                    string cmd = "SELECT Quantity, Price  FROM dbo.[Stock]" + " WHERE  Item_Code='" + txtItemCode.Text + "';";

                    SqlCommand command1 = new SqlCommand(cmd, connection);

                    SqlDataReader reader = command1.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        item_Quantity = int.Parse(reader["Quantity"].ToString());
                        item_Price = int.Parse(reader["Price"].ToString());

                        reader.Close();

                        dgvCart.Rows.Add(cmbItem.Text, txtItemCode.Text, item_Price, txtQuantity.Text);

                        //################# calculation#######################

                        total_Price = (item_Price * int.Parse(txtQuantity.Text));
                        subTotal += total_Price;

                        Items += cmbItem.Text + ", ";

                        quantityUpdate = item_Quantity - int.Parse(txtQuantity.Text);

                        //################## updating quantity ##################
                        String cmd2 = "UPDATE dbo.[Stock] SET Quantity='" + quantityUpdate + "' WHERE Item_Code='" + txtItemCode.Text + "';";

                        SqlCommand command2 = new SqlCommand(cmd2, connection);

                        int i = command2.ExecuteNonQuery();

                        if (i != 0)
                        {
                            txtItemCode.ResetText();
                            cmbItem.ResetText();
                            txtQuantity.ResetText();

                            connection.Close();
                            MessageBox.Show("Added successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Update Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        connection.Close();

                    }
                    else
                    {
                        MessageBox.Show("Order Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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
            txtItemCode.ResetText();
            txtQuantity.ResetText();
            cmbItem.ResetText();

            dgvCart.DataSource = null;
            dgvCart.Rows.Clear();


        }
        private void sales_order(int OID)
        {
            try
            {
                int m = 0;
                int tableRows = dgvCart.RowCount - 1;
                int[] array = new int[tableRows];

                for (int i = 0; i < dgvCart.Rows.Count-1; i++)
                {
                    array[i] = int.Parse(dgvCart.Rows[i].Cells[1].Value.ToString().Trim());
                }

                connection.Open();

                for (int k=0; k< dgvCart.Rows.Count - 1; k++)
                {
                    int code = array[k];

                    String cmd = "INSERT INTO  dbo.[Stock_Oder](Order_ID, Item_Code) " + " VALUES ('" + OID + "','" + code + "')";

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int j = command.ExecuteNonQuery();
                    ++m;
                    if (j != 0)
                    {
                        if (m== dgvCart.Rows.Count - 1)
                        {
                            connection.Close();
                        }
                        
                    }
                    else
                    {
                        connection.Close();
                    }

                }
                connection.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOredID()
        {
            try
            {
                connection.Open();

                String cmd = "SELECT TOP(1) Order_ID FROM dbo.[Orders] ORDER BY[Order_ID] DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd,connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count != 0)
                {

                    SqlCommand command = new SqlCommand(cmd, connection);

                    int j = command.ExecuteNonQuery();
                    if (j != 0)
                    {
                        SqlDataReader data = command.ExecuteReader();
                        if (data.Read())
                        {
                            int orderID = int.Parse(data.GetValue(0).ToString());
                           
                            connection.Close();
                            sales_order(orderID);

                        }

                    }
                    else
                    {
                        connection.Close();
                    }
                }
                else
                {
                    connection.Close();
                    sales_order(1);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
