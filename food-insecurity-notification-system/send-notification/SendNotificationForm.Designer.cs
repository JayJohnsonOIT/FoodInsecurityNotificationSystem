
namespace send_notification
{
    partial class SendNotificationForm
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
            this.components = new System.ComponentModel.Container();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.loadTemplateButton = new System.Windows.Forms.Button();
            this.templateSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.sendNotificationTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.sendNotificationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sendNotificationErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(12, 9);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectLabel.TabIndex = 0;
            this.subjectLabel.Text = "Subject:";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 55);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(53, 13);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "Message:";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(64, 6);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(500, 20);
            this.subjectTextBox.TabIndex = 2;
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Location = new System.Drawing.Point(12, 71);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.Size = new System.Drawing.Size(552, 250);
            this.messageRichTextBox.TabIndex = 3;
            this.messageRichTextBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.AutoSize = true;
            this.sendButton.Location = new System.Drawing.Point(12, 327);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(254, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send Message";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(272, 327);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(152, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // loadTemplateButton
            // 
            this.loadTemplateButton.Location = new System.Drawing.Point(12, 356);
            this.loadTemplateButton.Name = "loadTemplateButton";
            this.loadTemplateButton.Size = new System.Drawing.Size(182, 23);
            this.loadTemplateButton.TabIndex = 6;
            this.loadTemplateButton.Text = "Load Template";
            this.loadTemplateButton.UseVisualStyleBackColor = true;
            this.loadTemplateButton.Click += new System.EventHandler(this.loadTemplateButton_Click);
            // 
            // templateSelectionComboBox
            // 
            this.templateSelectionComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.templateSelectionComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.templateSelectionComboBox.FormattingEnabled = true;
            this.templateSelectionComboBox.Location = new System.Drawing.Point(200, 358);
            this.templateSelectionComboBox.Name = "templateSelectionComboBox";
            this.templateSelectionComboBox.Size = new System.Drawing.Size(364, 21);
            this.templateSelectionComboBox.TabIndex = 7;
            this.sendNotificationTooltip.SetToolTip(this.templateSelectionComboBox, "Select template");
            // 
            // sendNotificationErrorProvider
            // 
            this.sendNotificationErrorProvider.ContainerControl = this;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(430, 327);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(134, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // SendNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.templateSelectionComboBox);
            this.Controls.Add(this.loadTemplateButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageRichTextBox);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.subjectLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SendNotificationForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Notification";
            this.Load += new System.EventHandler(this.SendNotificationForm_Load);
            this.Shown += new System.EventHandler(this.SendNotificationForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.sendNotificationErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button loadTemplateButton;
        private System.Windows.Forms.ComboBox templateSelectionComboBox;
        private System.Windows.Forms.ToolTip sendNotificationTooltip;
        private System.Windows.Forms.ErrorProvider sendNotificationErrorProvider;
        private System.Windows.Forms.Button exitButton;
    }
}

