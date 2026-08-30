using ClassLibrary;

namespace MunicipalityApp
{
    public partial class IssueReportingForm : Form
    {
        public Repository<Issue> Repository = new Repository<Issue>();
        public string filePath = "";

        public IssueReportingForm()
        {
            InitializeComponent();

            // Configure Progress Bars
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;

            // Attach events for dynamic progress updates
            txtLocation.TextChanged += FormFieldChanged;
            txtDescription.TextChanged += FormFieldChanged;
            categoryDropDown.TextChanged += FormFieldChanged;
            categoryDropDown.SelectedIndexChanged += FormFieldChanged;

            // Set initial progress
            UpdateProgress();
        }

        // This method calculates the progress based on completed fields
        private void UpdateProgress()
        {
            int progress = 0;

            // Location = 25%
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
                lblLocation.Text = txtLocation.Text;

            }

            // Description = 25%
            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                progress += 25;
                lblDescription.Text = txtDescription.Text;
            }

            // Category = 25%
            if (!string.IsNullOrWhiteSpace(categoryDropDown.Text))
            {
                progress += 25;
                lblCategory.Text = categoryDropDown.Text;
            }

            // File = 25%
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                progress += 25;
                lblFileName.Text = labelFileName.Text;
            }

            // Make sure the value stays between 0 and 100
            progress = Math.Max(progress, 0);
            progress = Math.Min(progress, 100);

            // Update both progress bars
            progressBar1.Value = progress;
            progressBar2.Value = progress;

            // Optional: display the percentage in the form title
            // this.Text = $"Report an Issue - {progress}% Complete";
        }

        // Called whenever a text field or category changes
        private void FormFieldChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        // Choose/upload a file
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "All Supported Files|*.jpg;*.jpeg;*.png;*.doc;*.docx;*.txt";

                openFile.Title = "Select a File";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Store the selected file path
                    filePath = openFile.FileName;

                    // Display only the file name instead of the entire path
                    labelFileName.Text = Path.GetFileName(filePath);

                    // Get the file extension
                    string extension = Path.GetExtension(filePath).ToLower();

                    // Supported image extensions
                    string[] imageExtensions =
                    {
                        ".jpg",
                        ".jpeg",
                        ".png"
                    };

                    // Display image if the selected file is an image
                    if (imageExtensions.Contains(extension))
                    {
                        // Dispose the previous image first
                        if (imageFileUpload.Image != null)
                        {
                            imageFileUpload.Image.Dispose();
                            imageFileUpload.Image = null;
                        }

                        imageFileUpload.Image = Image.FromFile(filePath);
                        imageFileUpload.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        // Non-image file
                        if (imageFileUpload.Image != null)
                        {
                            imageFileUpload.Image.Dispose();
                            imageFileUpload.Image = null;
                        }
                    }

                    // File is now completed, so update progress
                    UpdateProgress();
                }
            }
        }

        // Optional remove-file button
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            // Clear file path
            filePath = "";

            // Clear file name
            labelFileName.Text = "";

            // Remove image
            if (imageFileUpload.Image != null)
            {
                imageFileUpload.Image.Dispose();
                imageFileUpload.Image = null;
            }

            // Decrease progress by 25%
            UpdateProgress();
        }

        // Save the issue
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check whether all fields are completed
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(categoryDropDown.Text) ||
                string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show(
                    "Please complete all fields and upload a file before saving.",
                    "Incomplete Form",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Collect data from the form
            string location = txtLocation.Text.Trim();
            string description = txtDescription.Text.Trim();
            string category = categoryDropDown.Text.Trim();

            // Create new Issue
            Issue issue = new Issue
            {
                Id = Guid.NewGuid().ToString(),
                Location = location,
                Description = description,
                Category = category,
                FilePath = filePath
            };


            // Add issue to repository
            Repository.Add(issue);


            UpdateProgress();

            MessageBox.Show(
                "Issue has been successfully logged 🎉.",
                "Issue Report Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            txtLocation.Text = string.Empty;
            txtDescription.Text = string.Empty;
            categoryDropDown.Text = "";
            labelFileName.Text = "No File Selected.";
            imageFileUpload.Image.Dispose();

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
