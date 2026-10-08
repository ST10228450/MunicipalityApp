using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace MunicipalityApp
{
    partial class ViewAnnouncementsWindow
    {
        private System.ComponentModel.IContainer components = null;

    private Panel headerPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel filterPanel;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnSearch;
        private Button btnClear;
        private DataGridView dgvAnnouncements;
        private GroupBox grpRecommendations;
        private ListBox lstRecommendations;
        private Label lblResults;
        private Button btnViewRecent;
        private Button btnProcessQueue;
        private Button btnBack;
        private Label lblFooter;
        private Button btnCreateAnnouncement;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            btnCreateAnnouncement = new Button();

            filterPanel = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnSearch = new Button();
            btnClear = new Button();

            dgvAnnouncements = new DataGridView();
            grpRecommendations = new GroupBox();
            lstRecommendations = new ListBox();
            lblResults = new Label();

            btnViewRecent = new Button();
            btnProcessQueue = new Button();
            btnBack = new Button();
            lblFooter = new Label();

            SuspendLayout();

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 760);
            MinimumSize = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local Events and Announcements";
            BackColor = Color.FromArgb(239, 247, 255);
            Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // Header
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 105;
            headerPanel.BackColor = Color.FromArgb(80, 160, 225);
            headerPanel.Padding = new Padding(25);

            lblTitle.Text = "LOCAL EVENTS & ANNOUNCEMENTS";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(25, 15);

            lblSubtitle.Text =
                "Stay informed about upcoming community activities and municipal notices.";
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(29, 60);

            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);

            // Filter panel
            filterPanel.Location = new Point(20, 125);
            filterPanel.Size = new Size(1110, 135);
            filterPanel.Anchor = AnchorStyles.Top |
                                 AnchorStyles.Left |
                                 AnchorStyles.Right;
            filterPanel.BackColor = Color.White;
            filterPanel.BorderStyle = BorderStyle.FixedSingle;

            ConfigureLabel(lblSearch, "Search", 15, 12);
            txtSearch.Location = new Point(15, 40);
            txtSearch.Size = new Size(235, 30);
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.PlaceholderText = "Enter event or announcement...";

            ConfigureLabel(lblCategory, "Category", 270, 12);
            cmbCategory.Location = new Point(270, 40);
            cmbCategory.Size = new Size(200, 30);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);

            ConfigureLabel(lblFromDate, "From date", 490, 12);
            dtpFromDate.Location = new Point(490, 40);
            dtpFromDate.Size = new Size(170, 30);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.ShowCheckBox = true;
            dtpFromDate.Checked = false;

            ConfigureLabel(lblToDate, "To date", 680, 12);
            dtpToDate.Location = new Point(680, 40);
            dtpToDate.Size = new Size(170, 30);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.ShowCheckBox = true;
            dtpToDate.Checked = false;

            ConfigureButton(btnSearch, "Search", 870, 38, 105, 35);
            ConfigureButton(btnClear, "Clear", 985, 38, 100, 35);

            btnSearch.Click += btnSearch_Click;
            btnClear.Click += btnClear_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;

            filterPanel.Controls.AddRange(new Control[]
            {
            lblSearch, txtSearch,
            lblCategory, cmbCategory,
            lblFromDate, dtpFromDate,
            lblToDate, dtpToDate,
            btnSearch, btnClear
            });

            // Results label
            lblResults.Location = new Point(22, 275);
            lblResults.Size = new Size(700, 25);
            lblResults.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            lblResults.ForeColor = Color.FromArgb(38, 95, 145);
            lblResults.Text = "Upcoming events and announcements";

            // Announcements grid
            dgvAnnouncements.Location = new Point(20, 305);
            dgvAnnouncements.Size = new Size(750, 330);
            dgvAnnouncements.Anchor = AnchorStyles.Top |
                                      AnchorStyles.Bottom |
                                      AnchorStyles.Left;
            dgvAnnouncements.BackgroundColor = Color.White;
            dgvAnnouncements.BorderStyle = BorderStyle.FixedSingle;
            dgvAnnouncements.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnnouncements.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAnnouncements.MultiSelect = false;
            dgvAnnouncements.ReadOnly = true;
            dgvAnnouncements.AllowUserToAddRows = false;
            dgvAnnouncements.AllowUserToDeleteRows = false;
            dgvAnnouncements.RowHeadersVisible = false;
            dgvAnnouncements.AutoGenerateColumns = false;
            dgvAnnouncements.ColumnHeadersHeight = 40;
            dgvAnnouncements.RowTemplate.Height = 36;
            dgvAnnouncements.EnableHeadersVisualStyles = false;

            dgvAnnouncements.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(80, 160, 225);
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvAnnouncements.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(190, 225, 250);
            dgvAnnouncements.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(35, 65, 90);
            dgvAnnouncements.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(244, 250, 255);

            dgvAnnouncements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnnouncementId",
                HeaderText = "ID",
                DataPropertyName = "AnnouncementId",
                FillWeight = 55
            });

            dgvAnnouncements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Title",
                DataPropertyName = "Title",
                FillWeight = 125
            });

            dgvAnnouncements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category",
                FillWeight = 90
            });

            dgvAnnouncements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnnouncementDate",
                HeaderText = "Date",
                DataPropertyName = "AnnouncementDate",
                FillWeight = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd MMM yyyy"
                }
            });

            dgvAnnouncements.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Content",
                HeaderText = "Description",
                DataPropertyName = "Content",
                FillWeight = 150
            });

            dgvAnnouncements.CellDoubleClick +=
                dgvAnnouncements_CellDoubleClick;

            // Recommendations
            grpRecommendations.Text = "Recommended for you";
            grpRecommendations.Location = new Point(790, 305);
            grpRecommendations.Size = new Size(340, 330);
            grpRecommendations.Anchor = AnchorStyles.Top |
                                        AnchorStyles.Bottom |
                                        AnchorStyles.Left |
                                        AnchorStyles.Right;
            grpRecommendations.Font =
                new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            grpRecommendations.ForeColor =
                Color.FromArgb(38, 95, 145);
            grpRecommendations.BackColor = Color.White;

            lstRecommendations.Location = new Point(12, 30);
            lstRecommendations.Size = new Size(314, 285);
            lstRecommendations.Anchor = AnchorStyles.Top |
                                        AnchorStyles.Bottom |
                                        AnchorStyles.Left |
                                        AnchorStyles.Right;
            lstRecommendations.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lstRecommendations.BackColor =
                Color.FromArgb(248, 252, 255);
            lstRecommendations.ForeColor =
                Color.FromArgb(38, 79, 115);
            lstRecommendations.IntegralHeight = false;
            lstRecommendations.DoubleClick +=
                lstRecommendations_DoubleClick;

            grpRecommendations.Controls.Add(lstRecommendations);

            // Bottom action buttons
            ConfigureButton(btnViewRecent, "Recently Viewed", 20, 655, 170, 38);
            ConfigureButton(btnProcessQueue, "Process Next", 200, 655, 145, 38);
            ConfigureButton(btnBack, "Back to Menu", 355, 655, 150, 38);
            ConfigureButton(btnCreateAnnouncement,"Create Announcement",515, 655, 185, 38);

            btnCreateAnnouncement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            btnCreateAnnouncement.Click += btnCreateAnnouncement_Click;

            btnViewRecent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnProcessQueue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            btnViewRecent.Click += btnViewRecent_Click;
            btnProcessQueue.Click += btnProcessQueue_Click;
            btnBack.Click += btnBack_Click;

            lblFooter.Text = "Municipal Services | Community Information";
            lblFooter.AutoSize = true;
            lblFooter.ForeColor = Color.FromArgb(90, 120, 145);
            lblFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFooter.Location = new Point(820, 665);

            Controls.Add(headerPanel);
            Controls.Add(filterPanel);
            Controls.Add(lblResults);
            Controls.Add(dgvAnnouncements);
            Controls.Add(grpRecommendations);
            Controls.Add(btnViewRecent);
            Controls.Add(btnProcessQueue);
            Controls.Add(btnBack);
            Controls.Add(lblFooter);
            Controls.Add(btnCreateAnnouncement);

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureLabel(
            Label label,
            string text,
            int x,
            int y)
        {
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(50, 85, 115);
        }

        private void ConfigureButton(
            Button button,
            string text,
            int x,
            int y,
            int width,
            int height)
        {
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.BackColor = Color.FromArgb(80, 160, 225);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }
    }

}
