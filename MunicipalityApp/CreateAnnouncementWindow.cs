using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;

namespace MunicipalityApp
{
    public partial class CreateAnnouncementWindow : Form
    {
        private readonly List<Announcement> announcements;

    public Announcement CreatedAnnouncement { get; private set; }

        // Use this constructor when the calling form supplies
        // the shared announcement collection.
        public CreateAnnouncementWindow(
            List<Announcement> sharedAnnouncements)
        {
            InitializeComponent();

            announcements = sharedAnnouncements ??
                throw new ArgumentNullException(
                    nameof(sharedAnnouncements));

            cbCategory.SelectedIndex = 0;
        }

        // Optional parameterless constructor for designer support
        // or standalone testing.
        public CreateAnnouncementWindow()
            : this(new List<Announcement>())
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = txtContent.Text.Trim();

            // Validate title.
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show(
                    "Please enter an announcement title.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return;
            }

            // Validate content.
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show(
                    "Please enter the announcement description.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContent.Focus();
                return;
            }

            // Validate category.
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select an announcement category.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbCategory.Focus();
                return;
            }

            // Validate date.
            if (datePicker.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Please select today or a future date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                datePicker.Focus();
                return;
            }

            // Create announcement.
            Announcement announcement = new Announcement
            {
                AnnouncementId = Guid.NewGuid().ToString(),
                Title = title,
                Content = content,
                Category = cbCategory.SelectedItem.ToString(),
                AnnouncementDate = datePicker.Value.Date
            };

            // Save to the shared in-memory collection.
            announcements.Add(announcement);

            CreatedAnnouncement = announcement;

            MessageBox.Show(
                "Announcement posted successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }


}
