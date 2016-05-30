using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    /// <summary>
    /// A class to hold the current state of the form
    /// </summary>
    [Serializable]
    public class UploadFormState
    {
        // Name and ID
        public string StateName { get; set; }
        public string StateId { get; set; }

        // CellContenTypes
        public string StatVarCol1 { get; set; }
        public string StatVarCol2 { get; set; }
        public string StatVarCol3 { get; set; }
        public string StatVarCol4 { get; set; }
        public string StatVarRow1 { get; set; }
        public string StatVarRow2 { get; set; }
        public string StatVarRow3 { get; set; }
        public string StatVarRow4 { get; set; }

        // StatArea
        public string StatUnitType { get; set; }
        public string StatUnitName { get; set; }
        public string StatUnitID { get; set; }
        public string StatUnitGroup { get; set; }

        public string StatDatumFormat { get; set; }

        public string StatDatumYear { get; set; }
        public string StatDatumQuarter { get; set; }
        public string StatDatumMonth { get; set; }
        public string StatDatumDay { get; set; }

        public List<UploadFormFieldState> StatVarProperties { get; set; }

        public UploadFormState()
        {
            this.StateId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Save the state of the form to a f
        /// </summary>
        /// <param name="mFrm"></param>
        /// <returns></returns>
        [Obsolete("No form states to be saved")]
        public static UploadFormState RecordState(UploadForm mFrm)
        {
            var mJson = new JavaScriptSerializer();
            var mState = new UploadFormState();

            mState.StatVarCol1 = (string)mFrm.cbColCType1.SelectedValue;
            mState.StatVarCol2 = (string)mFrm.cbColCType2.SelectedValue;
            mState.StatVarCol3 = (string)mFrm.cbColCType3.SelectedValue;
            mState.StatVarCol4 = (string)mFrm.cbColCType4.SelectedValue;

            mState.StatVarRow1 = (string)mFrm.cbRowCType1.SelectedValue;
            mState.StatVarRow2 = (string)mFrm.cbRowCType2.SelectedValue;
            mState.StatVarRow3 = (string)mFrm.cbRowCType3.SelectedValue;
            mState.StatVarRow4 = (string)mFrm.cbRowCType4.SelectedValue;

            mState.StatDatumFormat = (string)mFrm.cbStatDatumFormat.SelectedValue;
            mState.StatDatumYear = (string)mFrm.tbStatDatumYear.Text;
            mState.StatDatumQuarter = (string)mFrm.cbStatDatumQuarter.Text;
            mState.StatDatumMonth = (string)mFrm.tbStatDatumMonth.Text;

            mState.StatUnitType = (string)mFrm.cbStatUnitType.SelectedValue;
            mState.StatUnitID = (string)mFrm.tbStatUnitID.Text;
            mState.StatUnitName = (string)mFrm.tbStatUnitName.Text;
            mState.StatUnitGroup = (string)mFrm.tbStatUnitGroup.Text;

            mState.StatVarProperties = UploadFormFieldState.GetFieldStates(mFrm.dgvStatVarProperties);

            return mState;
        }

        public static bool RestoreState(UploadForm mFrm, UploadFormState mState)
        {

            UploadFormState.RestoreCB(mFrm.cbColCType1, mState.StatVarCol1);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbColCType1, DataOrientation.InColumns, 1);
            UploadFormState.RestoreCB(mFrm.cbColCType2, mState.StatVarCol2);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbColCType2, DataOrientation.InColumns, 2);
            UploadFormState.RestoreCB(mFrm.cbColCType3, mState.StatVarCol3);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbColCType3, DataOrientation.InColumns, 3);
            UploadFormState.RestoreCB(mFrm.cbColCType4, mState.StatVarCol4);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbColCType4, DataOrientation.InColumns, 4);

            UploadFormState.RestoreCB(mFrm.cbRowCType1, mState.StatVarRow1);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbRowCType1, DataOrientation.InRows, 1);
            UploadFormState.RestoreCB(mFrm.cbRowCType2, mState.StatVarRow2);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbRowCType2, DataOrientation.InRows, 2);
            UploadFormState.RestoreCB(mFrm.cbRowCType3, mState.StatVarRow3);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbRowCType3, DataOrientation.InRows, 3);
            UploadFormState.RestoreCB(mFrm.cbRowCType4, mState.StatVarRow4);
            mFrm.OnCellContenTypeComboBoxChangeCommit(mFrm.cbRowCType4, DataOrientation.InRows, 4);

            UploadFormState.RestoreCB(mFrm.cbStatUnitType, mState.StatUnitType);
            UploadFormState.RestoreTB(mFrm.tbStatUnitID, mState.StatUnitID);

            if (mState.StatUnitName != null)
            {
                mFrm.tbStatUnitName.Text = mState.StatUnitName;
            }
            if (mState.StatUnitGroup != null)
            {
                mFrm.tbStatUnitGroup.Text = mState.StatUnitGroup;
            }

            if (mState.StatDatumFormat != null)
            {
                mFrm.cbStatDatumFormat.SelectedValue = mState.StatDatumFormat;
            }
            if (mState.StatDatumYear != null)
            {
                mFrm.tbStatDatumYear.Text = mState.StatDatumYear;
            }
            if (mState.StatDatumQuarter != null)
            {
                mFrm.cbStatDatumQuarter.Text = mState.StatDatumQuarter;
            }
            if (mState.StatDatumMonth != null)
            {
                mFrm.tbStatDatumMonth.Text = mState.StatDatumMonth;
            }

            mFrm.LoadStatVarPropertiesGrid();

            var mNumStatVarProperties = mFrm.dgvStatVarProperties.Rows.Count;
            var mNumStoredProperties = mState.StatVarProperties.Count();
            var mLimit = (mNumStoredProperties < mNumStatVarProperties) ? mNumStoredProperties : mNumStatVarProperties;

            for (int i = 0; i < mLimit; i++)
            {
                // Get current stored field
                var mStatVarProperty = mState.StatVarProperties[i];

                // Get corresponding row in datagridview
                DataGridViewCellCollection mRow = mFrm.dgvStatVarProperties.Rows[i].Cells;

                // Create a variable for each of the combobox cells
                DataGridViewComboBoxCell mStatVarCol1 = (DataGridViewComboBoxCell)mRow["StatVarCol1"];
                DataGridViewComboBoxCell mStatVarCol2 = (DataGridViewComboBoxCell)mRow["StatVarCol2"];
                DataGridViewComboBoxCell mStatVarCol3 = (DataGridViewComboBoxCell)mRow["StatVarCol3"];
                DataGridViewComboBoxCell mStatVarCol4 = (DataGridViewComboBoxCell)mRow["StatVarCol4"];
                DataGridViewComboBoxCell mStatVarCol5 = (DataGridViewComboBoxCell)mRow["StatVarCol5"];
                DataGridViewComboBoxCell mMeasurementUnitCol = (DataGridViewComboBoxCell)mRow["enhet"];

                // Add the selected item to the combobox cells
                if (mStatVarProperty.StatVarLevel1 != null)
                {
                    mStatVarCol1.Items.Add(ComboBoxItem.GetNewItem(mStatVarProperty.StatVarLevel1));
                    mStatVarCol1.ValueMember = "value";
                    mStatVarCol1.DisplayMember = "key";
                    mStatVarCol1.Value = mStatVarProperty.StatVarLevel1;
                }
                if (mStatVarProperty.StatVarLevel2 != null)
                {
                    mStatVarCol2.Items.Add(ComboBoxItem.GetNewItem(mStatVarProperty.StatVarLevel2));
                    mStatVarCol2.ValueMember = "value";
                    mStatVarCol2.DisplayMember = "key";
                    mStatVarCol2.Value = mStatVarProperty.StatVarLevel2;
                }
                if (mStatVarProperty.StatVarLevel3 != null)
                {
                    mStatVarCol3.Items.Add(ComboBoxItem.GetNewItem(mStatVarProperty.StatVarLevel3));
                    mStatVarCol3.ValueMember = "value";
                    mStatVarCol3.DisplayMember = "key";
                    mStatVarCol3.Value = mStatVarProperty.StatVarLevel3;
                }
                if (mStatVarProperty.StatVarLevel4 != null)
                {
                    mStatVarCol4.Items.Add(ComboBoxItem.GetNewItem(mStatVarProperty.StatVarLevel4));
                    mStatVarCol4.ValueMember = "value";
                    mStatVarCol4.DisplayMember = "key";
                    mStatVarCol4.Value = mStatVarProperty.StatVarLevel4;
                }
                if (mStatVarProperty.StatVarLevel5 != null)
                {
                    mStatVarCol5.Items.Add(ComboBoxItem.GetNewItem(mStatVarProperty.StatVarLevel5));
                    mStatVarCol5.ValueMember = "value";
                    mStatVarCol5.DisplayMember = "key";
                    mStatVarCol5.Value = mStatVarProperty.StatVarLevel5;
                }
                if (mStatVarProperty.MeasurementUnit != null)
                {
                    mMeasurementUnitCol.Items.Add(ComboBoxItem.GetNewItem(mStatVarProperty.MeasurementUnit));
                    mStatVarCol5.ValueMember = "value";
                    mStatVarCol5.DisplayMember = "key";
                    mMeasurementUnitCol.Value = mStatVarProperty.MeasurementUnit;
                }

                mRow["ar"].Value = mStatVarProperty.Year;
                mRow["kvartal"].Value = mStatVarProperty.Quarter;
                mRow["mnd"].Value = mStatVarProperty.Month;
                mRow["Day"].Value = mStatVarProperty.Day;

            }
            return true;
        }

        private static void RestoreCB(ComboBox pComboBox, string pString)
        {
            if (pString != null && pComboBox.ValueMember != null)
            {
                pComboBox.SelectedValue = pString;
            }
            else
            {
                pComboBox.SelectedValue = "";
            }
        }

        private static void RestoreTB(TextBox pTextBox, string pString)
        {
            if (pString != null)
            {
                pTextBox.Text = pString;
            }
            else
            {
                pTextBox.Text = "";
            }
        }
    }
}
