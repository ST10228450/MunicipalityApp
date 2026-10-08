using ClassLibrary;

namespace MunicipalityApp
{
    public partial class ViewAnnouncementsWindow : Form
    {
        // Organises announcements by date.
        private readonly SortedDictionary<DateTime, List<Announcement>>
        announcementsByDate = new SortedDictionary<DateTime, List<Announcement>>();


    // Provides fast retrieval by announcement ID.
    private readonly Dictionary<string, Announcement>
        announcementsById = new Dictionary<string, Announcement>(
            StringComparer.OrdinalIgnoreCase);

        // Stores unique categories.
        private readonly HashSet<string> categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Stores recently viewed announcements.
        private readonly Stack<Announcement> recentlyViewed =
            new Stack<Announcement>();

        // Stores announcements waiting to be processed.
        private readonly Queue<Announcement> announcementQueue =
            new Queue<Announcement>();

        // Prioritises announcements by earliest date.
        private readonly PriorityQueue<Announcement, DateTime>
            announcementPriorityQueue =
                new PriorityQueue<Announcement, DateTime>();

        // Counts the user's searches by category.
        private readonly Dictionary<string, int> searchPreferences =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // Retains the currently displayed search results.
        private List<Announcement> currentResults =
            new List<Announcement>();

        public ViewAnnouncementsWindow()
        {
            InitializeComponent();

            LoadSampleAnnouncements();
            PopulateCategories();
            DisplayAnnouncements(GetAllAnnouncements());
            UpdateRecommendations();
        }

        // ----------------------------------------------------
        // 1. SAMPLE DATA
        // ----------------------------------------------------

        private void LoadSampleAnnouncements()
        {
            DateTime today = DateTime.Today;

            var sampleAnnouncements = new List<Announcement>
        {
            new Announcement
            {
                AnnouncementId = "ANN001",
                Title = "Community Meeting",
                Content = "Residents are invited to discuss local development and community needs.",
                Category = "Community Meetings",
                AnnouncementDate = today.AddDays(2)
            },

            new Announcement
            {
                AnnouncementId = "ANN002",
                Title = "Road Maintenance",
                Content = "Temporary road closures will occur while maintenance work is completed.",
                Category = "Road Closures",
                AnnouncementDate = today.AddDays(3)
            },

            new Announcement
            {
                AnnouncementId = "ANN003",
                Title = "Water Supply Interruption",
                Content = "Water supply may be interrupted while municipal repairs are underway.",
                Category = "Service Interruptions",
                AnnouncementDate = today.AddDays(1)
            },

            new Announcement
            {
                AnnouncementId = "ANN004",
                Title = "Community Clean-Up",
                Content = "Join volunteers to clean public spaces and improve the neighbourhood.",
                Category = "Community Events",
                AnnouncementDate = today.AddDays(5)
            },

            new Announcement
            {
                AnnouncementId = "ANN005",
                Title = "Public Health Awareness",
                Content = "Attend a community awareness session about public health and safety.",
                Category = "Awareness Campaigns",
                AnnouncementDate = today.AddDays(7)
            },

            new Announcement
            {
                AnnouncementId = "ANN006",
                Title = "Electricity Maintenance",
                Content = "Scheduled electricity maintenance may affect selected areas.",
                Category = "Service Interruptions",
                AnnouncementDate = today.AddDays(4)
            },

            new Announcement
            {
                AnnouncementId = "ANN007",
                Title = "Youth Sports Day",
                Content = "Young residents are invited to participate in community sports activities.",
                Category = "Sports and Recreation",
                AnnouncementDate = today.AddDays(9)
            },

            new Announcement
            {
                AnnouncementId = "ANN008",
                Title = "Municipal Budget Consultation",
                Content = "Residents can provide feedback on municipal spending priorities.",
                Category = "Public Consultations",
                AnnouncementDate = today.AddDays(6)
            },

            new Announcement
            {
                AnnouncementId = "ANN009",
                Title = "Recycling Collection",
                Content = "A special recycling collection will take place at designated community points.",
                Category = "Waste Collection",
                AnnouncementDate = today.AddDays(8)
            },

            new Announcement
            {
                AnnouncementId = "ANN010",
                Title = "Local Market Day",
                Content = "Visit local traders and small businesses at the community market.",
                Category = "Community Events",
                AnnouncementDate = today.AddDays(10)
            },

            new Announcement
            {
                AnnouncementId = "ANN011",
                Title = "Municipal Service Update",
                Content = "Important updates on municipal services and public facilities.",
                Category = "Service Announcements",
                AnnouncementDate = today.AddDays(11)
            },

            new Announcement
            {
                AnnouncementId = "ANN012",
                Title = "Community Safety Workshop",
                Content = "Learn about neighbourhood safety and emergency preparedness.",
                Category = "Safety and Security",
                AnnouncementDate = today.AddDays(12)
            }
        };

            foreach (Announcement announcement in sampleAnnouncements)
            {
                AddAnnouncement(announcement);
            }
        }

