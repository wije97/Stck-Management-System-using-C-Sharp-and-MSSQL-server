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
    public partial class Form1 : Form
    {
        String NIC_SP, MID;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

            if (txtUserName.Text=="" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    String cmd1 = "SELECT User_Name, Password, NIC  FROM dbo.[Sales_Person]" + " WHERE  User_Name='" + txtUserName.Text + "' AND Password='" + txtPassword.Text + "';";
                    SqlCommand command = new SqlCommand(cmd1, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        NIC_SP = reader["NIC"].ToString();

                        SalesPersonPanel form13 = new SalesPersonPanel();
                        form13.lblSPNIC.Text = NIC_SP;
                        form13.Show();
                        this.Hide();

                        reader.Close();
                        connection.Close();
                    }
                    else
                    {
                        reader.Close();
                        String cmd2 = "SELECT Username, Password, Manager_Id  FROM dbo.[Manager]" + " WHERE  Username='" + txtUserName.Text + "' AND Password='" + txtPassword.Text + "';";
                        SqlCommand command2 = new SqlCommand(cmd2, connection);

                        SqlDataReader reader2 = command2.ExecuteReader();

                        if (reader2.Read() == true)
                        {
                            MID = reader2["Manager_Id"].ToString();

                            ManagerPanel form2 = new ManagerPanel();
                            form2.lblMID.Text = MID;
                            form2.Show();
                            this.Hide();

                            reader2.Close();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtUserName.ResetText();
                            txtPassword.ResetText();

                            reader2.Close();
                            connection.Close();
                        }
                        
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
