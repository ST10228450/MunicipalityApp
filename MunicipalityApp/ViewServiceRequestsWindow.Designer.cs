namespace MunicipalityApp
{
    partial class ViewServiceRequestsWindow
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Label lblResolved;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.TextBox txtTrackId;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.RichTextBox txtDetails;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.TextBox txtUpdateNote;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Button btnPriority;
        private System.Windows.Forms.Button btnShowTrees;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            filterPanel = new Panel();
            txtSearch = new TextBox();
            cmbStatus = new ComboBox();
            cmbPriority = new ComboBox();
            btnRefresh = new Button();
            lblTotal = new Label();
            lblOpen = new Label();
            lblResolved = new Label();
            splitContainer = new SplitContainer();
            dgvRequests = new DataGridView();
            detailsPanel = new Panel();
            lblTrack = new Label();
            txtTrackId = new TextBox();
            btnTrack = new Button();
            txtDetails = new RichTextBox();
            lblUpdateStatus = new Label();
            cmbNewStatus = new ComboBox();
            txtUpdateNote = new TextBox();
            btnUpdateStatus = new Button();
            btnGraph = new Button();
            btnPriority = new Button();
            btnShowTrees = new Button();
            headerPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            detailsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(25, 67, 120);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1202, 86);
            headerPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(512, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Municipal Service Request Status";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(224, 238, 252);
            lblSubtitle.Location = new Point(24, 54);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(500, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Track reported issues, progress updates and related municipal requests";
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.FromArgb(242, 247, 253);
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(cmbStatus);
            filterPanel.Controls.Add(cmbPriority);
            filterPanel.Controls.Add(btnRefresh);
            filterPanel.Controls.Add(lblTotal);
            filterPanel.Controls.Add(lblOpen);
            filterPanel.Controls.Add(lblResolved);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(0, 86);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1202, 100);
            filterPanel.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search ID, category, location or description...";
            txtSearch.Size = new Size(300, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(334, 14);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 28);
            cmbStatus.TabIndex = 1;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Location = new Point(495, 14);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(145, 28);
            cmbPriority.TabIndex = 2;
            cmbPriority.SelectedIndexChanged += cmbPriority_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(35, 110, 190);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(651, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(95, 32);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(22, 61);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(125, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total requests: 0";
            // 
            // lblOpen
            // 
            lblOpen.AutoSize = true;
            lblOpen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOpen.ForeColor = Color.FromArgb(25, 67, 120);
            lblOpen.Location = new Point(220, 61);
            lblOpen.Name = "lblOpen";
            lblOpen.Size = new Size(63, 20);
            lblOpen.TabIndex = 5;
            lblOpen.Text = "Open: 0";
            // 
            // lblResolved
            // 
            lblResolved.AutoSize = true;
            lblResolved.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResolved.ForeColor = Color.FromArgb(25, 95, 160);
            lblResolved.Location = new Point(360, 61);
            lblResolved.Name = "lblResolved";
            lblResolved.Size = new Size(140, 20);
            lblResolved.TabIndex = 6;
            lblResolved.Text = "Resolved/closed: 0";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel2;
            splitContainer.Location = new Point(0, 186);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvRequests);
            splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(detailsPanel);
            splitContainer.Panel2MinSize = 0;
            splitContainer.Size = new Size(1202, 604);
            splitContainer.SplitterDistance = 1171;
            splitContainer.SplitterWidth = 6;
            splitContainer.TabIndex = 0;
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(246, 250, 255);
            dgvRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRequests.BackgroundColor = Color.White;
            dgvRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(25, 67, 120);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRequests.ColumnHeadersHeight = 38;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(205, 229, 252);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRequests.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.Location = new Point(0, 0);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1171, 604);
            dgvRequests.TabIndex = 0;
            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
            // 
            // detailsPanel
            // 
            detailsPanel.BackColor = Color.White;
            detailsPanel.Controls.Add(lblTrack);
            detailsPanel.Controls.Add(txtTrackId);
            detailsPanel.Controls.Add(btnTrack);
            detailsPanel.Controls.Add(txtDetails);
            detailsPanel.Controls.Add(lblUpdateStatus);
            detailsPanel.Controls.Add(cmbNewStatus);
            detailsPanel.Controls.Add(txtUpdateNote);
            detailsPanel.Controls.Add(btnUpdateStatus);
            detailsPanel.Controls.Add(btnGraph);
            detailsPanel.Controls.Add(btnPriority);
            detailsPanel.Controls.Add(btnShowTrees);
            detailsPanel.Dock = DockStyle.Fill;
            detailsPanel.Location = new Point(0, 0);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Padding = new Padding(10);
            detailsPanel.Size = new Size(25, 604);
            detailsPanel.TabIndex = 0;
            // 
            // lblTrack
            // 
            lblTrack.AutoSize = true;
            lblTrack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrack.Location = new Point(12, 13);
            lblTrack.Name = "lblTrack";
            lblTrack.Size = new Size(144, 20);
            lblTrack.TabIndex = 0;
            lblTrack.Text = "Track by request ID";
            // 
            // txtTrackId
            // 
            txtTrackId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTrackId.Location = new Point(14, 37);
            txtTrackId.Name = "txtTrackId";
            txtTrackId.PlaceholderText = "e.g. MS-1001";
            txtTrackId.Size = new Size(61, 27);
            txtTrackId.TabIndex = 1;
            // 
            // btnTrack
            // 
            btnTrack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTrack.BackColor = Color.FromArgb(35, 110, 190);
            btnTrack.FlatStyle = FlatStyle.Flat;
            btnTrack.ForeColor = Color.White;
            btnTrack.Location = new Point(106, 35);
            btnTrack.Name = "btnTrack";
            btnTrack.Size = new Size(76, 31);
            btnTrack.TabIndex = 2;
            btnTrack.Text = "Track";
            btnTrack.UseVisualStyleBackColor = false;
            btnTrack.Click += btnTrack_Click;
            // 
            // txtDetails
            // 
            txtDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetails.BackColor = Color.White;
            txtDetails.Font = new Font("Consolas", 9F);
            txtDetails.Location = new Point(14, 78);
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.Size = new Size(168, 794);
            txtDetails.TabIndex = 3;
            txtDetails.Text = "Select a request to view its details and progress history.";
            // 
            // lblUpdateStatus
            // 
            lblUpdateStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblUpdateStatus.AutoSize = true;
            lblUpdateStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUpdateStatus.Location = new Point(13, 884);
            lblUpdateStatus.Name = "lblUpdateStatus";
            lblUpdateStatus.Size = new Size(249, 20);
            lblUpdateStatus.TabIndex = 4;
            lblUpdateStatus.Text = "Update status / add progress note";
            // 
            // cmbNewStatus
            // 
            cmbNewStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.Location = new Point(14, 909);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(168, 28);
            cmbNewStatus.TabIndex = 5;
            // 
            // txtUpdateNote
            // 
            txtUpdateNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUpdateNote.Location = new Point(14, 944);
            txtUpdateNote.Name = "txtUpdateNote";
            txtUpdateNote.PlaceholderText = "Optional progress note...";
            txtUpdateNote.Size = new Size(168, 27);
            txtUpdateNote.TabIndex = 6;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdateStatus.BackColor = Color.FromArgb(25, 67, 120);
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.Location = new Point(14, 978);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(168, 32);
            btnUpdateStatus.TabIndex = 7;
            btnUpdateStatus.Text = "Save status update";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnGraph
            // 
            btnGraph.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGraph.Location = new Point(14, 1018);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new Size(168, 30);
            btnGraph.TabIndex = 8;
            btnGraph.Text = "Graph traversal and minimum spanning tree";
            btnGraph.Click += btnGraph_Click;
            // 
            // btnPriority
            // 
            btnPriority.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPriority.Location = new Point(14, 1055);
            btnPriority.Name = "btnPriority";
            btnPriority.Size = new Size(166, 30);
            btnPriority.TabIndex = 9;
            btnPriority.Text = "Sort by heap priority";
            btnPriority.Click += btnPriority_Click;
            // 
            // btnShowTrees
            // 
            btnShowTrees.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShowTrees.Location = new Point(15, 1055);
            btnShowTrees.Name = "btnShowTrees";
            btnShowTrees.Size = new Size(167, 30);
            btnShowTrees.TabIndex = 10;
            btnShowTrees.Text = "Inspect tree indexes";
            btnShowTrees.Click += btnShowTrees_Click;
            // 
            // ViewServiceRequestsWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1202, 790);
            Controls.Add(splitContainer);
            Controls.Add(filterPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 650);
            Name = "ViewServiceRequestsWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Municipal Services — Service Request Status";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            detailsPanel.ResumeLayout(false);
            detailsPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
