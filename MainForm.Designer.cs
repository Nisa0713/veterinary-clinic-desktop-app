using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetClinicApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void LoadFormInPanel(Form form)
        {
            panelContainer.Controls.Clear();   // remove old
            form.TopLevel = false;             // not a separate window
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            panelContainer.Tag = form;
            form.Show();
        }

        private void btnOwners_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new OwnerForm());
        }

        private void btnPets_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new PetForm());
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new AppointmentForm());
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new InvoiceForm());
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new MedicineForm());
        }

        private void btnVaccinations_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new VaccinationForm());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new DashboardForm());
        }
    }
}
