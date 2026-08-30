namespace MunicipalityApp
{
    partial class ViewReportsForm
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
            panel1 = new Panel();
            panel7 = new Panel();
            listBox1 = new ListBox();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            btnShowReport = new Button();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1004, 698);
            panel1.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(listBox1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(25, 171);
            panel7.Name = "panel7";
            panel7.Size = new Size(952, 497);
            panel7.TabIndex = 5;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(952, 497);
            listBox1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(25, 668);
            panel6.Name = "panel6";
            panel6.Size = new Size(952, 30);
            panel6.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(977, 171);
            panel5.Name = "panel5";
            panel5.Size = new Size(27, 527);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 171);
            panel4.Name = "panel4";
            panel4.Size = new Size(25, 527);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnShowReport);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 96);
            panel3.Name = "panel3";
            panel3.Size = new Size(1004, 75);
            panel3.TabIndex = 1;
            // 
            // btnShowReport
            // 
            btnShowReport.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowReport.Location = new Point(33, 16);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new Size(182, 45);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Show Report";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1004, 96);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(376, 31);
            label1.Name = "label1";
            label1.Size = new Size(252, 42);
            label1.TabIndex = 1;
            label1.Text = "View Reports";
            label1.Click += label1_Click;
            // 
            // ViewReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1004, 698);
            Controls.Add(panel1);
            Name = "ViewReportsForm";
            Text = "ViewReportsForm";
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private Panel panel7;
        private ListBox listBox1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Button btnShowReport;
    }
}