namespace Weather
{
    partial class bookmarks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bookmarks));
            this.buttonAddCityID = new System.Windows.Forms.Button();
            this.textBoxCityID = new System.Windows.Forms.TextBox();
            this.labelCityID = new System.Windows.Forms.Label();
            this.listBoxCityIDBookmarks = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAddCityID
            // 
            this.buttonAddCityID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCityID.Location = new System.Drawing.Point(257, 11);
            this.buttonAddCityID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddCityID.Name = "buttonAddCityID";
            this.buttonAddCityID.Size = new System.Drawing.Size(52, 44);
            this.buttonAddCityID.TabIndex = 3;
            this.buttonAddCityID.Text = "Add";
            this.buttonAddCityID.UseVisualStyleBackColor = true;
            this.buttonAddCityID.Click += new System.EventHandler(this.buttonAddCityID_Click);
            // 
            // textBoxCityID
            // 
            this.textBoxCityID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCityID.Location = new System.Drawing.Point(53, 35);
            this.textBoxCityID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCityID.Name = "textBoxCityID";
            this.textBoxCityID.Size = new System.Drawing.Size(200, 20);
            this.textBoxCityID.TabIndex = 2;
            this.textBoxCityID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCityID_KeyPress);
            // 
            // labelCityID
            // 
            this.labelCityID.AutoSize = true;
            this.labelCityID.Location = new System.Drawing.Point(12, 39);
            this.labelCityID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCityID.Name = "labelCityID";
            this.labelCityID.Size = new System.Drawing.Size(37, 13);
            this.labelCityID.TabIndex = 2;
            this.labelCityID.Text = "cityID:";
            // 
            // listBoxCityIDBookmarks
            // 
            this.listBoxCityIDBookmarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCityIDBookmarks.FormattingEnabled = true;
            this.listBoxCityIDBookmarks.Location = new System.Drawing.Point(11, 59);
            this.listBoxCityIDBookmarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxCityIDBookmarks.Name = "listBoxCityIDBookmarks";
            this.listBoxCityIDBookmarks.Size = new System.Drawing.Size(298, 212);
            this.listBoxCityIDBookmarks.Sorted = true;
            this.listBoxCityIDBookmarks.TabIndex = 4;
            this.listBoxCityIDBookmarks.DoubleClick += new System.EventHandler(this.listBoxCityIDBookmarks_DoubleClick);
            this.listBoxCityIDBookmarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxCityIDBookmarks_KeyPress);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(260, 275);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(49, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 15);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(53, 11);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // bookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(320, 309);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.listBoxCityIDBookmarks);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelCityID);
            this.Controls.Add(this.textBoxCityID);
            this.Controls.Add(this.buttonAddCityID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "bookmarks";
            this.ShowInTaskbar = false;
            this.Text = "Bookmarks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.settingsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddCityID;
        private System.Windows.Forms.TextBox textBoxCityID;
        private System.Windows.Forms.Label labelCityID;
        private System.Windows.Forms.ListBox listBoxCityIDBookmarks;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
    }
}