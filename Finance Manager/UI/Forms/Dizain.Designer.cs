namespace Finance_Manager.UI.Forms
{
    partial class Dizain
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
            this.LightTheme = new System.Windows.Forms.Button();
            this.DarkTheme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(12, 12);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(33, 37);
            this.GoBack.TabIndex = 2;
            this.GoBack.Text = "🡸";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // LightTheme
            // 
            this.LightTheme.Location = new System.Drawing.Point(113, 26);
            this.LightTheme.Name = "LightTheme";
            this.LightTheme.Size = new System.Drawing.Size(107, 45);
            this.LightTheme.TabIndex = 3;
            this.LightTheme.Text = "Светлая тема";
            this.LightTheme.UseVisualStyleBackColor = true;
            this.LightTheme.Click += new System.EventHandler(this.LightTheme_Click);
            // 
            // DarkTheme
            // 
            this.DarkTheme.Location = new System.Drawing.Point(336, 26);
            this.DarkTheme.Name = "DarkTheme";
            this.DarkTheme.Size = new System.Drawing.Size(107, 45);
            this.DarkTheme.TabIndex = 4;
            this.DarkTheme.Text = "Темная Тема";
            this.DarkTheme.UseVisualStyleBackColor = true;
            this.DarkTheme.Click += new System.EventHandler(this.DarkTheme_Click);
            // 
            // Dizain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DarkTheme);
            this.Controls.Add(this.LightTheme);
            this.Controls.Add(this.GoBack);
            this.Name = "Dizain";
            this.Text = "Dizain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBack;
        private System.Windows.Forms.Button LightTheme;
        private System.Windows.Forms.Button DarkTheme;
    }
}