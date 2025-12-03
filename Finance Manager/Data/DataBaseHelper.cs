using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Finance_Manager.models;


namespace Finance_Manager
{
    public class DatabaseHelper : IDisposable
    {
        private SQLiteConnection _connection;
        private string _dbPath = "finance.db";

        public DatabaseHelper()
        {
            _connection = new SQLiteConnection($"Data Source={_dbPath};Version=3;");
            _connection.Open();

            CreateTables();
            MigrateCategoryTypesIfNeeded();
        }

        private void CreateTables()
        {
            string sql = @"
CREATE TABLE IF NOT EXISTS Categories (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CategoryName TEXT NOT NULL,
    -- храним как 0/1 (INTEGER) для удобства; 1 = Income, 0 = Expense
    CategoryType INTEGER DEFAULT 1 CHECK(CategoryType IN (0,1))
);

CREATE TABLE IF NOT EXISTS Transactions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CategoryId INTEGER,
    Amount REAL NOT NULL,
    Description TEXT,
    TransactionDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    IsIncome INTEGER DEFAULT 1,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);";

            using (var command = new SQLiteCommand(sql, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void MigrateCategoryTypesIfNeeded()
        {
            string sqlIncome = "UPDATE Categories SET CategoryType = 1 WHERE CategoryType = 'Income';";
            string sqlExpense = "UPDATE Categories SET CategoryType = 0 WHERE CategoryType = 'Expense';";

            using (var cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText = sqlIncome;
                try { cmd.ExecuteNonQuery(); } catch { }

                cmd.CommandText = sqlExpense;
                try { cmd.ExecuteNonQuery(); } catch {}
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            var transactions = new List<Transaction>();
            string sql = "SELECT Id, CategoryId, Amount, Description, TransactionDate, IsIncome FROM Transactions";

            using (var command = new SQLiteCommand(sql, _connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    transactions.Add(new Transaction
                    {
                        Id = reader.GetInt32(0),
                        CategoryId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                        Amount = Convert.ToDecimal(reader.GetDouble(2)),
                        Name = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        TransactionDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        IsIncome = !reader.IsDBNull(5) && Convert.ToInt32(reader.GetValue(5)) == 1
                    });
                }
            }

            return transactions;
        }

        public void AddTransaction(Transaction transaction)
        {
            string sql = @"
INSERT INTO Transactions (CategoryId, Amount, Description, TransactionDate, IsIncome)
VALUES (@CategoryId, @Amount, @Description, @TransactionDate, @IsIncome)";

            using (var command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@CategoryId", transaction.CategoryId);
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(transaction.Name) ? DBNull.Value : (object)transaction.Name);
                command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                command.Parameters.AddWithValue("@IsIncome", transaction.IsIncome ? 1 : 0);
                command.ExecuteNonQuery();
            }
        }

        public List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            string sql = "SELECT Id, CategoryName, CategoryType FROM Categories";

            using (var command = new SQLiteCommand(sql, _connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                    bool isIncome = true;
                    if (!reader.IsDBNull(2))
                    {
                        var val = reader.GetValue(2);
                        if (val is long || val is int)
                        {
                            isIncome = Convert.ToInt32(val) == 1;
                        }
                        else
                        {
                            string s = val.ToString();
                            isIncome = s.Equals("Income", StringComparison.OrdinalIgnoreCase) || s == "1" || s.Equals("true", StringComparison.OrdinalIgnoreCase);
                        }
                    }

                    categories.Add(new Category
                    {
                        Id = id,
                        CategoryName = name,
                        CategoryType = isIncome
                    });
                }
            }

            return categories;
        }

        public void DeleteTransaction(int id)
        {
            string sql = "DELETE FROM Transactions WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Transaction> GetTransactionsByType(bool isIncome)
        {
            var transactions = new List<Transaction>();
            string sql = "SELECT Id, CategoryId, Amount, Description, TransactionDate, IsIncome FROM Transactions WHERE IsIncome = @flag";

            using (var command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@flag", isIncome ? 1 : 0);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new Transaction
                        {
                            Id = reader.GetInt32(0),
                            CategoryId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            Amount = Convert.ToDecimal(reader.GetDouble(2)),
                            Name = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            TransactionDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                            IsIncome = !reader.IsDBNull(5) && Convert.ToInt32(reader.GetValue(5)) == 1
                        });
                    }
                }
            }

