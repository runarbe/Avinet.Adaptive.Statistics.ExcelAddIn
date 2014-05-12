using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Web.Script.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    [Serializable]
    public class UploadFormStates
    {
        public static JavaScriptSerializer Json = new JavaScriptSerializer(new SimpleTypeResolver());
        public static string StateFile = "SavedImportSettings.json";
        public List<UploadFormState> States { get; set; }
        
        public UploadFormStates()
        {
            this.States = new List<UploadFormState>();
        }

        public static UploadFormStates Load()
        {
            var mFilename = Util.GetFullResourceFilename(UploadFormStates.StateFile);
            if (File.Exists(mFilename))
            {
                var mSettings = File.ReadAllText(mFilename);
                if (mSettings != "")
                {
                    var mUploadFormStates = UploadFormStates.Json.Deserialize<UploadFormStates>(mSettings);
                    if (mUploadFormStates != null)
                    {
                        return mUploadFormStates;
                    }
                }
            }

            var mEmptyUploadFormStates = new UploadFormStates();
            UploadFormStates.Save(mEmptyUploadFormStates);
            return mEmptyUploadFormStates;

        }

        public static UploadFormState GetState(string pStateId) {
            var mSavedSettings = UploadFormStates.Load();
            foreach (var mState in mSavedSettings.States)
            {
                if (mState.StateId == pStateId)
                {
                    return mState;
                }
            }
            return null;
        }

        public static List<ComboBoxItem> GetComboBoxItems()
        {
            var mItems = new List<ComboBoxItem>();
            var mSavedSettings = UploadFormStates.Load();
            foreach (var mState in mSavedSettings.States)
            {
                mItems.Add(new ComboBoxItem(mState.StateName, mState.StateId));
            }
            return mItems;
        }

        public UploadFormStates AddState(String pName, UploadFormState pState)
        {
            pState.StateName = pName;
            var mCurrentStates = UploadFormStates.Load();
            var mToBeRemoved = new List<UploadFormState>();

            // Identify elements to be removed
            foreach (UploadFormState mState in mCurrentStates.States)
            {
                if (mState.StateName == pName)
                {
                    mToBeRemoved.Add(mState);
                }
            }

            // Remove elements
            foreach (var mState in mToBeRemoved)
            {
                mCurrentStates.States.Remove(mState);
            }

            // Add new element in its place
            mCurrentStates.States.Add(pState);

            // Save changes
            UploadFormStates.Save(mCurrentStates);
            return mCurrentStates;
        }

        public static UploadFormStates RemoveState(string pStateId)
        {

            var mCurrentStates = UploadFormStates.Load();
            var mToBeRemoved = new List<UploadFormState>();

            // Identify elements to be removed
            foreach (UploadFormState mState in mCurrentStates.States)
            {
                if (mState.StateId == pStateId)
                {
                    mToBeRemoved.Add(mState);
                }
            }

            // Remove elements
            foreach (var mState in mToBeRemoved)
            {
                mCurrentStates.States.Remove(mState);
            }

            // Save changes
            UploadFormStates.Save(mCurrentStates);
            return mCurrentStates;
        }

        public static bool Save(UploadFormStates pUploadFormStates)
        {
            Util.SaveResourceFile(UploadFormStates.StateFile, UploadFormStates.Json.Serialize(pUploadFormStates));
            return true;
        }

    }
}