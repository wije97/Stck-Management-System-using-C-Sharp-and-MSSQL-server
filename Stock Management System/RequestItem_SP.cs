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
    public partial class RequestItem_SP : Form
    {
        public RequestItem_SP()
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

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if ( txtRItemCode.Text == "" || txtRQuantity.Text == "" || txtWarehouseID.Text == "")
            {
                MessageBox.Show("Enter all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

                try
                {
                    connection.Open();

                    //##################### getting warehouse item quantity ##########################

                    String cmd = "SELECT WareHouseQuantity  FROM dbo.[Warehouse_Item]" + " WHERE  WareHouseItemCode='" + txtRItemCode.Text + "';";

                    SqlCommand command1 = new SqlCommand(cmd, connection);

                    SqlDataReader reader = command1.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        int warehouseQuantity = int.Parse(reader["WareHouseQuantity"].ToString());
                        reader.Close();

                        int requestedQuantity = int.Parse(txtRQuantity.Text);

                        if (warehouseQuantity == 0)
                        {
                            MessageBox.Show("Item Code " + txtRItemCode.Text + " Out of Stock!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (warehouseQuantity < requestedQuantity)
                        {
                            MessageBox.Show("Only " + warehouseQuantity + " pieces available in Warahouse!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //############## getting item quantity in stock ####################

                            String cmd2 = "SELECT Quantity  FROM dbo.[Stock]" + " WHERE  Item_Code='" + txtRItemCode.Text + "';";

                            SqlCommand command2 = new SqlCommand(cmd2, connection);

                            SqlDataReader reader2 = command2.ExecuteReader();

                            if (reader2.Read() == true)
                            {
                                int stockQuantity = int.Parse(reader2["Quantity"].ToString());
                                reader2.Close();

                                //############## add requested quantity to available item quantity in stock ##################
                                stockQuantity += requestedQuantity;

                                //################## removing requested quantity from available item quantity in Warehouse_Item #########
                                warehouseQuantity -= requestedQuantity;


                                // ################ updating tables ###################

                                String cmd3 = "UPDATE dbo.[Warehouse_Item] SET WareHouseQuantity='" + warehouseQuantity + "' WHERE WareHouseItemCode='" + txtRItemCode.Text + "';";
                                String cmd4 = "UPDATE dbo.[Stock] SET Quantity='" + stockQuantity + "' WHERE Item_Code='" + txtRItemCode.Text + "';";

                                SqlCommand command3 = new SqlCommand(cmd3, connection);
                                SqlCommand command4 = new SqlCommand(cmd4, connection);

                                int i = command3.ExecuteNonQuery();
                                int j = command4.ExecuteNonQuery();

                                if (i != 0 && j != 0)
                                {
                                    txtRItemCode.ResetText();
                                    txtRQuantity.ResetText();
                                    txtWarehouseID.ResetText();

                                    MessageBox.Show("Request sent successfully!");
                                }
                                else
                                {
                                    MessageBox.Show("Request Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Request Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