            return transactions;
        }

        public decimal GetTotalByType(bool isIncome)
        {
            decimal total = 0;
            string sql = "SELECT SUM(Amount) FROM Transactions WHERE IsIncome = @flag";

            using (var command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@flag", isIncome ? 1 : 0);
                var result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    total = Convert.ToDecimal(result);
            }

            return total;
        }

        public void AddCategory(string name, bool type)
        {
            string sql = "INSERT INTO Categories (CategoryName, CategoryType) VALUES (@Name, @Type)";

            using (var cmd = new SQLiteCommand(sql, _connection))
            {
                string typeText = type ? "Income" : "Expense";

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Type", typeText);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCategory(int categoryId)
        {
            string sql = "DELETE FROM Categories WHERE Id = @Id";

            using (var cmd = new SQLiteCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", categoryId);
                cmd.ExecuteNonQuery();
            }
        }


        public bool CategoryExists(string categoryName) // проверка на существование
        {
            string sql = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @Name";
            using (var command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@Name", categoryName);
                var countObj = command.ExecuteScalar();
                int count = 0;
                if (countObj != null && countObj != DBNull.Value)
                    count = Convert.ToInt32(countObj);
                return count > 0;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            string sql = "SELECT Id, CategoryName, CategoryType FROM Categories WHERE Id = @Id";
            using (var command = new SQLiteCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@Id", categoryId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var cat = new Category
                        {
                            Id = reader.GetInt32(0),
                            CategoryName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            CategoryType = !reader.IsDBNull(2) && Convert.ToInt32(reader.GetValue(2)) == 1
                        };
                        return cat;
                    }
                }
            }
            return null;
        }

        public int GetCategoryIdByName(string name)
        {
            string sql = "SELECT Id FROM Categories WHERE CategoryName = @name LIMIT 1";

            using (var cmd = new SQLiteCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
            }

            return -1;
        }

        public List<(string Category, double Sum)> GetCategorySums(
      DateTime? start, DateTime? end, bool? isIncome = null)
        {
            var list = new List<(string Category, double Sum)>();

            string query = @"
        SELECT c.CategoryName,
               SUM(CASE WHEN t.IsIncome = 1 THEN t.Amount ELSE -t.Amount END)
        FROM Categories c
        JOIN Transactions t ON c.Id = t.CategoryId
        WHERE 1=1
    ";

            if (start.HasValue && end.HasValue)
                query += " AND t.TransactionDate BETWEEN @Start AND @End ";

            if (isIncome.HasValue)
                query += " AND t.IsIncome = @IsIncome ";

            query += " GROUP BY c.CategoryName";

            using (var cmd = new SQLiteCommand(query, _connection))
            {
                if (start.HasValue && end.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Start", start.Value);
                    cmd.Parameters.AddWithValue("@End", end.Value);
                }

                if (isIncome.HasValue)
                {
                    cmd.Parameters.AddWithValue("@IsIncome", isIncome.Value ? 1 : 0);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string category = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        double sum = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);

                        list.Add((category, sum));
                    }
                }
            }

            return list;
        }

        public double GetBalance(DateTime? start, DateTime? end)
        {
            string query = "SELECT SUM(Amount) FROM Transactions WHERE 1=1";

            if (start.HasValue && end.HasValue)
                query += " AND TransactionDate BETWEEN @Start AND @End ";

            using (var cmd = new SQLiteCommand(query, _connection))
            {
                if (start.HasValue && end.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Start", start.Value);
                    cmd.Parameters.AddWithValue("@End", end.Value);
                }

                object r = cmd.ExecuteScalar();
                return r != DBNull.Value ? Convert.ToDouble(r) : 0;
            }
        }


        public void Dispose()
        {
            _connection?.Close();
            _connection = null;
        }
    }
}
