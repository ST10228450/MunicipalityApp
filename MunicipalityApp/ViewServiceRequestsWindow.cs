using ClassLibrary;
using MunicipalityApp.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalityApp
{
    public partial class ViewServiceRequestsWindow : Form
    {
        private readonly ServiceRequestManager _manager;
        private bool _loading;

        public ViewServiceRequestsWindow() : this(new ServiceRequestManager()) { }

        public ViewServiceRequestsWindow(ServiceRequestManager manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            InitializeComponent();

            // Keep the request details panel visible at different window sizes.
            
            this.Shown += ViewServiceRequestsWindow_Shown;
            this.Resize += ViewServiceRequestsWindow_Resize;
            this.Shown += (s, e) =>
            {
                splitContainer.Panel1MinSize = 400;
                splitContainer.Panel2MinSize = 300;
                AdjustSplitLayout();
            };

            ConfigureGrid();
            LoadFilters();
            RefreshRequests();
            UpdateStatistics();
        }


        private void ViewServiceRequestsWindow_Shown(object? sender, EventArgs e)
        {
            AdjustSplitLayout();
        }

        private void ViewServiceRequestsWindow_Resize(object? sender, EventArgs e)
        {
            AdjustSplitLayout();
        }

        private void AdjustSplitLayout()
        {
            int width = splitContainer.ClientSize.Width;

            int minLeft = splitContainer.Panel1MinSize;
            int minRight = splitContainer.Panel2MinSize;
            int splitter = splitContainer.SplitterWidth;

            int maxDistance = width - minRight - splitter;

            if (width < minLeft + minRight + splitter)
                return;

            int desired = Math.Max(minLeft,
                Math.Min(width - 416, maxDistance));

            splitContainer.SplitterDistance = desired;
        }

        private void ConfigureGrid()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Request ID", DataPropertyName = nameof(ServiceRequest.RequestId), Width = 105 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = nameof(ServiceRequest.Category), Width = 105 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Location", DataPropertyName = nameof(ServiceRequest.Location), Width = 180 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Priority", DataPropertyName = nameof(ServiceRequest.Priority), Width = 80 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = nameof(ServiceRequest.Status), Width = 110 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Submitted", DataPropertyName = nameof(ServiceRequest.SubmittedDate), Width = 115, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd MMM yyyy" } });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", DataPropertyName = nameof(ServiceRequest.Description), AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth = 160 });
        }

        private void LoadFilters()
        {
            _loading = true;
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "All statuses", "Submitted", "Assigned", "In Progress", "On Hold", "Resolved", "Closed" });
            cmbStatus.SelectedIndex = 0;
            cmbPriority.Items.Clear();
            cmbPriority.Items.AddRange(new object[] { "All priorities", "Urgent", "High", "Medium", "Low" });
            cmbPriority.SelectedIndex = 0;
            cmbNewStatus.Items.Clear();
            cmbNewStatus.Items.AddRange(new object[] { "Submitted", "Assigned", "In Progress", "On Hold", "Resolved", "Closed" });
            cmbNewStatus.SelectedItem = "In Progress";
            _loading = false;
        }

        private void RefreshRequests()
        {
            if (dgvRequests.Columns.Count == 0) return;
            IEnumerable<ServiceRequest> requests = _manager.Filter(cmbStatus.Text, cmbPriority.Text);
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                requests = requests.Where(r => _manager.Search(txtSearch.Text).Any(s => s.RequestId == r.RequestId));
            dgvRequests.DataSource = requests.ToList();
            UpdateStatistics();
            if (dgvRequests.Rows.Count > 0 && dgvRequests.CurrentRow != null)
                ShowSelectedRequest();
            else
                ClearDetails();
        }

        private void UpdateStatistics()
        {
            lblTotal.Text = $"Total requests: {_manager.Count}";
            lblOpen.Text = $"Open: {_manager.GetAll().Count(r => !r.Status.Equals("Resolved", StringComparison.OrdinalIgnoreCase) && !r.Status.Equals("Closed", StringComparison.OrdinalIgnoreCase))}";
            lblResolved.Text = $"Resolved/closed: {_manager.GetAll().Count(r => r.Status.Equals("Resolved", StringComparison.OrdinalIgnoreCase) || r.Status.Equals("Closed", StringComparison.OrdinalIgnoreCase))}";
        }

        private void ShowSelectedRequest()
        {
            if (dgvRequests.CurrentRow?.DataBoundItem is not ServiceRequest request) return;
            txtTrackId.Text = request.RequestId;
            txtDetails.Text =
                $"REQUEST DETAILS\r\n" +
                $"Request ID: {request.RequestId}\r\n" +
                $"Category: {request.Category}\r\n" +
                $"Location: {request.Location}\r\n" +
                $"Priority: {request.Priority}\r\n" +
                $"Status: {request.Status}\r\n" +
                $"Submitted: {request.SubmittedDate:dd MMM yyyy HH:mm}\r\n\r\n" +
                $"Description\r\n{request.Description}\r\n\r\n" +
                $"PROGRESS HISTORY\r\n" +
                (request.History.Count == 0 ? "No progress updates have been recorded." : string.Join("\r\n", request.History));
        }

        private void ClearDetails()
        {
            txtDetails.Clear();
            txtTrackId.Clear();
        }

        private void dgvRequests_SelectionChanged(object? sender, EventArgs e) => ShowSelectedRequest();
        private void txtSearch_TextChanged(object? sender, EventArgs e) => RefreshRequests();
        private void cmbStatus_SelectedIndexChanged(object? sender, EventArgs e) { if (!_loading) RefreshRequests(); }
        private void cmbPriority_SelectedIndexChanged(object? sender, EventArgs e) { if (!_loading) RefreshRequests(); }
        private void btnRefresh_Click(object? sender, EventArgs e) => RefreshRequests();

        private void btnTrack_Click(object? sender, EventArgs e)
        {
            var request = _manager.FindById(txtTrackId.Text);
            if (request == null)
            {
                MessageBox.Show("No service request was found for that identifier. Check the ID and try again.", "Request not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < dgvRequests.Rows.Count; i++)
            {
                if (dgvRequests.Rows[i].DataBoundItem is ServiceRequest rowRequest && rowRequest.RequestId.Equals(request.RequestId, StringComparison.OrdinalIgnoreCase))
                {
                    dgvRequests.ClearSelection();
                    dgvRequests.Rows[i].Selected = true;
                    dgvRequests.CurrentCell = dgvRequests.Rows[i].Cells[0];
                    ShowSelectedRequest();
                    return;
                }
            }
            // If a filter hides the requested item, display its details directly.
            txtDetails.Text = $"REQUEST DETAILS\r\nRequest ID: {request.RequestId}\r\nCategory: {request.Category}\r\nLocation: {request.Location}\r\nPriority: {request.Priority}\r\nStatus: {request.Status}\r\nSubmitted: {request.SubmittedDate:dd MMM yyyy HH:mm}\r\n\r\nDescription\r\n{request.Description}\r\n\r\nPROGRESS HISTORY\r\n{string.Join("\r\n", request.History)}";
        }

        private void btnUpdateStatus_Click(object? sender, EventArgs e)
        {
            string id = txtTrackId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Select a request or enter its request ID first.", "Request ID required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_manager.UpdateStatus(id, cmbNewStatus.Text, txtUpdateNote.Text, out string message))
            {
                txtUpdateNote.Clear();
                RefreshRequests();
                btnTrack_Click(sender, e);
                MessageBox.Show(message, "Status updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(message, "Unable to update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGraph_Click(object? sender, EventArgs e)
        {
            string id = txtTrackId.Text.Trim();
            if (_manager.FindById(id) == null)
            {
                MessageBox.Show("Select a request or enter a valid request ID first.", "Request required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var bfs = _manager.GetGraphBreadthFirst(id).ToList();
            var dfs = _manager.GetGraphDepthFirst(id).ToList();
            var mst = _manager.GetMinimumSpanningForest();
            string mstText = mst.Count == 0 ? "No related-request edges exist yet." : string.Join(Environment.NewLine, mst.Select(e => e.ToString()));
            MessageBox.Show(
                $"RELATED REQUESTS — GRAPH ANALYSIS\r\n\r\nBreadth-first traversal from {id}:\r\n{(bfs.Count == 0 ? "No related requests" : string.Join(" → ", bfs))}\r\n\r\nDepth-first traversal from {id}:\r\n{(dfs.Count == 0 ? "No related requests" : string.Join(" → ", dfs))}\r\n\r\nMinimum spanning forest (Kruskal):\r\n{mstText}",
                "Graph and MST analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPriority_Click(object? sender, EventArgs e)
        {
            var ordered = _manager.GetRequestsByPriority().ToList();
            dgvRequests.DataSource = ordered;
            MessageBox.Show("The list is now ordered by heap priority: Urgent, High, Medium, Low; older requests appear first within each priority.", "Priority queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowTrees_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                $"DATA STRUCTURE INDEX CHECK\r\n\r\nBinary search tree IDs: {string.Join(", ", _manager.GetBinarySearchTreeOrder())}\r\n\r\nAVL tree IDs: {string.Join(", ", _manager.GetAvlTreeOrder())}\r\n\r\nRed-black tree IDs: {string.Join(", ", _manager.GetRedBlackTreeOrder())}\r\n\r\nBinary tree IDs: {string.Join(", ", _manager.GetBinaryTreeOrder())}\r\n\r\nCategory tree (breadth-first): {string.Join(", ", _manager.GetCategoryTreeBreadthFirst())}",
                "Tree indexes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
