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
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }

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

        void LoadVets()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT VetID, FullName FROM Veterinarians", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbVets.DataSource = dt;
                cmbVets.DisplayMember = "FullName";
                cmbVets.ValueMember = "VetID";
            }
        }

        void LoadAppointments()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT a.AppointmentID,
                     p.PetName,
                     o.FullName AS Owner,
                     v.FullName AS Vet,
                     a.AppointmentDate
              FROM Appointments a
              JOIN Pets p ON a.PetID = p.PetID
              JOIN Owners o ON p.OwnerID = o.OwnerID
              JOIN Veterinarians v ON a.VetID = v.VetID",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAppointments.DataSource = dt;
            }
        }

        void StyleGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }
        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            LoadPets();
            LoadVets();
            LoadAppointments();
            StyleGrid(dgvAppointments);
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Appointments (PetID, VetID, AppointmentDate)
              VALUES (@p, @v, @d)", con);

                cmd.Parameters.AddWithValue("@p", cmbPets.SelectedValue);
                cmd.Parameters.AddWithValue("@v", cmbVets.SelectedValue);
                cmd.Parameters.AddWithValue("@d", dtpDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadAppointments();
            MessageBox.Show("Appointment added!");
        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an appointment to delete.");
                return;
            }

            int appointmentId = Convert.ToInt32(
                dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);

            if (MessageBox.Show(
                "Delete this appointment?",
                "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(Database.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Appointments WHERE AppointmentID=@id", con);

                    cmd.Parameters.AddWithValue("@id", appointmentId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadAppointments();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Cannot delete appointment because it has an invoice.");
            }
        }
    }
}

