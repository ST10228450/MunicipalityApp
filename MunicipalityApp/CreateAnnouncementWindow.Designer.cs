namespace MunicipalityApp
{
    partial class CreateAnnouncementWindow
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTitle;
        private TextBox txtContent;
        private ComboBox cbCategory;
        private DateTimePicker datePicker;
        private Button btnSave;
        private Button btnCancel;
        private Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTitle = new TextBox();
            txtContent = new TextBox();
            cbCategory = new ComboBox();
            datePicker = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            lblFooter = new Label();

            SuspendLayout();

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 247, 255);
            ClientSize = new Size(850, 620);
            MinimumSize = new Size(850, 620);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Create Announcement";
            Font = new Font("Segoe UI", 10F);

            // Header panel
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 105;
            headerPanel.BackColor = Color.FromArgb(80, 160, 225);

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 22);
            label1.Text = "Post New Announcement";

            headerPanel.Controls.Add(label1);

            // Title label
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(38, 79, 115);
            label2.Location = new Point(90, 140);
            label2.Text = "Title";

            // Title textbox
            txtTitle.Location = new Point(220, 135);
            txtTitle.Size = new Size(520, 30);
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.MaxLength = 150;
            txtTitle.PlaceholderText = "Enter announcement title";

            // Content label
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(38, 79, 115);
            label3.Location = new Point(90, 190);
            label3.Text = "Description";

            // Content textbox
            txtContent.Location = new Point(220, 185);
            txtContent.Size = new Size(520, 110);
            txtContent.Font = new Font("Segoe UI", 10F);
            txtContent.Multiline = true;
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.MaxLength = 2000;
            txtContent.PlaceholderText =
                "Provide details about the event or announcement";

            // Category label
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(38, 79, 115);
            label4.Location = new Point(90, 320);
            label4.Text = "Category";

            // Category dropdown
            cbCategory.Location = new Point(220, 315);
            cbCategory.Size = new Size(520, 32);
            cbCategory.Font = new Font("Segoe UI", 10F);
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            cbCategory.Items.AddRange(new object[]
            {
            "Community Meetings",
            "Community Events",
            "Road Closures",
            "Service Interruptions",
            "Service Announcements",
            "Public Consultations",
            "Awareness Campaigns",
            "Waste Collection",
            "Sports and Recreation",
            "Safety and Security"
            });

            // Date label
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(38, 79, 115);
            label5.Location = new Point(90, 375);
            label5.Text = "Event Date";

            // Date picker
            datePicker.Location = new Point(220, 370);
            datePicker.Size = new Size(520, 32);
            datePicker.Font = new Font("Segoe UI", 10F);
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "dddd, dd MMMM yyyy";
            datePicker.MinDate = DateTime.Today;
            datePicker.Value = DateTime.Today;

            // Save button
            btnSave.Location = new Point(220, 440);
            btnSave.Size = new Size(245, 48);
            btnSave.Text = "Post Announcement";
            btnSave.BackColor = Color.FromArgb(80, 160, 225);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += btnSave_Click;

            // Cancel button
            btnCancel.Location = new Point(480, 440);
            btnCancel.Size = new Size(260, 48);
            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.FromArgb(220, 235, 248);
            btnCancel.ForeColor = Color.FromArgb(38, 79, 115);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor =
                Color.FromArgb(160, 200, 230);
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            // Footer
            lblFooter.AutoSize = true;
            lblFooter.Text = "Municipal Services | Community Information";
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = Color.FromArgb(90, 120, 145);
            lblFooter.Location = new Point(260, 540);

            // Add controls
            Controls.Add(headerPanel);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(txtContent);
            Controls.Add(label4);
            Controls.Add(cbCategory);
            Controls.Add(label5);
            Controls.Add(datePicker);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblFooter);

            AcceptButton = btnSave;
            CancelButton = btnCancel;

            ResumeLayout(false);
            PerformLayout();
        }
    }


}
