using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finance_Manager.models;
using static Finance_Manager.UI.Forms.Dizain;


namespace Finance_Manager.UI.Forms
{
    public partial class AllTransactionsForm : Form
    {
        private readonly DatabaseHelper _dbHelper;
        private List<Transaction> transactions;
        public AllTransactionsForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            ThemeManager.ApplyThemeToForm(this);

            InitTable();
            LoadTransactions();
        }
        private void InitTable()
        {
            dgvTransactions.Columns.Clear();
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 40 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Название", DataPropertyName = "Name", Width = 150 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Сумма", DataPropertyName = "Amount", Width = 80 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Категория", DataPropertyName = "CategoryName", Width = 120 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Дата", DataPropertyName = "TransactionDate", Width = 120 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Тип", DataPropertyName = "IsIncomeText", Width = 80 });
        }

        private void LoadTransactions()
        {
            var categories = _dbHelper.GetAllCategories();
            transactions = _dbHelper.GetAllTransactions();


            var view = transactions.Select(t =>
            {
                var cat = categories.FirstOrDefault(c => c.Id == t.CategoryId);


                return new
                {
                    t.Id,
                    Name = string.IsNullOrEmpty(t.Name) ? "—" : t.Name,
                    t.Amount,
                    CategoryName = cat?.CategoryName ?? "—",
                    TransactionDate = t.TransactionDate.ToString("dd.MM.yyyy"),
                    IsIncomeText = t.IsIncome ? "Доход" : "Расход"
                };
            }).ToList();


            dgvTransactions.DataSource = view;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите транзакцию!");
                return;
            }


            int id = (int)dgvTransactions.SelectedRows[0].Cells[0].Value;


            if (MessageBox.Show("Удалить выбранную транзакцию?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _dbHelper.DeleteTransaction(id);
                LoadTransactions();


                FinanceManagerMain.Instance.LoadDataFromDb();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
