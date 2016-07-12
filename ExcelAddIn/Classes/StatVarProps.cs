using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class StatVarProperties
    {
        public Variable Variable;
        public string Unit;
        public string Year;
        public string Quarter;
        public string Month;
        public string fk_variable;
        public string time_unit;
        public string fk_kretstype;

        public static StatVarProperties Get(DataGridView dgvStatVarProperties, int pRow, int pCol, DataOrientation pDataOrientation)
        {
            int mStatVarIndex;

            if (pDataOrientation == DataOrientation.InColumns)
            {
                mStatVarIndex = pRow;
            }
            else
            {
                mStatVarIndex = pCol;
            }

            var mStatVarProperties = new StatVarProperties();

            for (int rowIndex = 0, maxRows = dgvStatVarProperties.RowCount; rowIndex < maxRows; rowIndex++)
            {
                int statVarIndex = (int)dgvStatVarProperties["Index", rowIndex].Value;

                if (statVarIndex == mStatVarIndex)
                {
                    for (int columnIndex = 0; columnIndex < dgvStatVarProperties.ColumnCount; columnIndex++)
                    {
                        DataGridViewColumn mDGVC = dgvStatVarProperties.Columns[columnIndex];

                        switch (mDGVC.DataPropertyName)
                        {
                            case "SelectedStatVar":
                                Variable mVariable = dgvStatVarProperties[columnIndex, rowIndex].AsComboBox().Value as Variable;
                                if (mVariable != null)
                                {
                                    mStatVarProperties.fk_variable = mVariable.id.ToString();
                                    mStatVarProperties.Variable = mVariable;
                                }
                                break;
                            case "Kretstype":
                                mStatVarProperties.fk_kretstype = Util.CheckNullOrEmpty(dgvStatVarProperties[columnIndex, rowIndex].Value);
                                break;
                            case "Year":
                                mStatVarProperties.Year = Table.GetNullOrDoubleString(dgvStatVarProperties[columnIndex, rowIndex].Value);
                                break;
                            case "Quarter":
                                mStatVarProperties.Quarter = Table.GetNullOrDoubleString(dgvStatVarProperties[columnIndex, rowIndex].Value);
                                break;
                            case "Month":
                                mStatVarProperties.Month = Table.GetNullOrDoubleString(dgvStatVarProperties[columnIndex, rowIndex].Value);
                                break;
                            case "Unit":
                                mStatVarProperties.Unit = dgvStatVarProperties[columnIndex, rowIndex].Value.GetNullEmptyOrString();
                                break;
                            case "TimeUnit":
                                mStatVarProperties.time_unit = Util.CheckNullOrEmpty(dgvStatVarProperties[columnIndex, rowIndex].Value);
                                break;
                        }

                    }
                    break;
                }
            }
            return mStatVarProperties;
        }

    }
}
