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
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerPanel form2 = new ManagerPanel();
            form2.lblMID.Text = lblMID.Text;
            form2.Show();
            this.Hide();
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                String cmd = "SELECT *  FROM dbo.[Customer_vs_Orders]";
                SqlCommand command = new SqlCommand(cmd, connection);

                dgvOrders.DataSource = null;
                dgvOrders.Rows.Clear();

                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dgvOrders.ReadOnly = true;
                dgvOrders.DataSource = ds.Tables[0];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                
                int[] arrayCID = new int[dgvOrders.Rows.Count - 1];
                int x = 1;
                connection.Open();
                for(int a = 0; a< dgvOrders.Rows.Count - 1; a++)
                {
                    string cmd = "SELECT Cus_ID  FROM dbo.[Orders]" + " WHERE  Order_ID='" + x + "';";
                    SqlCommand command = new SqlCommand(cmd, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        arrayCID[a] = int.Parse(reader["Cus_ID"].ToString());

                        reader.Close();
                        x++;
                    }
                    else
                    {
                        MessageBox.Show("Sort Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }
                }

                connection.Close();

                int temp = 0;
                int arrLength = arrayCID.Length;

                for (int write = 0; write < arrayCID.Length - 1; write++, arrLength--)
                {
                    for (int sort = 0; sort < arrLength - 1; sort++)
                    {
                        if (arrayCID[sort] > arrayCID[sort + 1])
                        {
                            temp = arrayCID[sort + 1];
                            arrayCID[sort + 1] = arrayCID[sort];
                            arrayCID[sort] = temp;
                        }
                    }
                }

                connection.Open();
                dgvOrders.DataSource = null;
                dgvOrders.Rows.Clear();
                DataSet ds = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter();

                int n = arrayCID.Length;

                for (int b = 0; b < n; b++)
                {
                    String cmd = "SELECT * FROM dbo.[Customer_vs_Orders] WHERE  Cus_ID='" + arrayCID[b] + "';";
                    
                    SqlCommand command = new SqlCommand(cmd, connection);

                    dAdapter.SelectCommand = command;
                    dAdapter.Fill(ds);

                    
                    dgvOrders.ReadOnly = true;
                    dgvOrders.DataSource = ds.Tables[0];
                    
                }
                var newDataTable = ds.Tables[0];
                dgvOrders.DataSource = newDataTable.AsEnumerable().GroupBy(col => col.Field<int>("Order_ID"))
                .Select(d => d.First()).CopyToDataTable();


                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
