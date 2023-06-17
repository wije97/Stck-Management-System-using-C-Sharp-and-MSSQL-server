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
    public partial class ViewSP : Form
    {
        public ViewSP()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");

            if (txtSearch.Text == "")
            {
                MessageBox.Show("Enter NIC!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("viewSalesPerson", connection);
                    
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NIC", txtSearch.Text);

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerPanel form2 = new ManagerPanel();
            form2.lblMID.Text = lblMID.Text;
            form2.Show();
            this.Hide();
        }
    }
}
