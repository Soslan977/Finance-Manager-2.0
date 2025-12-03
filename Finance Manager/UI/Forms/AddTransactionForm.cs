using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Finance_Manager.models;
using static Finance_Manager.UI.Forms.Dizain;

namespace Finance_Manager.UI.Forms
{
    public partial class AddTransactionForm : Form
    {
        private DatabaseHelper _dbHelper;
        private List<Category> categories;

        public Transaction Transaction { get; private set; }

        public AddTransactionForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            ThemeManager.ApplyThemeToForm(this);

            cmbCategory.DisplayMember = nameof(Category.CategoryName);
            cmbCategory.ValueMember = nameof(Category.Id);

            radioIncome.CheckedChanged += radioIncome_CheckedChanged;
            radioExpense.CheckedChanged += radioExpense_CheckedChanged;
            radioIncome.Checked = true;

            LoadCategoriesFromDb();
            UpdateCategoryList();
        }

        private void LoadCategoriesFromDb()
        {
            categories = _dbHelper.GetAllCategories();

            cmbCategory.DataSource = null;

            if (categories != null && categories.Any())
            {
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = nameof(Category.CategoryName);
                cmbCategory.ValueMember = nameof(Category.Id);
            }
            else
            {
                cmbCategory.Items.Clear();
                MessageBox.Show("Список категорий пуст!");
            }
        }

        private void UpdateCategoryList()
        {
            try
            {
                var allCategories = _dbHelper.GetAllCategories();

                var filteredCategories = allCategories
                    .Where(c => (radioIncome.Checked && c.CategoryType) ||
                                (!radioIncome.Checked && !c.CategoryType))
                    .ToList();

                cmbCategory.DataSource = null;

                if (filteredCategories.Any())

                {
                    cmbCategory.DataSource = filteredCategories;
                    cmbCategory.DisplayMember = nameof(Category.CategoryName);
                    cmbCategory.ValueMember = nameof(Category.Id);
                }
                else
                {
                    cmbCategory.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении списка категорий: {ex.Message}");
            }
        }

        private void radioIncome_CheckedChanged(object sender, EventArgs e) => UpdateCategoryList();
        private void radioExpense_CheckedChanged(object sender, EventArgs e) => UpdateCategoryList();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Категория не выбрана!");
                return;
            }

            if (!(cmbCategory.SelectedValue is int categoryId))
            {
                try
                {
                    categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Ошибка при получении ID категории!");
                    return;
                }
            }

            Transaction = new Transaction
            {
                Name = txtTransactionName.Text,
                Amount = (decimal)numAmount.Value,
                CategoryId = categoryId,
                IsIncome = radioIncome.Checked,
                TransactionDate = dtpDate.Value
            };

            try
            {
                _dbHelper.AddTransaction(Transaction);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении транзакции: {ex.Message}");
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtTransactionName.Text))
            {
                MessageBox.Show("Введите название транзакции!");
                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите категорию!");
                return false;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Сумма должна быть больше нуля!");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
        private void numAmount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
