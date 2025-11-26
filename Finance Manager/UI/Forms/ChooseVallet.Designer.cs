namespace Finance_Manager.UI.Forms
{
    partial class ChooseVallet
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
            this.GoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(12, 12);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(33, 37);
            this.GoBack.TabIndex = 4;
            this.GoBack.Text = "🡸";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // ChooseVallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 598);
            this.Controls.Add(this.GoBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseVallet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseVallet";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBack;
    }
}