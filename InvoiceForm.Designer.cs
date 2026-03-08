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
    public partial class InvoiceForm : Form
    {

        void LoadAppointments()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT a.AppointmentID,
                     p.PetName + ' - ' + 
                     CONVERT(varchar, a.AppointmentDate, 23) AS DisplayText
              FROM Appointments a
              JOIN Pets p ON a.PetID = p.PetID", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbAppointments.DataSource = dt;
                cmbAppointments.DisplayMember = "DisplayText";
                cmbAppointments.ValueMember = "AppointmentID";
            }
        }

        void LoadInvoices()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Invoices", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInvoices.DataSource = dt;
            }
        }
        public InvoiceForm()
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
        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
            LoadInvoices();
            StyleGrid(dgvInvoices);

            cmbPaymentStatus.SelectedIndex = 0;
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Invoices
              (AppointmentID, TotalAmount, PaymentStatus, PaymentDate)
              VALUES (@aid, @amount, @status, @date)", con);

                cmd.Parameters.AddWithValue("@aid",
                    cmbAppointments.SelectedValue);
                cmd.Parameters.AddWithValue("@amount",
                    decimal.Parse(txtTotalAmount.Text));
                cmd.Parameters.AddWithValue("@status",
                    cmbPaymentStatus.Text);
                cmd.Parameters.AddWithValue("@date",
                    dtpPaymentDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadInvoices();
            MessageBox.Show("Invoice created successfully.");
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an invoice to delete.");
                return;
            }

            int appointmentId = Convert.ToInt32(
                dgvInvoices.SelectedRows[0].Cells["AppointmentID"].Value);

            if (MessageBox.Show(
                "Delete this invoice?",
                "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Invoices WHERE AppointmentID=@id", con);

                cmd.Parameters.AddWithValue("@id", appointmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadInvoices();
        }
    }
}