        // ----------------------------------------------------
        // 2. ADD ANNOUNCEMENTS TO DATA STRUCTURES
        // ----------------------------------------------------

        private void AddAnnouncement(Announcement announcement)
        {
            if (announcement == null ||
                string.IsNullOrWhiteSpace(announcement.AnnouncementId))
            {
                return;
            }

            // Prevent duplicate IDs.
            if (announcementsById.ContainsKey(announcement.AnnouncementId))
            {
                return;
            }

            // Fast ID lookup.
            announcementsById.Add(
                announcement.AnnouncementId, announcement);

            // Add to the sorted dictionary.
            DateTime dateKey = announcement.AnnouncementDate.Date;

            if (!announcementsByDate.ContainsKey(dateKey))
            {
                announcementsByDate[dateKey] =
                    new List<Announcement>();
            }

            announcementsByDate[dateKey].Add(announcement);

            // Track unique categories.
            categories.Add(announcement.Category);

            // Queue for sequential processing.
            announcementQueue.Enqueue(announcement);

            // Priority queue: earliest date has highest priority.
            announcementPriorityQueue.Enqueue(
                announcement, announcement.AnnouncementDate);
        }

        private List<Announcement> GetAllAnnouncements()
        {
            return announcementsByDate
                .SelectMany(group => group.Value)
                .OrderBy(a => a.AnnouncementDate)
                .ToList();
        }

        // ----------------------------------------------------
        // 3. POPULATE CATEGORY FILTER
        // ----------------------------------------------------

