namespace Finance_Manager.UI.Forms
{
    partial class Kategories
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
            this.groupBoxIncome = new System.Windows.Forms.GroupBox();
            this.btnAddIncome = new System.Windows.Forms.Button();
            this.txtIncomeInput = new System.Windows.Forms.TextBox();
            this.listBoxIncome = new System.Windows.Forms.ListBox();
            this.groupBoxExpense = new System.Windows.Forms.GroupBox();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.txtExpenseInput = new System.Windows.Forms.TextBox();
            this.listBoxExpense = new System.Windows.Forms.ListBox();
            this.groupBoxIncome.SuspendLayout();
            this.groupBoxExpense.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(12, 1);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(33, 37);
            this.GoBack.TabIndex = 1;
            this.GoBack.Text = "🡸";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // groupBoxIncome
            // 
            this.groupBoxIncome.Controls.Add(this.btnAddIncome);
            this.groupBoxIncome.Controls.Add(this.txtIncomeInput);
            this.groupBoxIncome.Controls.Add(this.listBoxIncome);
            this.groupBoxIncome.Location = new System.Drawing.Point(87, 12);
            this.groupBoxIncome.Name = "groupBoxIncome";
            this.groupBoxIncome.Size = new System.Drawing.Size(200, 574);
            this.groupBoxIncome.TabIndex = 2;
            this.groupBoxIncome.TabStop = false;
            this.groupBoxIncome.Text = "Доходы";
            // 
            // btnAddIncome
            // 
            this.btnAddIncome.Location = new System.Drawing.Point(6, 536);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(75, 23);
            this.btnAddIncome.TabIndex = 3;
            this.btnAddIncome.Text = "Добавить";
            this.btnAddIncome.UseVisualStyleBackColor = true;
            this.btnAddIncome.Click += new System.EventHandler(this.btnAddIncome_Click);
            // 
            // txtIncomeInput
            // 
            this.txtIncomeInput.Location = new System.Drawing.Point(6, 510);
            this.txtIncomeInput.Name = "txtIncomeInput";
            this.txtIncomeInput.Size = new System.Drawing.Size(100, 20);
            this.txtIncomeInput.TabIndex = 3;
            // 
            // listBoxIncome
            // 
            this.listBoxIncome.AllowDrop = true;
            this.listBoxIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxIncome.FormattingEnabled = true;
            this.listBoxIncome.Location = new System.Drawing.Point(3, 16);
            this.listBoxIncome.Name = "listBoxIncome";
            this.listBoxIncome.Size = new System.Drawing.Size(194, 555);
            this.listBoxIncome.TabIndex = 3;
            // 
            // groupBoxExpense
            // 
            this.groupBoxExpense.Controls.Add(this.btnAddExpense);
            this.groupBoxExpense.Controls.Add(this.txtExpenseInput);
            this.groupBoxExpense.Controls.Add(this.listBoxExpense);
            this.groupBoxExpense.Location = new System.Drawing.Point(466, 12);
            this.groupBoxExpense.Name = "groupBoxExpense";
            this.groupBoxExpense.Size = new System.Drawing.Size(215, 574);
            this.groupBoxExpense.TabIndex = 3;
            this.groupBoxExpense.TabStop = false;
            this.groupBoxExpense.Text = "Расходы";
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Location = new System.Drawing.Point(6, 536);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(75, 23);
            this.btnAddExpense.TabIndex = 4;
            this.btnAddExpense.Text = "Добавить";
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // txtExpenseInput
            // 
            this.txtExpenseInput.Location = new System.Drawing.Point(6, 510);
            this.txtExpenseInput.Name = "txtExpenseInput";
            this.txtExpenseInput.Size = new System.Drawing.Size(100, 20);
            this.txtExpenseInput.TabIndex = 3;
            // 
            // listBoxExpense
            // 
            this.listBoxExpense.AllowDrop = true;
            this.listBoxExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxExpense.FormattingEnabled = true;
            this.listBoxExpense.Location = new System.Drawing.Point(3, 16);
            this.listBoxExpense.Name = "listBoxExpense";
            this.listBoxExpense.Size = new System.Drawing.Size(209, 555);
            this.listBoxExpense.TabIndex = 3;
            // 
            // Kategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 598);
            this.Controls.Add(this.groupBoxExpense);
            this.Controls.Add(this.groupBoxIncome);
            this.Controls.Add(this.GoBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Kategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategories";
            this.groupBoxIncome.ResumeLayout(false);
            this.groupBoxIncome.PerformLayout();
            this.groupBoxExpense.ResumeLayout(false);
            this.groupBoxExpense.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBack;
        private System.Windows.Forms.GroupBox groupBoxIncome;
        private System.Windows.Forms.Button btnAddIncome;
        private System.Windows.Forms.TextBox txtIncomeInput;
        private System.Windows.Forms.GroupBox groupBoxExpense;
        private System.Windows.Forms.TextBox txtExpenseInput;
        private System.Windows.Forms.ListBox listBoxExpense;
        private System.Windows.Forms.ListBox listBoxIncome;
        private System.Windows.Forms.Button btnAddExpense;
    }
}