using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Finance_Manager.UI.Forms.Dizain.ThemeManager;

namespace Finance_Manager.UI.Forms
{
    public partial class Dizain : Form
    {
        // Создаём статический менеджер тем
        public static class ThemeManager
        {
            private static string filePath = "theme.txt";
            public static event EventHandler ThemeChanged;

            public enum ThemeType
            {
                Light = 0,
                Dark = 1
            }

            private static ThemeType _currentTheme;
            public static ThemeType CurrentTheme
            {
                get => _currentTheme;
                set
                {
                    _currentTheme = value;
                    ThemeChanged?.Invoke(null, EventArgs.Empty);
                }
            }

            public static void SaveTheme(ThemeType theme)
            {
                try
                {
                    File.WriteAllText(filePath, ((int)theme).ToString());
                }
                catch { }
            }

            public static ThemeType LoadTheme()
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        return (ThemeType)int.Parse(File.ReadAllText(filePath));
                    }
                    catch { }
                }
                return ThemeType.Light; // По умолчанию светлая тема
            }
        }

        public Dizain()
        {
            InitializeComponent();
            // Подписываемся на изменение темы
            ThemeManager.ThemeChanged += OnThemeChanged;
            // Загружаем и применяем текущую тему
            ThemeManager.CurrentTheme = ThemeManager.LoadTheme();
            ApplyTheme(ThemeManager.CurrentTheme);
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme(ThemeManager.CurrentTheme);
        }

        private void ApplyTheme(ThemeType theme)
        {
            ApplyControlsTheme(this, theme);
        }

        private void ApplyControlsTheme(Form form, ThemeType theme)
        {
            form.BackColor = theme == ThemeType.Light ? Color.White : Color.FromArgb(30, 30, 30);
            form.ForeColor = theme == ThemeType.Light ? Color.Black : Color.White;

            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is Button button)
                {
                    button.ForeColor = theme == ThemeType.Light ? Color.Black : Color.White;
                    if (button == DarkTheme)
                    {
                        button.BackColor = theme == ThemeType.Light ? Color.LightGray : Color.LightBlue;
                    }
                    else if (button == LightTheme)
                    {
                        button.BackColor = theme == ThemeType.Light ? Color.LightBlue : Color.LightGray;
                        button.ForeColor = theme == ThemeType.Light ? Color.White : Color.Black;
                    }
                    else
                    {
                        button.BackColor = theme == ThemeType.Light ? Color.White : Color.FromArgb(50, 50, 50);
                    }
                }
                else if (ctrl is Label label)
                {
                    label.ForeColor = theme == ThemeType.Light ? Color.Black : Color.White;
                }
            }
        }

        private void LightTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.CurrentTheme = ThemeType.Light;
            ThemeManager.SaveTheme(ThemeType.Light);
        }

        private void DarkTheme_Click_1(object sender, EventArgs e)
        {
            ThemeManager.CurrentTheme = ThemeType.Dark;
            ThemeManager.SaveTheme(ThemeType.Dark);
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            FinanceManagerMain.Instance.Show();
            this.Close();
        }

        // Добавляем метод для применения темы ко всем формам
        public void ApplyThemeToAllForms(ThemeType theme)
        {
            foreach (Form form in Application.OpenForms)
            {
                // Проверяем, что форма поддерживает интерфейс IThemeable
                if (form is IThemeable themeableForm)
                {
                    // Применяем тему только если это не текущая форма
                    if (form != this)
                    {
                        themeableForm.ApplyTheme(theme);
                    }
                    else
                    {
                        // Для текущей формы применяем тему напрямую
                        ApplyControlsTheme(form, theme);
                    }
                }
            }
        }
    }

    // Определяем интерфейс для форм, поддерживающих смену темы
    public interface IThemeable
    {
        void ApplyTheme(ThemeType theme);
    }
}