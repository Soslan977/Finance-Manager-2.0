using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Manager.UI.Forms
{
    public partial class DateRangeSmallForm : Form
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public DateRangeSmallForm()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            StartDate = monthCalendar.SelectionStart;
            EndDate = monthCalendar.SelectionEnd;

            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
