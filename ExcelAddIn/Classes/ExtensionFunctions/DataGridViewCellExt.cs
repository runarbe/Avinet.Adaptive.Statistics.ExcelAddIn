using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class DataGridViewCellExt
    {
        /// <summary>
        /// Returns a combobox or null
        /// </summary>
        /// <param title="c"></param>
        /// <returns></returns>
        public static DataGridViewComboBoxCell AsComboBox(this DataGridViewCell c) {
            if (c is DataGridViewComboBoxCell)
            {
                return (DataGridViewComboBoxCell)c;
            }
            else
            {
                return null;
            }
        }
    }
}
