
namespace notification_log
{
    partial class NotificationLogForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.messageSearchTextBox = new System.Windows.Forms.TextBox();
            this.alertsLabel = new System.Windows.Forms.Label();
            this.alertsPanel = new System.Windows.Forms.Panel();
            this.droughtRichTextBox = new System.Windows.Forms.RichTextBox();
            this.duplicateRichTextBox = new System.Windows.Forms.RichTextBox();
            this.droughtLabel = new System.Windows.Forms.Label();
            this.duplicateLabel = new System.Windows.Forms.Label();
            this.subjectSearchTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.subjectSearchLabel = new System.Windows.Forms.Label();
            this.messageSearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.alertsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.AutoSize = true;
            this.dateRangeLabel.Location = new System.Drawing.Point(13, 13);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(104, 13);
            this.dateRangeLabel.TabIndex = 0;
            this.dateRangeLabel.Text = "Select Date Range: ";
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Location = new System.Drawing.Point(12, 41);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(33, 13);
            this.fromDateLabel.TabIndex = 1;
            this.fromDateLabel.Text = "From:";
            // 
            // toDateLabel
            // 
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Location = new System.Drawing.Point(12, 68);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(23, 13);
            this.toDateLabel.TabIndex = 2;
            this.toDateLabel.Text = "To:";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Location = new System.Drawing.Point(62, 34);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(213, 20);
            this.fromDateTimePicker.TabIndex = 3;
            this.fromDateTimePicker.Value = new System.DateTime(2022, 10, 17, 0, 0, 0, 0);
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Location = new System.Drawing.Point(62, 61);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(213, 20);
            this.toDateTimePicker.TabIndex = 4;
            this.toDateTimePicker.Value = new System.DateTime(2022, 11, 3, 0, 0, 0, 0);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(16, 272);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(259, 24);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(16, 302);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(259, 24);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(288, 34);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(486, 322);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Location = new System.Drawing.Point(12, 370);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(42, 13);
            this.detailsLabel.TabIndex = 8;
            this.detailsLabel.Text = "Details:";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(71, 390);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.ReadOnly = true;
            this.subjectTextBox.Size = new System.Drawing.Size(911, 20);
            this.subjectTextBox.TabIndex = 9;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(12, 397);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectLabel.TabIndex = 10;
            this.subjectLabel.Text = "Subject:";
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageRichTextBox.Location = new System.Drawing.Point(71, 417);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.ReadOnly = true;
            this.messageRichTextBox.Size = new System.Drawing.Size(911, 224);
            this.messageRichTextBox.TabIndex = 12;
            this.messageRichTextBox.Text = "";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 420);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(53, 13);
            this.messageLabel.TabIndex = 13;
            this.messageLabel.Text = "Message:";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(16, 332);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(259, 24);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 98);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(74, 13);
            this.searchLabel.TabIndex = 20;
            this.searchLabel.Text = "Search Fields:";
            // 
            // messageSearchTextBox
            // 
            this.messageSearchTextBox.Location = new System.Drawing.Point(16, 232);
            this.messageSearchTextBox.Name = "messageSearchTextBox";
            this.messageSearchTextBox.Size = new System.Drawing.Size(259, 20);
            this.messageSearchTextBox.TabIndex = 21;
            // 
            // alertsLabel
            // 
            this.alertsLabel.AutoSize = true;
            this.alertsLabel.Location = new System.Drawing.Point(779, 13);
            this.alertsLabel.Name = "alertsLabel";
            this.alertsLabel.Size = new System.Drawing.Size(36, 13);
            this.alertsLabel.TabIndex = 24;
            this.alertsLabel.Text = "Alerts:";
            // 
            // alertsPanel
            // 
            this.alertsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.alertsPanel.Controls.Add(this.droughtRichTextBox);
            this.alertsPanel.Controls.Add(this.duplicateRichTextBox);
            this.alertsPanel.Controls.Add(this.droughtLabel);
            this.alertsPanel.Controls.Add(this.duplicateLabel);
            this.alertsPanel.Location = new System.Drawing.Point(782, 34);
            this.alertsPanel.Name = "alertsPanel";
            this.alertsPanel.Size = new System.Drawing.Size(200, 322);
            this.alertsPanel.TabIndex = 24;
            // 
            // droughtRichTextBox
            // 
            this.droughtRichTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.droughtRichTextBox.Location = new System.Drawing.Point(3, 179);
            this.droughtRichTextBox.Name = "droughtRichTextBox";
            this.droughtRichTextBox.ReadOnly = true;
            this.droughtRichTextBox.Size = new System.Drawing.Size(193, 137);
            this.droughtRichTextBox.TabIndex = 5;
            this.droughtRichTextBox.Text = "";
            // 
            // duplicateRichTextBox
            // 
            this.duplicateRichTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.duplicateRichTextBox.Location = new System.Drawing.Point(3, 23);
            this.duplicateRichTextBox.Name = "duplicateRichTextBox";
            this.duplicateRichTextBox.ReadOnly = true;
            this.duplicateRichTextBox.Size = new System.Drawing.Size(193, 137);
            this.duplicateRichTextBox.TabIndex = 4;
            this.duplicateRichTextBox.Text = "";
            // 
            // droughtLabel
            // 
            this.droughtLabel.AutoSize = true;
            this.droughtLabel.Location = new System.Drawing.Point(5, 163);
            this.droughtLabel.Name = "droughtLabel";
            this.droughtLabel.Size = new System.Drawing.Size(96, 13);
            this.droughtLabel.TabIndex = 3;
            this.droughtLabel.Text = "Notification Status:";
            // 
            // duplicateLabel
            // 
            this.duplicateLabel.AutoSize = true;
            this.duplicateLabel.Location = new System.Drawing.Point(4, 7);
            this.duplicateLabel.Name = "duplicateLabel";
            this.duplicateLabel.Size = new System.Drawing.Size(116, 13);
            this.duplicateLabel.TabIndex = 0;
            this.duplicateLabel.Text = "Duplicate Notifications:";
            // 
            // subjectSearchTextBox
            // 
            this.subjectSearchTextBox.Location = new System.Drawing.Point(15, 183);
            this.subjectSearchTextBox.Name = "subjectSearchTextBox";
            this.subjectSearchTextBox.Size = new System.Drawing.Size(260, 20);
            this.subjectSearchTextBox.TabIndex = 25;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(16, 137);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(259, 20);
            this.usernameTextBox.TabIndex = 26;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(13, 121);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 27;
            this.usernameLabel.Text = "Username:";
            // 
            // subjectSearchLabel
            // 
            this.subjectSearchLabel.AutoSize = true;
            this.subjectSearchLabel.Location = new System.Drawing.Point(13, 167);
            this.subjectSearchLabel.Name = "subjectSearchLabel";
            this.subjectSearchLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectSearchLabel.TabIndex = 28;
            this.subjectSearchLabel.Text = "Subject:";
            // 
            // messageSearchLabel
            // 
            this.messageSearchLabel.AutoSize = true;
            this.messageSearchLabel.Location = new System.Drawing.Point(13, 216);
            this.messageSearchLabel.Name = "messageSearchLabel";
            this.messageSearchLabel.Size = new System.Drawing.Size(50, 13);
            this.messageSearchLabel.TabIndex = 29;
            this.messageSearchLabel.Text = "Message";
            // 
            // NotificationLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(995, 689);
            this.Controls.Add(this.messageSearchLabel);
            this.Controls.Add(this.subjectSearchLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.subjectSearchTextBox);
            this.Controls.Add(this.alertsPanel);
            this.Controls.Add(this.alertsLabel);
            this.Controls.Add(this.messageSearchTextBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.messageRichTextBox);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.toDateLabel);
            this.Controls.Add(this.fromDateLabel);
            this.Controls.Add(this.dateRangeLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NotificationLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification Log";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.alertsPanel.ResumeLayout(false);
            this.alertsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.Label fromDateLabel;
        private System.Windows.Forms.Label toDateLabel;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox messageSearchTextBox;
        private System.Windows.Forms.Label alertsLabel;
        private System.Windows.Forms.Panel alertsPanel;
        private System.Windows.Forms.Label duplicateLabel;
        private System.Windows.Forms.Label droughtLabel;
        private System.Windows.Forms.RichTextBox droughtRichTextBox;
        private System.Windows.Forms.RichTextBox duplicateRichTextBox;
        private System.Windows.Forms.TextBox subjectSearchTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label subjectSearchLabel;
        private System.Windows.Forms.Label messageSearchLabel;
    }
}

