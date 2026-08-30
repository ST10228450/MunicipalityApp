namespace MunicipalityApp
{
    partial class IssueReportingForm
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            txtLocation = new TextBox();
            progressBar1 = new ProgressBar();
            label4 = new Label();
            categoryDropDown = new ComboBox();
            label5 = new Label();
            txtDescription = new RichTextBox();
            btnChooseFile = new Button();
            label6 = new Label();
            labelFileName = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            lblFileName = new Label();
            lblDescription = new Label();
            lblCategory = new Label();
            lblLocation = new Label();
            progressBar2 = new ProgressBar();
            btnSave = new Button();
            imageFileUpload = new PictureBox();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageFileUpload).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(353, 98);
            label1.Name = "label1";
            label1.Size = new Size(366, 46);
            label1.TabIndex = 0;
            label1.Text = "Issue Report Form";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.emergency;
            pictureBox1.Location = new Point(490, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(287, 144);
            label2.Name = "label2";
            label2.Size = new Size(486, 20);
            label2.TabIndex = 2;
            label2.Text = "Let us know about any issues within the community by filling in this form";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(69, 228);
            label3.Name = "label3";
            label3.Size = new Size(83, 22);
            label3.TabIndex = 3;
            label3.Text = "Location:";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLocation.Location = new Point(189, 225);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(228, 28);
            txtLocation.TabIndex = 6;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-1, -1);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1033, 10);
            progressBar1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(69, 294);
            label4.Name = "label4";
            label4.Size = new Size(88, 22);
            label4.TabIndex = 8;
            label4.Text = "Category:";
            // 
            // categoryDropDown
            // 
            categoryDropDown.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            categoryDropDown.FormattingEnabled = true;
            categoryDropDown.Items.AddRange(new object[] { "Water", "Electricity", "Roads", "Refuse Collection", "Sewege" });
            categoryDropDown.Location = new Point(189, 294);
            categoryDropDown.Name = "categoryDropDown";
            categoryDropDown.Size = new Size(228, 30);
            categoryDropDown.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(52, 361);
            label5.Name = "label5";
            label5.Size = new Size(105, 22);
            label5.TabIndex = 10;
            label5.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = SystemColors.HighlightText;
            txtDescription.Location = new Point(189, 361);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(228, 149);
            txtDescription.TabIndex = 11;
            txtDescription.Text = "";
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(209, 571);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(189, 40);
            btnChooseFile.TabIndex = 12;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(52, 528);
            label6.Name = "label6";
            label6.Size = new Size(96, 22);
            label6.TabIndex = 13;
            label6.Text = "File Name:";
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFileName.ForeColor = SystemColors.ButtonHighlight;
            labelFileName.Location = new Point(189, 528);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(136, 22);
            labelFileName.TabIndex = 14;
            labelFileName.Text = "No file Selected";
            labelFileName.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(35, 60);
            label8.Name = "label8";
            label8.Size = new Size(207, 29);
            label8.TabIndex = 15;
            label8.Text = "Report Summary";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(27, 119);
            label9.Name = "label9";
            label9.Size = new Size(83, 22);
            label9.TabIndex = 16;
            label9.Text = "Location:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(22, 150);
            label10.Name = "label10";
            label10.Size = new Size(88, 22);
            label10.TabIndex = 17;
            label10.Text = "Category:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(0, 184);
            label11.Name = "label11";
            label11.Size = new Size(105, 22);
            label11.TabIndex = 18;
            label11.Text = "Description:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(9, 216);
            label12.Name = "label12";
            label12.Size = new Size(96, 22);
            label12.TabIndex = 19;
            label12.Text = "File Name:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.google_docs;
            pictureBox2.Location = new Point(110, 17);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblFileName);
            panel1.Controls.Add(lblDescription);
            panel1.Controls.Add(lblCategory);
            panel1.Controls.Add(lblLocation);
            panel1.Controls.Add(progressBar2);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(649, 225);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 285);
            panel1.TabIndex = 21;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFileName.ForeColor = SystemColors.ButtonHighlight;
            lblFileName.Location = new Point(110, 216);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(145, 22);
            lblFileName.TabIndex = 25;
            lblFileName.Text = "Field is Required";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = SystemColors.ButtonHighlight;
            lblDescription.Location = new Point(110, 184);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(145, 22);
            lblDescription.TabIndex = 24;
            lblDescription.Text = "Field is Required";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.ForeColor = SystemColors.ButtonHighlight;
            lblCategory.Location = new Point(110, 150);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(145, 22);
            lblCategory.TabIndex = 23;
            lblCategory.Text = "Field is Required";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLocation.ForeColor = SystemColors.ButtonHighlight;
            lblLocation.Location = new Point(110, 119);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(145, 22);
            lblLocation.TabIndex = 22;
            lblLocation.Text = "Field is Required";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(22, 95);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(236, 10);
            progressBar2.TabIndex = 21;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(690, 528);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(189, 40);
            btnSave.TabIndex = 22;
            btnSave.Text = "Save and Continue";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // imageFileUpload
            // 
            imageFileUpload.Location = new Point(466, 361);
            imageFileUpload.Name = "imageFileUpload";
            imageFileUpload.Size = new Size(130, 130);
            imageFileUpload.TabIndex = 23;
            imageFileUpload.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Tomato;
            btnExit.Location = new Point(909, 616);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(106, 29);
            btnExit.TabIndex = 24;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // IssueReportingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1027, 657);
            Controls.Add(btnExit);
            Controls.Add(imageFileUpload);
            Controls.Add(btnSave);
            Controls.Add(panel1);
            Controls.Add(labelFileName);
            Controls.Add(label6);
            Controls.Add(btnChooseFile);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(categoryDropDown);
            Controls.Add(label4);
            Controls.Add(progressBar1);
            Controls.Add(txtLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            MaximumSize = new Size(1045, 704);
            Name = "IssueReportingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IssueReportingForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageFileUpload).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox txtLocation;
        private ProgressBar progressBar1;
        private Label label4;
        private ComboBox categoryDropDown;
        private Label label5;
        private RichTextBox txtDescription;
        private Button btnChooseFile;
        private Label label6;
        private Label labelFileName;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private PictureBox pictureBox2;
        private Panel panel1;
        private ProgressBar progressBar2;
        private Button btnSave;
        private Label lblLocation;
        private Label lblFileName;
        private Label lblDescription;
        private Label lblCategory;
        private PictureBox imageFileUpload;
        private Button btnExit;
    }
}