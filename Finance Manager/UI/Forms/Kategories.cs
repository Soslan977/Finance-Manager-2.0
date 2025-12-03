using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Finance_Manager.models;
using static Finance_Manager.UI.Forms.Dizain;
namespace Finance_Manager.UI.Forms
{
    public partial class Kategories : Form
    {
        private DatabaseHelper _dbHelper;
        private List<string> incomeCategories;
        private List<string> expenseCategories;

        public Kategories()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            ThemeManager.ApplyThemeToForm(this);
            LoadCategoriesFromDb();

            listBoxIncome.DataSource = incomeCategories;
            listBoxExpense.DataSource = expenseCategories;
        }

        private void LoadCategoriesFromDb()
        {
            var allCategories = _dbHelper.GetAllCategories();

            incomeCategories = allCategories
                .Where(c => c.CategoryType)        // True = доход
                .Select(c => c.CategoryName)
                .ToList();

            expenseCategories = allCategories
                .Where(c => !c.CategoryType)      // False = расход
                .Select(c => c.CategoryName)
                .ToList();
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme(ThemeManager.CurrentTheme);
        }

        public void ApplyTheme(ThemeType theme)
        {
            this.BackColor = theme == ThemeType.Light ? Color.White : Color.FromArgb(30, 30, 30);
            this.ForeColor = theme == ThemeType.Light ? Color.Black : Color.White;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button button)
                {
                    button.ForeColor = theme == ThemeType.Light ? Color.Black : Color.White;
                    button.BackColor = theme == ThemeType.Light ? Color.White : Color.FromArgb(50, 50, 50);
                }
                else if (ctrl is Label label)
                {
                    label.ForeColor = theme == ThemeType.Light ? Color.Black : Color.White;
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _dbHelper.Dispose();
            base.OnFormClosed(e);
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            string newCategory = txtIncomeInput.Text.Trim();
            if (!string.IsNullOrEmpty(newCategory))
            {
                if (_dbHelper.CategoryExists(newCategory))
                {
                    MessageBox.Show("Категория уже существует!");
                    return;
                }
                try
                {
                    _dbHelper.AddCategory(newCategory, true); // true = доход
                    LoadCategoriesFromDb();
                    listBoxIncome.DataSource = null;
                    listBoxIncome.DataSource = incomeCategories;
                    txtIncomeInput.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении категории: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Категория не может быть пустой!");
            }
        }
        private void btnDeleteIncome_Click(object sender, EventArgs e)
        {
            string selected = listBoxIncome.SelectedItem as string;

            if (selected == null)
            {
                MessageBox.Show("Выберите категорию для удаления!");
                return;
            }

            if (MessageBox.Show($"Удалить категорию \"{selected}\"?",
                "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            int id = _dbHelper.GetCategoryIdByName(selected);

            if (id != -1)
            {
                _dbHelper.DeleteCategory(id);
                LoadCategoriesFromDb();

                listBoxIncome.DataSource = null;
                listBoxIncome.DataSource = incomeCategories;
            }
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            string newCategory = txtExpenseInput.Text.Trim();
            if (!string.IsNullOrEmpty(newCategory))
            {
                if (_dbHelper.CategoryExists(newCategory))
                {
                    MessageBox.Show("Категория уже существует!");
                    return;
                }
                try
                {
                    _dbHelper.AddCategory(newCategory, false); // false = расход
                    LoadCategoriesFromDb();
                    listBoxExpense.DataSource = null;
                    listBoxExpense.DataSource = expenseCategories;
                    txtExpenseInput.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении категории: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Категория не может быть пустой!");
            }
        }

        private void btnDeleteExpense_Click(object sender, EventArgs e)
        {
            string selected = listBoxExpense.SelectedItem as string;

            if (selected == null)
            {
                MessageBox.Show("Выберите категорию для удаления!");
                return;
            }

            if (MessageBox.Show($"Удалить категорию \"{selected}\"?",
                "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            int id = _dbHelper.GetCategoryIdByName(selected);

            if (id != -1)
            {
                _dbHelper.DeleteCategory(id);
                LoadCategoriesFromDb();

                listBoxExpense.DataSource = null;
                listBoxExpense.DataSource = expenseCategories;
            }
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            FinanceManagerMain.Instance.Show();
            this.Close();
        }

    }
}
