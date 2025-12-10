using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            public static Color GetSecondaryBack(ThemeType theme) =>
                theme == ThemeType.Light ? Color.FromArgb(245, 245, 245) : Color.FromArgb(40, 40, 40); //панели, карточеки, боковая панель

            public static Color GetCardColor(ThemeType theme) =>
                theme == ThemeType.Light ? Color.White : Color.FromArgb(45, 45, 45); 

            public static Color GetAccentColor(ThemeType theme) =>
                theme == ThemeType.Light ? Color.FromArgb(0, 122, 255) : Color.FromArgb(30, 144, 255); //для кнопок

            public static Color GetBorderColor(ThemeType theme) =>
                theme == ThemeType.Light ? Color.FromArgb(220, 220, 220) : Color.FromArgb(60, 60, 60);

            public static Color GetChartGrid(ThemeType theme) =>
                theme == ThemeType.Light ? Color.FromArgb(220, 220, 220) : Color.FromArgb(70, 70, 70);//для сетки графика

            public static Color GetChartSeries(ThemeType theme) =>
                theme == ThemeType.Light ? Color.FromArgb(0, 122, 255) : Color.FromArgb(0, 153, 255);//цвет столбцов/линий

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
                    gb.BackColor = ThemePalette.GetCardColor(theme);
                    gb.ForeColor = ThemePalette.GetForeColor(theme);
                    gb.Padding = new Padding(10);
                }

                else if (ctrl is Chart chart)
                {
                    chart.BackColor = ThemePalette.GetCardColor(theme);
                    chart.ChartAreas[0].BackColor = ThemePalette.GetCardColor(theme);
                    chart.ChartAreas[0].AxisX.LineColor = ThemePalette.GetBorderColor(theme);
                    chart.ChartAreas[0].AxisY.LineColor = ThemePalette.GetBorderColor(theme);
                    chart.ChartAreas[0].AxisX.MajorGrid.LineColor = ThemePalette.GetChartGrid(theme);
                    chart.ChartAreas[0].AxisY.MajorGrid.LineColor = ThemePalette.GetChartGrid(theme);

                    foreach (var series in chart.Series)
                        series.Color = ThemePalette.GetChartSeries(theme);
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
