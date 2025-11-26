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
            this.Chosetheme = new System.Windows.Forms.Label();
            this.DarkTheme = new System.Windows.Forms.Button();
            this.LightTheme = new System.Windows.Forms.Button();
            this.GoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chosetheme
            // 
            this.Chosetheme.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Chosetheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chosetheme.Location = new System.Drawing.Point(79, 9);
            this.Chosetheme.Name = "Chosetheme";
            this.Chosetheme.Size = new System.Drawing.Size(91, 35);
            this.Chosetheme.TabIndex = 0;
            this.Chosetheme.Text = "Выбор Темы";
            // 
            // DarkTheme
            // 
            this.DarkTheme.Location = new System.Drawing.Point(79, 63);
            this.DarkTheme.Name = "DarkTheme";
            this.DarkTheme.Size = new System.Drawing.Size(88, 40);
            this.DarkTheme.TabIndex = 1;
            this.DarkTheme.Text = "Темная Тема";
            this.DarkTheme.UseVisualStyleBackColor = true;
            this.DarkTheme.Click += new System.EventHandler(this.DarkTheme_Click_1);
            // 
            // LightTheme
            // 
            this.LightTheme.Location = new System.Drawing.Point(79, 127);
            this.LightTheme.Name = "LightTheme";
            this.LightTheme.Size = new System.Drawing.Size(88, 40);
            this.LightTheme.TabIndex = 2;
            this.LightTheme.Text = "Светлая Тема";
            this.LightTheme.UseVisualStyleBackColor = true;
            this.LightTheme.Click += new System.EventHandler(this.LightTheme_Click);
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(12, -1);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(33, 37);
            this.GoBack.TabIndex = 3;
            this.GoBack.Text = "🡸";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // Dizain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 598);
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.LightTheme);
            this.Controls.Add(this.DarkTheme);
            this.Controls.Add(this.Chosetheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dizain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dizain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Chosetheme;
        private System.Windows.Forms.Button DarkTheme;
        private System.Windows.Forms.Button LightTheme;
        private System.Windows.Forms.Button GoBack;
    }
}