using ClassLibrary;

namespace MunicipalityApp
{
    public partial class ViewReportsForm : Form
    {
        public Repository<Issue> issues = new Repository<Issue>();

        public ViewReportsForm()
        {
            InitializeComponent();

            // Configure the ListBox
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.DrawItem += listBox1_DrawItem;
            listBox1.MeasureItem += listBox1_MeasureItem;

            listBox1.HorizontalScrollbar = false;
            listBox1.IntegralHeight = false;

            // A little padding around the reports
            listBox1.BackColor = Color.FromArgb(245, 247, 250);
            listBox1.BorderStyle = BorderStyle.None;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            // Clear existing items so they don't appear twice
            listBox1.Items.Clear();

            List<Issue> issueItems = issues.GetAll();

            if (issueItems.Count == 0)
            {
                MessageBox.Show(
                    "There are currently no issue reports.",
                    "No Reports",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            foreach (Issue issue in issueItems)
            {
                listBox1.Items.Add(issue);
            }

            // Refresh the ListBox
            listBox1.Refresh();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Give every report enough space for multiple lines
            e.ItemHeight = 125;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            Issue issue = (Issue)listBox1.Items[e.Index];

            // Determine whether the item is selected
            bool selected = (e.State & DrawItemState.Selected)
                            == DrawItemState.Selected;

            // Colours
            Color backgroundColor = selected
                ? Color.FromArgb(52, 152, 219)
                : Color.White;

            Color textColor = selected
                ? Color.White
                : Color.FromArgb(45, 45, 45);

            Color secondaryColor = selected
                ? Color.FromArgb(230, 240, 250)
                : Color.FromArgb(100, 100, 100);

            // Draw background
            e.Graphics.FillRectangle(
                new SolidBrush(backgroundColor),
                e.Bounds);

            // Card border
            using (Pen borderPen = new Pen(
                selected
                    ? Color.FromArgb(41, 128, 185)
                    : Color.FromArgb(220, 220, 220)))
            {
                e.Graphics.DrawRectangle(
                    borderPen,
                    e.Bounds.X + 5,
                    e.Bounds.Y + 5,
                    e.Bounds.Width - 11,
                    e.Bounds.Height - 11);
            }

            // Fonts
            using Font titleFont = new Font(
                "Segoe UI",
                11,
                FontStyle.Bold);

            using Font normalFont = new Font(
                "Segoe UI",
                9);

            using Font smallFont = new Font(
                "Segoe UI",
                8);

            // Category
            string category = string.IsNullOrWhiteSpace(issue.Category)
                ? "Uncategorised"
                : issue.Category;

            // Location
            string location = string.IsNullOrWhiteSpace(issue.Location)
                ? "No location provided"
                : issue.Location;

            // Description
            string description = string.IsNullOrWhiteSpace(issue.Description)
                ? "No description provided"
                : issue.Description;

            // File
            string file = string.IsNullOrWhiteSpace(issue.FilePath)
                ? "No attachment"
                : Path.GetFileName(issue.FilePath);

            // Positioning
            int left = e.Bounds.X + 18;
            int top = e.Bounds.Y + 13;

            // Draw category/title
            using (Brush titleBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    $"{category} Issue",
                    titleFont,
                    titleBrush,
                    left,
                    top);
            }

            // Draw location
            using (Brush secondaryBrush = new SolidBrush(secondaryColor))
            {
                e.Graphics.DrawString(
                    $"{location}",
                    normalFont,
                    secondaryBrush,
                    left,
                    top + 28);
            }

            // Draw description
            using (Brush descriptionBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    $"Description: {description}",
                    normalFont,
                    descriptionBrush,
                    new RectangleF(
                        left,
                        top + 50,
                        e.Bounds.Width - 40,
                        35));
            }

            // Draw attachment
            using (Brush fileBrush = new SolidBrush(secondaryColor))
            {
                e.Graphics.DrawString(
                    $"{file}",
                    smallFont,
                    fileBrush,
                    left,
                    top + 88);
            }

            // Draw focus rectangle
            e.DrawFocusRectangle();
        }
    }
}
