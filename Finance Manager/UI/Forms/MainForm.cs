using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Finance_Manager.models;
using Finance_Manager.UI.Forms;
using static Finance_Manager.UI.Forms.Dizain;
using static Finance_Manager.UI.Forms.Dizain.ThemeManager;

namespace Finance_Manager
{
    public partial class FinanceManagerMain : Form, IThemeable
    {
        private DatabaseHelper _dbHelper;
        private List<Transaction> transactions;
        private List<Category> categories;
        public static FinanceManagerMain Instance { get; private set; }
        private bool menuIsVisible = false;
        public bool isIncomeMode = true;
        private DateTime? filterStart = null;
        private DateTime? filterEnd = null;


        public FinanceManagerMain()
        {
            InitializeComponent();
            AddMenuItems();
            Instance = this;



            _dbHelper = new DatabaseHelper();

            chartGraphic.Series.Clear();
            chartGraphic.Series.Add("Транзакции");
            chartGraphic.Series[0].ChartType = SeriesChartType.Pie;
            chartGraphic.Titles.Add("Распределение транзакций");

            LoadDataFromDb();


            ThemeManager.ThemeChanged += OnThemeChanged;
            ApplyTheme(ThemeManager.CurrentTheme);


        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            burgerButton.Visible = true;
            menuPanel.Visible = menuIsVisible;

            btnToday_Click(null, null);
        }

        private void burgerButton_Click_1(object sender, EventArgs e)
        {
            Panel menu = menuPanel;

            menu.Visible = !menu.Visible;

            if (menu.Visible)
                burgerButton.Text = "×";
            else
                burgerButton.Text = "☰";
        }

        private void Expensesbutton1_Click(object sender, EventArgs e)
        {
            isIncomeMode = false;
            UpdateChart();
        }

        private void Доходы_Click(object sender, EventArgs e)
        {
            isIncomeMode = true;
            UpdateChart();
        }


        private void AddMenuItems()
        {
            var items = new[] { "Категории", "Графики", "Регулярный платеж", "Дизайн", "Валюта" };

            foreach (var item in items)
            {
                var button = new Button
                {
                    Text = item,
                    Dock = DockStyle.Top,
                    Height = 30,
                    BackColor = Color.FromArgb(224, 224, 224)
                };
                button.Click += MenuItem_Click;
                menuPanel.Controls.Add(button);
            }
        }
        private void ShowForm(Form newForm)
        {
            if (newForm is FinanceManagerMain)
            {
                this.Show();
                return;
            }

            this.Hide();

            newForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            newForm.Show();
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            switch (button.Text)
            {
                case "Главная":
                    this.Show();
                    break;

                case "Категории":
                    ShowForm(new Kategories());
                    break;

                case "Графики":
                    ShowForm(new Graphicss());
                    break;

                case "Регулярный платеж":
                    MessageBox.Show("Функция пока не реализована.");
                    break;

                case "Дизайн":
                    ShowForm(new Dizain());
                    break;

                case "Валюта":
                    ShowForm(new ChooseVallet());
                    break;
            }
        }


        public void LoadDataFromDb()
        {
            categories = _dbHelper.GetAllCategories();
            transactions = _dbHelper.GetAllTransactions();

            UpdateChart();
            UpdateBalance();
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme(ThemeManager.CurrentTheme);
        }

        public void ApplyTheme(ThemeType theme)
        {
            this.BackColor = theme == ThemeType.Light ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = theme == ThemeType.Light ? System.Drawing.Color.Black : System.Drawing.Color.White;
        }

        private void UpdateChart()
        {
            chartGraphic.Series[0].Points.Clear();

            var data = _dbHelper.GetCategorySums(filterStart, filterEnd, isIncomeMode);

            foreach (var item in data)
                chartGraphic.Series[0].Points.AddXY(item.Category, item.Sum);

            UpdateBalance();
        }

        private void UpdateBalance()
        {
            double balance = _dbHelper.GetBalance(filterStart, filterEnd);
            lblBalance.Text = $"Баланс: {balance:C}";
        }

        private void AddTransaction_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddTransactionForm(_dbHelper))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var transaction = addForm.Transaction;


                    // перезагружаем данные
                    transactions = _dbHelper.GetAllTransactions();
                    categories = _dbHelper.GetAllCategories();

                    UpdateChart();
                    UpdateBalance();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ThemeManager.ThemeChanged -= OnThemeChanged;
            _dbHelper.Dispose();
            base.OnFormClosed(e);
        }
        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
        }
        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            filterStart = DateTime.Today;
            filterEnd = DateTime.Today.AddDays(1).AddTicks(-1);
            UpdateChart();
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            filterEnd = DateTime.Today.AddDays(1).AddTicks(-1);
            filterStart = DateTime.Today.AddDays(-7);
            UpdateChart();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            filterStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            filterEnd = DateTime.Today.AddDays(1).AddTicks(-1);
            UpdateChart();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            using (var form = new DateRangeSmallForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    filterStart = form.StartDate;
                    filterEnd = form.EndDate;

                    UpdateChart();
                    UpdateBalance();
                }
            }
        }

        private void btnAllTransactions_Click(object sender, EventArgs e)
        {
            using (var form = new AllTransactionsForm(_dbHelper))
            {
                form.ShowDialog();
            }
        }
    }
}
