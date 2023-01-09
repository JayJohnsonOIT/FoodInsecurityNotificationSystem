
namespace template_aj
{
    partial class Templates
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
            this.templatesComboBox = new System.Windows.Forms.ComboBox();
            this.templatesLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.bodyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.templateNameLabel = new System.Windows.Forms.Label();
            this.templateNameTextBox = new System.Windows.Forms.TextBox();
            this.templateToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tagsLabel = new System.Windows.Forms.Label();
            this.tagsComboBox = new System.Windows.Forms.ComboBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // templatesComboBox
            // 
            this.templatesComboBox.FormattingEnabled = true;
            this.templatesComboBox.Location = new System.Drawing.Point(425, 32);
            this.templatesComboBox.Name = "templatesComboBox";
            this.templatesComboBox.Size = new System.Drawing.Size(351, 21);
            this.templatesComboBox.TabIndex = 0;
            this.templatesComboBox.SelectedIndexChanged += new System.EventHandler(this.templatesComboBox_SelectedIndexChanged);
            this.templatesComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.templatesComboBox_KeyPress);
            // 
            // templatesLabel
            // 
            this.templatesLabel.AutoSize = true;
            this.templatesLabel.Location = new System.Drawing.Point(422, 16);
            this.templatesLabel.Name = "templatesLabel";
            this.templatesLabel.Size = new System.Drawing.Size(59, 13);
            this.templatesLabel.TabIndex = 1;
            this.templatesLabel.Text = "Templates:";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(24, 58);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectLabel.TabIndex = 2;
            this.subjectLabel.Text = "Subject:";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(27, 74);
            this.subjectTextBox.MaxLength = 120;
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(623, 20);
            this.subjectTextBox.TabIndex = 3;
            // 
            // bodyRichTextBox
            // 
            this.bodyRichTextBox.Location = new System.Drawing.Point(27, 113);
            this.bodyRichTextBox.MaxLength = 1200;
            this.bodyRichTextBox.Name = "bodyRichTextBox";
            this.bodyRichTextBox.Size = new System.Drawing.Size(749, 294);
            this.bodyRichTextBox.TabIndex = 4;
            this.bodyRichTextBox.Text = "";
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Location = new System.Drawing.Point(24, 97);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(34, 13);
            this.bodyLabel.TabIndex = 5;
            this.bodyLabel.Text = "Body:";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(27, 413);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "&Clear";
            this.templateToolTip.SetToolTip(this.clearButton, "Clear all fields");
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(701, 413);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "&Save";
            this.templateToolTip.SetToolTip(this.saveButton, "Save template");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(620, 413);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "&Delete";
            this.templateToolTip.SetToolTip(this.deleteButton, "Delete selected template");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // templateNameLabel
            // 
            this.templateNameLabel.AutoSize = true;
            this.templateNameLabel.Location = new System.Drawing.Point(24, 17);
            this.templateNameLabel.Name = "templateNameLabel";
            this.templateNameLabel.Size = new System.Drawing.Size(82, 13);
            this.templateNameLabel.TabIndex = 10;
            this.templateNameLabel.Text = "Template Name";
            // 
            // templateNameTextBox
            // 
            this.templateNameTextBox.Location = new System.Drawing.Point(27, 33);
            this.templateNameTextBox.MaxLength = 120;
            this.templateNameTextBox.Name = "templateNameTextBox";
            this.templateNameTextBox.Size = new System.Drawing.Size(352, 20);
            this.templateNameTextBox.TabIndex = 11;
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Location = new System.Drawing.Point(668, 58);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(34, 13);
            this.tagsLabel.TabIndex = 12;
            this.tagsLabel.Text = "Tags:";
            // 
            // tagsComboBox
            // 
            this.tagsComboBox.FormattingEnabled = true;
            this.tagsComboBox.Items.AddRange(new object[] {
            "<Hot Food>",
            "<Location>",
            "<Drinks>",
            "<Clothing>"});
            this.tagsComboBox.Location = new System.Drawing.Point(671, 73);
            this.tagsComboBox.Name = "tagsComboBox";
            this.tagsComboBox.Size = new System.Drawing.Size(105, 21);
            this.tagsComboBox.TabIndex = 13;
            this.tagsComboBox.SelectedIndexChanged += new System.EventHandler(this.tagsComboBox_SelectedIndexChanged);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(539, 413);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Templates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.tagsComboBox);
            this.Controls.Add(this.tagsLabel);
            this.Controls.Add(this.templateNameTextBox);
            this.Controls.Add(this.templateNameLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.bodyRichTextBox);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.templatesLabel);
            this.Controls.Add(this.templatesComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Templates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Templates";
            this.Load += new System.EventHandler(this.templates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox templatesComboBox;
        private System.Windows.Forms.Label templatesLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.RichTextBox bodyRichTextBox;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label templateNameLabel;
        private System.Windows.Forms.TextBox templateNameTextBox;
        private System.Windows.Forms.ToolTip templateToolTip;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.ComboBox tagsComboBox;
        private System.Windows.Forms.Button exitButton;
    }
}