        private void PopulateCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in categories.OrderBy(c => c))
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }

        // ----------------------------------------------------
        // 4. SEARCH AND FILTER
        // ----------------------------------------------------

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAnnouncements();
        }
        private void btnCreateAnnouncement_Click(object sender, EventArgs e)
        {
            using (CreateAnnouncementWindow createForm =
                   new CreateAnnouncementWindow())
            {
                // Open the create announcement form.
                DialogResult result = createForm.ShowDialog(this);

                // Continue only when the user saves successfully.
                if (result == DialogResult.OK &&
                    createForm.CreatedAnnouncement != null)
                {
                    Announcement created =
                        createForm.CreatedAnnouncement;

                    // Add the announcement to all relevant data structures.
                    AddAnnouncement(created);

                    // Update the category filter with any new category.
                    PopulateCategories();

                    // Refresh the announcements table.
                    DisplayAnnouncements(GetAllAnnouncements());

                    // Refresh the recommendations.
                    UpdateRecommendations();

                    MessageBox.Show(
                        "The announcement has been created and added " +
                        "to the events list successfully.",
                        "Announcement Created",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchAnnouncements();
            }
        }

        private void SearchAnnouncements()
        {
            string searchText = txtSearch.Text.Trim();

            string selectedCategory =
                cmbCategory.SelectedItem?.ToString() ?? "All Categories";

            DateTime? fromDate = dtpFromDate.Checked
                ? dtpFromDate.Value.Date
                : (DateTime?)null;

            DateTime? toDate = dtpToDate.Checked
                ? dtpToDate.Value.Date
                : (DateTime?)null;

            if (fromDate.HasValue &&
                toDate.HasValue &&
                fromDate.Value > toDate.Value)
            {
                MessageBox.Show(
                    "The From date cannot be later than the To date.",
                    "Invalid date range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Record the category preference when a search is performed.
            if (selectedCategory != "All Categories")
            {
                if (!searchPreferences.ContainsKey(selectedCategory))
                {
                    searchPreferences[selectedCategory] = 0;
                }

                searchPreferences[selectedCategory]++;
            }

            IEnumerable<Announcement> results = GetAllAnnouncements();

            // Search title, description, ID and category.
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                results = results.Where(a =>
                    ContainsText(a.Title, searchText) ||
                    ContainsText(a.Content, searchText) ||
                    ContainsText(a.AnnouncementId, searchText) ||
                    ContainsText(a.Category, searchText));
            }

            // Filter by category.
            if (selectedCategory != "All Categories")
            {
                results = results.Where(a =>
                    string.Equals(
                        a.Category,
                        selectedCategory,
                        StringComparison.OrdinalIgnoreCase));
            }

            // Filter by date.
            if (fromDate.HasValue)
            {
                results = results.Where(a =>
                    a.AnnouncementDate.Date >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                results = results.Where(a =>
                    a.AnnouncementDate.Date <= toDate.Value);
            }

            DisplayAnnouncements(results.ToList());
            UpdateRecommendations();
        }

        private bool ContainsText(string source, string searchText)
        {
            return !string.IsNullOrEmpty(source) &&
                   source.IndexOf(
                       searchText,
                       StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }

            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;

            DisplayAnnouncements(GetAllAnnouncements());
            UpdateRecommendations();
        }

        // ----------------------------------------------------
        // 5. DISPLAY ANNOUNCEMENTS
        // ----------------------------------------------------

        private void DisplayAnnouncements(
            List<Announcement> announcements)
        {
            currentResults = announcements
                .OrderBy(a => a.AnnouncementDate)
                .ToList();

            dgvAnnouncements.DataSource = null;
            dgvAnnouncements.DataSource = currentResults;

            lblResults.Text =
                $"Upcoming events and announcements ({currentResults.Count})";

            // Disable the ID column if you want a cleaner interface.
            if (dgvAnnouncements.Columns["AnnouncementId"] != null)
            {
                dgvAnnouncements.Columns["AnnouncementId"]
                    .Visible = true;
            }
        }

        // ----------------------------------------------------
        // 6. VIEW ANNOUNCEMENT DETAILS
        // ----------------------------------------------------

        private void dgvAnnouncements_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dgvAnnouncements.Rows.Count)
            {
                return;
            }

            Announcement announcement =
                dgvAnnouncements.Rows[e.RowIndex].DataBoundItem
                as Announcement;

            if (announcement != null)
            {
                ShowAnnouncementDetails(announcement);
            }
        }

        private void ShowAnnouncementDetails(
            Announcement announcement)
        {
            // Keep a record of recent views.
            recentlyViewed.Push(announcement);

            string details =
                $"Title: {announcement.Title}\n\n" +
                $"Category: {announcement.Category}\n" +
                $"Date: {announcement.AnnouncementDate:dd MMMM yyyy}\n" +
                $"Reference: {announcement.AnnouncementId}\n\n" +
                $"Description:\n{announcement.Content}";

            MessageBox.Show(
                details,
                "Announcement Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ----------------------------------------------------
        // 7. RECOMMENDATION ENGINE
        // ----------------------------------------------------

        private void UpdateRecommendations()
        {
            lstRecommendations.Items.Clear();

            // Recommend events from the most frequently searched
            // category first.
            List<string> preferredCategories = searchPreferences
                .OrderByDescending(pair => pair.Value)
                .Select(pair => pair.Key)
                .ToList();

            IEnumerable<Announcement> recommendations;

            if (preferredCategories.Count > 0)
            {
                recommendations = GetAllAnnouncements()
                    .Where(a =>
                        preferredCategories.Contains(
                            a.Category,
                            StringComparer.OrdinalIgnoreCase))
                    .Where(a => a.AnnouncementDate.Date >= DateTime.Today)
                    .OrderBy(a =>
                        preferredCategories.IndexOf(a.Category))
                    .ThenBy(a => a.AnnouncementDate);
            }
            else
            {
                // Before the user searches, recommend the next
                // upcoming events.
                recommendations = GetAllAnnouncements()
                    .Where(a =>
                        a.AnnouncementDate.Date >= DateTime.Today)
                    .OrderBy(a => a.AnnouncementDate);
            }

            foreach (Announcement announcement in
                     recommendations.Take(5))
            {
                lstRecommendations.Items.Add(announcement);
            }

            lstRecommendations.DisplayMember = "Title";

            if (lstRecommendations.Items.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "No recommendations available.");
            }
        }

        private void lstRecommendations_DoubleClick(
            object sender, EventArgs e)
        {
            if (lstRecommendations.SelectedItem is Announcement announcement)
            {
                ShowAnnouncementDetails(announcement);
            }
        }

        // ----------------------------------------------------
        // 8. STACK: RECENTLY VIEWED
        // ----------------------------------------------------

        private void btnViewRecent_Click(object sender, EventArgs e)
        {
            if (recentlyViewed.Count == 0)
            {
                MessageBox.Show(
                    "You have not viewed any announcements yet.",
                    "Recently Viewed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Peek shows the most recently viewed announcement
            // without removing it from the stack.
            Announcement latest = recentlyViewed.Peek();

            ShowAnnouncementDetails(latest);
        }

        // ----------------------------------------------------
        // 9. QUEUE: PROCESS NEXT ANNOUNCEMENT
        // ----------------------------------------------------

        private void btnProcessQueue_Click(object sender, EventArgs e)
        {
            if (announcementQueue.Count == 0)
            {
                MessageBox.Show(
                    "There are no announcements left in the queue.",
                    "Announcement Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            Announcement next = announcementQueue.Dequeue();

            MessageBox.Show(
                $"Next announcement in the queue:\n\n" +
                $"{next.Title}\n" +
                $"Category: {next.Category}\n" +
                $"Date: {next.AnnouncementDate:dd MMM yyyy}\n\n" +
                $"{next.Content}",
                "Next Announcement",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ----------------------------------------------------
        // 10. PRIORITY QUEUE EXAMPLE
        // ----------------------------------------------------

        private void ShowNextPriorityAnnouncement()
        {
            if (announcementPriorityQueue.Count == 0)
            {
                MessageBox.Show(
                    "No announcements are available.",
                    "Priority Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            Announcement next =
                announcementPriorityQueue.Dequeue();

            MessageBox.Show(
                $"Next announcement by date:\n\n" +
                $"{next.Title}\n" +
                $"{next.AnnouncementDate:dd MMM yyyy}",
                "Priority Announcement",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ----------------------------------------------------
        // 11. BACK TO MAIN MENU
        // ----------------------------------------------------

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }


}
