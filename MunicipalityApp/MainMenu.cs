using ClassLibrary;

namespace MunicipalityApp
{
    public partial class MainMenu : Form
    {
        public Repository<Issue> Repository = new Repository<Issue>();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            IssueReportingForm form = new IssueReportingForm();
            form.Show();
            Repository = form.Repository;
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            ViewReportsForm viewReportsForm = new ViewReportsForm();
            viewReportsForm.issues = Repository;
            viewReportsForm.Show();
        }

        private void btnViewAnnouncements_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature coming soon");
        }

        private void btnRequestService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature Coming soon");
        }
    }
}
