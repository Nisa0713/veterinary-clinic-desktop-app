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
    public partial class VaccinationForm : Form
    {

        void LoadPets()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT PetID, PetName FROM Pets", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPets.DataSource = dt;
                cmbPets.DisplayMember = "PetName";
                cmbPets.ValueMember = "PetID";
            }
        }
        void LoadVaccinations()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT v.VaccinationID,
                     p.PetName,
                     v.VaccineType,
                     v.DateGiven,
                     v.NextDueDate
              FROM Vaccinations v
              JOIN Pets p ON v.PetID = p.PetID", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVaccinations.DataSource = dt;
            }
        }
        public VaccinationForm()
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
        private void VaccinationForm_Load(object sender, EventArgs e)
        {
            LoadPets();
            LoadVaccinations();
            StyleGrid(dgvVaccinations);
        }

        private void btnAddVaccine_Click(object sender, EventArgs e)
        {

            using (SqlConnection con =
        new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Vaccinations
              (PetID, VaccineType, DateGiven, NextDueDate)
              VALUES (@pid, @type, @given, @due)", con);

                cmd.Parameters.AddWithValue("@pid", cmbPets.SelectedValue);
                cmd.Parameters.AddWithValue("@type", txtVaccineType.Text);
                cmd.Parameters.AddWithValue("@given", dtpDateGiven.Value);
                cmd.Parameters.AddWithValue("@due", dtpNextDueDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadVaccinations();
            MessageBox.Show("Vaccination added successfully.");
        }

        private void btnDeleteVaccination_Click(object sender, EventArgs e)
        {
            if (dgvVaccinations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a vaccination to delete.");
                return;
            }

            int vid = Convert.ToInt32(
                dgvVaccinations.SelectedRows[0].Cells["VaccinationID"].Value);

            if (MessageBox.Show("Delete this vaccination?",
                "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Vaccinations WHERE VaccinationID=@id", con);

                cmd.Parameters.AddWithValue("@id", vid);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadVaccinations();
        }
    }
}

