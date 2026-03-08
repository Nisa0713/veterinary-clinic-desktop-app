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
    public partial class DashboardForm : Form
    {

        void LoadTodayAppointments()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT p.PetName,
                     o.FullName AS Owner,
                     v.FullName AS Vet,
                     a.AppointmentDate
              FROM Appointments a
              JOIN Pets p ON a.PetID = p.PetID
              JOIN Owners o ON p.OwnerID = o.OwnerID
              JOIN Veterinarians v ON a.VetID = v.VetID
              WHERE CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTodayAppointments.DataSource = dt;
            }
        }
        public DashboardForm()
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
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadTodayAppointments();
            StyleGrid(dgvTodayAppointments);
        }
    }
}
