using System.Drawing;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormBirthdayCardsGenerator
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonChooseForeColor = new System.Windows.Forms.Button();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.buttonGenerateCard = new System.Windows.Forms.Button();
            this.textBoxPreview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBackGroundColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(370, 324);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(134, 31);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Change Greeting";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonChooseForeColor
            // 
            this.buttonChooseForeColor.Location = new System.Drawing.Point(462, 379);
            this.buttonChooseForeColor.Name = "buttonChooseForeColor";
            this.buttonChooseForeColor.Size = new System.Drawing.Size(147, 31);
            this.buttonChooseForeColor.TabIndex = 2;
            this.buttonChooseForeColor.Text = "Fore Color";
            this.buttonChooseForeColor.UseVisualStyleBackColor = true;
            this.buttonChooseForeColor.Click += new System.EventHandler(this.buttonChooseColor_Click);
            // 
            // listBoxMain
            // 
            this.listBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 25;
            this.listBoxMain.Location = new System.Drawing.Point(240, 37);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(395, 129);
            this.listBoxMain.TabIndex = 55;
            this.listBoxMain.SelectedIndexChanged += new System.EventHandler(this.listBoxMain_SelectedIndexChanged);
            // 
            // buttonGenerateCard
            // 
            this.buttonGenerateCard.Location = new System.Drawing.Point(266, 433);
            this.buttonGenerateCard.Name = "buttonGenerateCard";
            this.buttonGenerateCard.Size = new System.Drawing.Size(343, 78);
            this.buttonGenerateCard.TabIndex = 56;
            this.buttonGenerateCard.Text = "Generate Card!";
            this.buttonGenerateCard.UseVisualStyleBackColor = true;
            this.buttonGenerateCard.Click += new System.EventHandler(this.buttonGenerateCard_Click);
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.Location = new System.Drawing.Point(240, 189);
            this.textBoxPreview.Multiline = true;
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.Size = new System.Drawing.Size(395, 129);
            this.textBoxPreview.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 58;
            this.label1.Text = "Preview:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 29);
            this.label2.TabIndex = 59;
            this.label2.Text = "Choose a friend:";
            // 
            // buttonBackGroundColor
            // 
            this.buttonBackGroundColor.Location = new System.Drawing.Point(266, 379);
            this.buttonBackGroundColor.Name = "buttonBackGroundColor";
            this.buttonBackGroundColor.Size = new System.Drawing.Size(147, 31);
            this.buttonBackGroundColor.TabIndex = 60;
            this.buttonBackGroundColor.Text = "Background Color";
            this.buttonBackGroundColor.UseVisualStyleBackColor = true;
            this.buttonBackGroundColor.Click += new System.EventHandler(this.buttonBackGroundColor_Click);
            // 
            // FormBirthdayCardsGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(777, 548);
            this.Controls.Add(this.buttonBackGroundColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPreview);
            this.Controls.Add(this.buttonGenerateCard);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.buttonChooseForeColor);
            this.Controls.Add(this.buttonNext);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBirthdayCardsGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Birthday Card Generator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonChooseForeColor;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Button buttonGenerateCard;
        private System.Windows.Forms.TextBox textBoxPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBackGroundColor;
    }
}