using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetClinicApp
{
    public partial class OwnerForm : Form
    {
        public OwnerForm()
        {
            InitializeComponent();
           
        }

        void StyleGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }
        private void OwnerForm_Load(object sender, EventArgs e)
        {
            LoadOwners();
            StyleGrid(dgvOwners);
        }
        void LoadOwners()
        {
          
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM Owners", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOwners.DataSource = dt;
            }
        }
        

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Owners (FullName, Phone, Email, Address)
              VALUES (@n, @p, @e, @a)", con);

                cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@a", txtAddress.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadOwners();
            MessageBox.Show("Owner added successfully!");
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an owner to delete.");
                return;
            }

            int ownerId = Convert.ToInt32(
                dgvOwners.SelectedRows[0].Cells["OwnerID"].Value);

            if (MessageBox.Show(
                "Deleting this owner may affect pets. Continue?",
                "Confirm Delete",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(Database.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Owners WHERE OwnerID = @id", con);

                    cmd.Parameters.AddWithValue("@id", ownerId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadOwners();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Cannot delete owner because related records exist.");
            }
        }
    }
 }

