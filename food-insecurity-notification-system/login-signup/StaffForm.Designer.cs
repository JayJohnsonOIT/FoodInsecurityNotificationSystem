
namespace login_signup
{
    partial class StaffForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.notificationLogButton = new System.Windows.Forms.Button();
            this.templateButton = new System.Windows.Forms.Button();
            this.sendNotificationButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome staff member! Please select a tool:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Signed in as:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(108, 332);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(0, 20);
            this.usernameLabel.TabIndex = 2;
            // 
            // notificationLogButton
            // 
            this.notificationLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationLogButton.Location = new System.Drawing.Point(12, 153);
            this.notificationLogButton.Name = "notificationLogButton";
            this.notificationLogButton.Size = new System.Drawing.Size(403, 38);
            this.notificationLogButton.TabIndex = 3;
            this.notificationLogButton.Text = "View Notification Log";
            this.infoToolTip.SetToolTip(this.notificationLogButton, "View the notification log");
            this.notificationLogButton.UseVisualStyleBackColor = true;
            this.notificationLogButton.Click += new System.EventHandler(this.notificationLogButton_Click);
            // 
            // templateButton
            // 
            this.templateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateButton.Location = new System.Drawing.Point(12, 197);
            this.templateButton.Name = "templateButton";
            this.templateButton.Size = new System.Drawing.Size(403, 38);
            this.templateButton.TabIndex = 4;
            this.templateButton.Text = "Create/Edit Template";
            this.infoToolTip.SetToolTip(this.templateButton, "Launch the create template page");
            this.templateButton.UseVisualStyleBackColor = true;
            this.templateButton.Click += new System.EventHandler(this.templateButton_Click);
            // 
            // sendNotificationButton
            // 
            this.sendNotificationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendNotificationButton.Location = new System.Drawing.Point(12, 109);
            this.sendNotificationButton.Name = "sendNotificationButton";
            this.sendNotificationButton.Size = new System.Drawing.Size(403, 38);
            this.sendNotificationButton.TabIndex = 5;
            this.sendNotificationButton.Text = "Send Notification";
            this.infoToolTip.SetToolTip(this.sendNotificationButton, "Launch the send notifications page");
            this.sendNotificationButton.UseVisualStyleBackColor = true;
            this.sendNotificationButton.Click += new System.EventHandler(this.sendNotificationButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(12, 241);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(403, 38);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back to Login";
            this.infoToolTip.SetToolTip(this.backButton, "Back to login");
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 361);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.sendNotificationButton);
            this.Controls.Add(this.templateButton);
            this.Controls.Add(this.notificationLogButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Portal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button notificationLogButton;
        private System.Windows.Forms.Button templateButton;
        private System.Windows.Forms.Button sendNotificationButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ToolTip infoToolTip;
    }
}