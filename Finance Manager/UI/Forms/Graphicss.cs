using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Finance_Manager.UI.Forms.Dizain;
using static Finance_Manager.UI.Forms.Dizain.ThemeManager;

namespace Finance_Manager.UI.Forms
{
    public partial class Graphicss : Form, IThemeable
    {
        private readonly DatabaseHelper _db;
        private bool isIncome = true;
        private DateTime? filterStart = null;
        private DateTime? filterEnd = null;

        public Graphicss()
        {
            InitializeComponent();
            _db = new DatabaseHelper();

            LoadPieChart();
            LoadBarChart();
            LoadLineChart();

            ThemeManager.ThemeChanged += OnThemeChanged;
            ApplyTheme(ThemeManager.CurrentTheme);
        }

        private void ReloadCharts()
        {
            LoadPieChart();
            LoadBarChart();
            LoadLineChart();
        }

        private void LoadPieChart()
        {
            var list = _db.GetCategorySums(filterStart, filterEnd, isIncome);
            pieChart.Series["Pie"].Points.Clear();

            foreach (var item in list)
                pieChart.Series["Pie"].Points.AddXY(item.Category, item.Sum);
        }

        private void LoadBarChart()
        {
            var list = _db.GetCategorySums(filterStart, filterEnd, isIncome);
            barChart.Series["Bar"].Points.Clear();

            foreach (var item in list)
                barChart.Series["Bar"].Points.AddXY(item.Category, item.Sum);
        }

        private void LoadLineChart()
        {
            var all = _db.GetTransactionsByType(isIncome);

            if (filterStart.HasValue && filterEnd.HasValue)
                all = all.Where(t => t.TransactionDate >= filterStart && t.TransactionDate <= filterEnd).ToList();

            var grouped = all
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new { Date = g.Key, Sum = g.Sum(t => t.Amount) })
                .OrderBy(x => x.Date)
                .ToList();

            lineChart.Series["Line"].Points.Clear();

            foreach (var day in grouped)
                lineChart.Series["Line"].Points.AddXY(day.Date.ToString("dd.MM"), day.Sum);
        }
    
     private void btnIncome_Click(object sender, EventArgs e)
        {
            isIncome = true;
            ReloadCharts();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            isIncome = false;
            ReloadCharts();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            filterStart = DateTime.Today;
            filterEnd = DateTime.Today.AddDays(1).AddTicks(-1);
            ReloadCharts();
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            filterStart = DateTime.Today.AddDays(-7);
            filterEnd = DateTime.Today;
            ReloadCharts();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            filterStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            filterEnd = DateTime.Today;
            ReloadCharts();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            FinanceManagerMain.Instance.Show();
            this.Close();
        }
        public void ApplyTheme(ThemeManager.ThemeType theme)
        {
            this.BackColor = theme == ThemeManager.ThemeType.Light
                ? Color.White
                : Color.FromArgb(30, 30, 30);

            this.ForeColor = theme == ThemeManager.ThemeType.Light
                ? Color.Black
                : Color.White;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme(ThemeManager.CurrentTheme);
        }
    }
}
