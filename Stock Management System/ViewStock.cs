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
    public partial class ViewStock : Form
    {
        public ViewStock()
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

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text == "")
            {
                MessageBox.Show("Please select an Item!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RequestItem form7 = new RequestItem();
                form7.lblMID.Text = lblMID.Text;
                form7.txtRItemCode.Text = txtItemID.Text;
                form7.Show();
                this.Hide();
            }
        }

        private void ViewStock_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ShowroomDB;Integrated Security=True");
                connection.Open();

                String cmd = "SELECT *  FROM dbo.[Stock_vs_Warehouse_Item]";
                SqlCommand command = new SqlCommand(cmd, connection);

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

        private void dgvStock_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvStock.Rows[e.RowIndex];
                    txtItemID.Text = row.Cells[0].Value.ToString();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
