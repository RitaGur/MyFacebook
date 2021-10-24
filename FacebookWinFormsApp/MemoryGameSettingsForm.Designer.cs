namespace BasicFacebookFeatures
{
    public partial class MemoryGameSettingsForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.listBoxFriendsList = new System.Windows.Forms.ListBox();
            this.labelPleaseChooseFriend = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(50, 382);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(324, 54);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBoxFriendsList
            // 
            this.listBoxFriendsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBoxFriendsList.FormattingEnabled = true;
            this.listBoxFriendsList.ItemHeight = 25;
            this.listBoxFriendsList.Location = new System.Drawing.Point(50, 97);
            this.listBoxFriendsList.Name = "listBoxFriendsList";
            this.listBoxFriendsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxFriendsList.Size = new System.Drawing.Size(324, 279);
            this.listBoxFriendsList.TabIndex = 1;
            // 
            // labelPleaseChooseFriend
            // 
            this.labelPleaseChooseFriend.AutoSize = true;
            this.labelPleaseChooseFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPleaseChooseFriend.Location = new System.Drawing.Point(37, 46);
            this.labelPleaseChooseFriend.Name = "labelPleaseChooseFriend";
            this.labelPleaseChooseFriend.Size = new System.Drawing.Size(351, 26);
            this.labelPleaseChooseFriend.TabIndex = 2;
            this.labelPleaseChooseFriend.Text = "Please choose friends from the list:";
            this.labelPleaseChooseFriend.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MemoryGameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(439, 453);
            this.Controls.Add(this.labelPleaseChooseFriend);
            this.Controls.Add(this.listBoxFriendsList);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemoryGameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListBox listBoxFriendsList;
        private System.Windows.Forms.Label labelPleaseChooseFriend;
    }
}