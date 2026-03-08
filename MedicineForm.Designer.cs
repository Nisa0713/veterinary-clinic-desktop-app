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
    public partial class MedicineForm : Form
    {


        void LoadMedicines()
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MedicineID, MedicineName, Stock, Price FROM Medicines", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMedicines.DataSource = dt;
            }
        }
        public MedicineForm()
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
        private void MedicineForm_Load(object sender, EventArgs e)
        {
            
            LoadMedicines();
            StyleGrid(dgvMedicines);
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Medicines (MedicineName, Stock, Price)
              VALUES (@n, @s, @p)", con);

                cmd.Parameters.AddWithValue("@n", txtMedicineName.Text);
                cmd.Parameters.AddWithValue("@s", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@p", decimal.Parse(txtPrice.Text));

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMedicines();
            MessageBox.Show("Medicine added to inventory.");
        }

        private void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a medicine to delete.");
                return;
            }

            int medicineId = Convert.ToInt32(
                dgvMedicines.SelectedRows[0].Cells["MedicineID"].Value);

            if (MessageBox.Show(
                "Delete this medicine?",
                "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Medicines WHERE MedicineID=@id", con);

                cmd.Parameters.AddWithValue("@id", medicineId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMedicines();
        }
    }
}

