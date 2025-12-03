using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Finance_Manager.UI.Forms
{
    public partial class Dizain : Form
    {
        public Dizain()
        {
            InitializeComponent();

            ThemeManager.LoadTheme();
            ThemeManager.ApplyThemeToForm(this);
        }


        public enum ThemeType
        {
            Light,
            Dark
        }

        public static class ThemePalette
        {
            public static Color GetBackColor(ThemeType theme) =>
                theme == ThemeType.Light ? Color.White : Color.FromArgb(32, 32, 32);

            public static Color GetForeColor(ThemeType theme) =>
                theme == ThemeType.Light ? Color.Black : Color.White;

            public static Color GetButtonBack(ThemeType theme) =>
                theme == ThemeType.Light ? Color.FromArgb(240, 240, 240) : Color.FromArgb(55, 55, 55);

            public static Color GetInputBack(ThemeType theme) =>
                theme == ThemeType.Light ? Color.White : Color.FromArgb(45, 45, 45);
        }

        public static class ThemeManager
        {
            private static string ThemeFile =>
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FinanceManagerTheme.txt");

            private static ThemeType _theme = ThemeType.Light;

            public static ThemeType CurrentTheme
            {
                get => _theme;
                set
                {
                    if (_theme == value)
                        return;

                    _theme = value;
                    SaveTheme();
                    ApplyThemeToAllForms();
                }
            }

            public static void LoadTheme()
            {
                try
                {
                    if (File.Exists(ThemeFile))
                    {
                        string text = File.ReadAllText(ThemeFile);
                        if (Enum.TryParse(text, out ThemeType t))
                            _theme = t;
                    }
                }
                catch { }
            }

            private static void SaveTheme()
            {
                try
                {
                    File.WriteAllText(ThemeFile, _theme.ToString());
                }
                catch { }
            }

            public static void ApplyThemeToAllForms()
            {
                foreach (Form form in Application.OpenForms)
                    ApplyThemeToForm(form);
            }

            public static void ApplyThemeToForm(Form form)
            {
                var theme = _theme;

                form.BackColor = ThemePalette.GetBackColor(theme);
                form.ForeColor = ThemePalette.GetForeColor(theme);

                foreach (Control ctrl in form.Controls)
                    ApplyThemeToControl(ctrl, theme);
            }

            private static void ApplyThemeToControl(Control ctrl, ThemeType theme)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = ThemePalette.GetButtonBack(theme);
                    btn.ForeColor = ThemePalette.GetForeColor(theme);
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BackColor = ThemePalette.GetInputBack(theme);
                    txt.ForeColor = ThemePalette.GetForeColor(theme);
                }
                else if (ctrl is ComboBox cb)
                {
                    cb.BackColor = ThemePalette.GetInputBack(theme);
                    cb.ForeColor = ThemePalette.GetForeColor(theme);
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = ThemePalette.GetForeColor(theme);
                }
                else if (ctrl is Panel pnl)
                {
                    pnl.BackColor = ThemePalette.GetBackColor(theme);
                }
                else if (ctrl is GroupBox gb)
                {
                    gb.BackColor = ThemePalette.GetBackColor(theme);
                    gb.ForeColor = ThemePalette.GetForeColor(theme);
                }

                if (ctrl.HasChildren)
                {
                    foreach (Control child in ctrl.Controls)
                        ApplyThemeToControl(child, theme);
                }
            }
        }

        private void LightTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.CurrentTheme = ThemeType.Light;
        }

        private void DarkTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.CurrentTheme = ThemeType.Dark;
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
