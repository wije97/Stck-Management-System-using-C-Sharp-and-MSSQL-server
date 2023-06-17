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
    public partial class AddSP : Form
    {
        public AddSP()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerPanel form2 = new ManagerPanel();
            form2.lblMID.Text = lblMID.Text;
            form2.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

            if (txtAddress.Text=="" || txtEmail.Text=="" || txtMobile.Text=="" || txtName.Text=="" || txtNIC.Text=="" || txtPassword.Text=="" || txtUsername.Text=="" || cmbGender.Text == "")
            {
                MessageBox.Show("Plese Enter All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    String cmd = "INSERT INTO  dbo.[Sales_Person](NIC, Manager_Id, Address, Email, Gender, B_Day, Full_Name, User_Name, Password, Contact) " + " VALUES ('" + txtNIC.Text + "','" + lblMID.Text + "','" + txtAddress.Text + "','" + txtEmail.Text + "','" + cmbGender.Text + "','" + dtpDOB.Text + "','" + txtName.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtMobile.Text + "')";
                    SqlCommand command = new SqlCommand(cmd, connection);

                    int i = command.ExecuteNonQuery();

                    if (i == 0)
                    {
                        MessageBox.Show("Data not Saved");
                    }
                    else
                    {
                        MessageBox.Show(txtName.Text + " added as Sales Person.");
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
