namespace VetClinicApp
{
    partial class VaccinationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaccinationForm));
            this.cmbPets = new System.Windows.Forms.ComboBox();
            this.txtVaccineType = new System.Windows.Forms.TextBox();
            this.dtpNextDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddVaccination = new System.Windows.Forms.Button();
            this.dgvVaccinations = new System.Windows.Forms.DataGridView();
            this.lblPetName = new System.Windows.Forms.Label();
            this.lblVaccineName = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblDateGiven = new System.Windows.Forms.Label();
            this.dtpDateGiven = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteVaccination = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPets
            // 
            this.cmbPets.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPets.FormattingEnabled = true;
            this.cmbPets.Location = new System.Drawing.Point(42, 108);
            this.cmbPets.Name = "cmbPets";
            this.cmbPets.Size = new System.Drawing.Size(200, 28);
            this.cmbPets.TabIndex = 0;
            // 
            // txtVaccineType
            // 
            this.txtVaccineType.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVaccineType.Location = new System.Drawing.Point(42, 172);
            this.txtVaccineType.Name = "txtVaccineType";
            this.txtVaccineType.Size = new System.Drawing.Size(199, 27);
            this.txtVaccineType.TabIndex = 1;
            // 
            // dtpNextDueDate
            // 
            this.dtpNextDueDate.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNextDueDate.Location = new System.Drawing.Point(41, 290);
            this.dtpNextDueDate.Name = "dtpNextDueDate";
            this.dtpNextDueDate.Size = new System.Drawing.Size(200, 23);
            this.dtpNextDueDate.TabIndex = 2;
            // 
            // btnAddVaccination
            // 
            this.btnAddVaccination.BackColor = System.Drawing.Color.Pink;
            this.btnAddVaccination.FlatAppearance.BorderColor = System.Drawing.Color.Beige;
            this.btnAddVaccination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVaccination.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVaccination.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVaccination.Image")));
            this.btnAddVaccination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVaccination.Location = new System.Drawing.Point(43, 340);
            this.btnAddVaccination.Name = "btnAddVaccination";
            this.btnAddVaccination.Size = new System.Drawing.Size(173, 34);
            this.btnAddVaccination.TabIndex = 3;
            this.btnAddVaccination.Text = "   Add Vaccine";
            this.btnAddVaccination.UseVisualStyleBackColor = false;
            this.btnAddVaccination.Click += new System.EventHandler(this.btnAddVaccine_Click);
            // 
            // dgvVaccinations
            // 
            this.dgvVaccinations.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvVaccinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinations.GridColor = System.Drawing.Color.Pink;
            this.dgvVaccinations.Location = new System.Drawing.Point(311, 82);
            this.dgvVaccinations.Name = "dgvVaccinations";
            this.dgvVaccinations.Size = new System.Drawing.Size(457, 332);
            this.dgvVaccinations.TabIndex = 4;
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.BackColor = System.Drawing.Color.Transparent;
            this.lblPetName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetName.Location = new System.Drawing.Point(39, 83);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(90, 19);
            this.lblPetName.TabIndex = 5;
            this.lblPetName.Text = "Pet Name:";
            // 
            // lblVaccineName
            // 
            this.lblVaccineName.AutoSize = true;
            this.lblVaccineName.BackColor = System.Drawing.Color.Transparent;
            this.lblVaccineName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaccineName.Location = new System.Drawing.Point(38, 150);
            this.lblVaccineName.Name = "lblVaccineName";
            this.lblVaccineName.Size = new System.Drawing.Size(126, 19);
            this.lblVaccineName.TabIndex = 6;
            this.lblVaccineName.Text = "Vaccine Name:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(38, 268);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(135, 19);
            this.lblDueDate.TabIndex = 7;
            this.lblDueDate.Text = "Next Due Date:";
            // 
            // lblDateGiven
            // 
            this.lblDateGiven.AutoSize = true;
            this.lblDateGiven.BackColor = System.Drawing.Color.Transparent;
            this.lblDateGiven.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateGiven.Location = new System.Drawing.Point(38, 208);
            this.lblDateGiven.Name = "lblDateGiven";
            this.lblDateGiven.Size = new System.Drawing.Size(108, 19);
            this.lblDateGiven.TabIndex = 9;
            this.lblDateGiven.Text = "Date Given:";
            // 
            // dtpDateGiven
            // 
            this.dtpDateGiven.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateGiven.Location = new System.Drawing.Point(41, 230);
            this.dtpDateGiven.Name = "dtpDateGiven";
            this.dtpDateGiven.Size = new System.Drawing.Size(200, 23);
            this.dtpDateGiven.TabIndex = 8;
            // 
            // btnDeleteVaccination
            // 
            this.btnDeleteVaccination.BackColor = System.Drawing.Color.Pink;
            this.btnDeleteVaccination.FlatAppearance.BorderColor = System.Drawing.Color.Beige;
            this.btnDeleteVaccination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteVaccination.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVaccination.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteVaccination.Image")));
            this.btnDeleteVaccination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteVaccination.Location = new System.Drawing.Point(43, 380);
            this.btnDeleteVaccination.Name = "btnDeleteVaccination";
            this.btnDeleteVaccination.Size = new System.Drawing.Size(173, 34);
            this.btnDeleteVaccination.TabIndex = 10;
            this.btnDeleteVaccination.Text = "   Delete Vaccine";
            this.btnDeleteVaccination.UseVisualStyleBackColor = false;
            this.btnDeleteVaccination.Click += new System.EventHandler(this.btnDeleteVaccination_Click);
            // 
            // VaccinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteVaccination);
            this.Controls.Add(this.lblDateGiven);
            this.Controls.Add(this.dtpDateGiven);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblVaccineName);
            this.Controls.Add(this.lblPetName);
            this.Controls.Add(this.dgvVaccinations);
            this.Controls.Add(this.btnAddVaccination);
            this.Controls.Add(this.dtpNextDueDate);
            this.Controls.Add(this.txtVaccineType);
            this.Controls.Add(this.cmbPets);
            this.Name = "VaccinationForm";
            this.Text = "VaccinationForm";
            this.Load += new System.EventHandler(this.VaccinationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPets;
        private System.Windows.Forms.TextBox txtVaccineType;
        private System.Windows.Forms.DateTimePicker dtpNextDueDate;
        private System.Windows.Forms.Button btnAddVaccination;
        private System.Windows.Forms.DataGridView dgvVaccinations;
        private System.Windows.Forms.Label lblPetName;
        private System.Windows.Forms.Label lblVaccineName;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDateGiven;
        private System.Windows.Forms.DateTimePicker dtpDateGiven;
        private System.Windows.Forms.Button btnDeleteVaccination;
    }
}