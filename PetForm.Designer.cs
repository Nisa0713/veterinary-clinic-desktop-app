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

namespace VetClinicApp
{
    public partial class PetForm : Form
    {

        void LoadOwners()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT OwnerID, FullName FROM Owners", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbOwners.DataSource = dt;
                cmbOwners.DisplayMember = "FullName";
                cmbOwners.ValueMember = "OwnerID";
            }
        }

        void LoadPets()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT p.PetID, p.PetName, p.Species, p.Breed, p.BirthDate,
                     o.FullName AS Owner
              FROM Pets p
              JOIN Owners o ON p.OwnerID = o.OwnerID", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPets.DataSource = dt;
            }
        }

        public PetForm()
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

        private void PetForm_Load(object sender, EventArgs e)
        {
            LoadOwners();
            LoadPets();
            StyleGrid(dgvPets);
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Pets
              (OwnerID, PetName, Species, Breed, BirthDate)
              VALUES (@oid, @name, @species, @breed, @birth)", con);

                cmd.Parameters.AddWithValue("@oid", cmbOwners.SelectedValue);
                cmd.Parameters.AddWithValue("@name", txtPetName.Text);
                cmd.Parameters.AddWithValue("@species", txtSpecies.Text);
                cmd.Parameters.AddWithValue("@breed", txtBreed.Text);
                cmd.Parameters.AddWithValue("@birth", dtpBirthDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPets();
            MessageBox.Show("Pet added successfully.");
        }

        private void btnDeletePet_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a pet to delete.");
                return;
            }

            int petId = Convert.ToInt32(
                dgvPets.SelectedRows[0].Cells["PetID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this pet?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Pets WHERE PetID = @id", con);

                cmd.Parameters.AddWithValue("@id", petId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPets();
        }
    }
}


