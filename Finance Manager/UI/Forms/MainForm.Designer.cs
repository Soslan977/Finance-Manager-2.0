namespace Finance_Manager
{
    partial class FinanceManagerMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinanceManagerMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.burgerButton = new System.Windows.Forms.Button();
            this.Расходы = new System.Windows.Forms.Button();
            this.Доходы = new System.Windows.Forms.Button();
            this.AddTransaction = new System.Windows.Forms.Button();
            this.chartGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.btnAllTransactions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.menuPanel, "menuPanel");
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            // 
            // burgerButton
            // 
            this.burgerButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.burgerButton, "burgerButton");
            this.burgerButton.Name = "burgerButton";
            this.burgerButton.UseVisualStyleBackColor = false;
            this.burgerButton.Click += new System.EventHandler(this.burgerButton_Click_1);
            // 
            // Расходы
            // 
            resources.ApplyResources(this.Расходы, "Расходы");
            this.Расходы.Name = "Расходы";
            this.Расходы.UseVisualStyleBackColor = true;
            this.Расходы.Click += new System.EventHandler(this.Expensesbutton1_Click);
            // 
            // Доходы
            // 
            resources.ApplyResources(this.Доходы, "Доходы");
            this.Доходы.Name = "Доходы";
            this.Доходы.UseVisualStyleBackColor = true;
            this.Доходы.Click += new System.EventHandler(this.Доходы_Click);
            // 
            // AddTransaction
            // 
            resources.ApplyResources(this.AddTransaction, "AddTransaction");
            this.AddTransaction.Name = "AddTransaction";
            this.AddTransaction.UseVisualStyleBackColor = true;
            this.AddTransaction.Click += new System.EventHandler(this.AddTransaction_Click);
            // 
            // chartGraphic
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGraphic.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGraphic.Legends.Add(legend1);
            resources.ApplyResources(this.chartGraphic, "chartGraphic");
            this.chartGraphic.Name = "chartGraphic";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartGraphic.Series.Add(series1);
            // 
            // lblBalance
            // 
            resources.ApplyResources(this.lblBalance, "lblBalance");
            this.lblBalance.Name = "lblBalance";
            // 
            // btnToday
            // 
            resources.ApplyResources(this.btnToday, "btnToday");
            this.btnToday.Name = "btnToday";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnWeek
            // 
            resources.ApplyResources(this.btnWeek, "btnWeek");
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.UseVisualStyleBackColor = true;
            this.btnWeek.Click += new System.EventHandler(this.btnWeek_Click);
            // 
            // btnMonth
            // 
            resources.ApplyResources(this.btnMonth, "btnMonth");
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnCustom
            // 
            resources.ApplyResources(this.btnCustom, "btnCustom");
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnAllTransactions
            // 
            resources.ApplyResources(this.btnAllTransactions, "btnAllTransactions");
            this.btnAllTransactions.Name = "btnAllTransactions";
            this.btnAllTransactions.UseVisualStyleBackColor = true;
            this.btnAllTransactions.Click += new System.EventHandler(this.btnAllTransactions_Click);
            // 
            // FinanceManagerMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAllTransactions);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.chartGraphic);
            this.Controls.Add(this.AddTransaction);
            this.Controls.Add(this.Доходы);
            this.Controls.Add(this.Расходы);
            this.Controls.Add(this.burgerButton);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinanceManagerMain";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button burgerButton;
        private System.Windows.Forms.Button Расходы;
        private System.Windows.Forms.Button Доходы;
        private System.Windows.Forms.Button AddTransaction;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGraphic;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnAllTransactions;
    }
}

