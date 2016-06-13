using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class StatVarProperties
    {
        public Variable StatVar1;
        public Variable StatVar2;
        public Variable StatVar3;
        public Variable StatVar4;
        public Variable StatVar5;
        public string Unit;
        public string Year;
        public string Quarter;
        public string Month;
        public string Day;
        public string fk_variable;
        public string time_unit;
        public string fk_kretstype;

        public static Variable GetVariable(DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                return null;
            }

            if (cell.Value.GetType() == typeof(Variable))
            {
                var v = (Variable)cell.Value;
                if (cell.ColumnIndex.Between(2, 7))
                {
                    return v;
                }
            }

            return null;
        }

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

            for (int i = 0, j = dgvStatVarProperties.RowCount; i < j; i++)
            {
                int mIndex = (int)dgvStatVarProperties["Index", i].Value;

                if (mIndex == mStatVarIndex)
                {
                    for (int f = 0; f < dgvStatVarProperties.ColumnCount; f++)
                    {
                        DataGridViewColumn mDGVC = dgvStatVarProperties.Columns[f];

                        switch (mDGVC.DataPropertyName)
                        {
                            case "StatVarCol1":
                                mStatVarProperties.StatVar1 = GetVariable(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar1 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar1.id.ToString();
                                }
                                break;
                            case "StatVarCol2":
                                mStatVarProperties.StatVar2 = GetVariable(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar2 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar2.id.ToString();
                                } break;
                            case "StatVarCol3":
                                mStatVarProperties.StatVar3 = GetVariable(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar3 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar3.id.ToString();
                                } break;
                            case "StatVarCol4":
                                mStatVarProperties.StatVar4 = GetVariable(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar4 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar4.id.ToString();
                                }
                                break;
                            case "StatVarCol5":
                                mStatVarProperties.StatVar5 = GetVariable(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar5 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar5.id.ToString();
                                }
                                break;
                            case "Kretstype":
                                mStatVarProperties.fk_kretstype = Util.CheckNullOrEmpty(dgvStatVarProperties[f, i].Value);
                                break;
                            case "Year":
                                mStatVarProperties.Year = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                            case "Quarter":
                                mStatVarProperties.Quarter = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                            case "Month":
                                mStatVarProperties.Month = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                            case "Unit":
                                mStatVarProperties.Unit = dgvStatVarProperties[f, i].Value.GetNullEmptyOrString();
                                break;
                            case "TimeUnit":
                                mStatVarProperties.time_unit = Util.CheckNullOrEmpty(dgvStatVarProperties[f, i].Value);
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
