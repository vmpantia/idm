namespace IDM.Common
{
    public class Constants
    {
        #region Common
        public const string STRING_NA = "N/A";
        #endregion

        #region Formats
        public const string FORMAT_FULL_NAME = "{0}, {1}";
        #endregion

        #region Error Messages
        public const string ERROR_NO_RECORD_FOUND = "No record found in the system.";
        public const string ERROR_CREATING_DATA = "Error in creating data.";
        public const string ERROR_UPDATING_DATA = "Error in updating data.";
        public const string ERROR_DELETING_DATA = "Error in deleting data.";
        #endregion

        #region Status
        public const int STATUS_INT_ENABLED = 0;
        public const int STATUS_INT_DISABLED = 1;
        public const int STATUS_INT_DELETION = 2;

        public const string STATUS_STRING_ENALBED = "enabled";
        public const string STATUS_STRING_DISABLED = "disabled";
        public const string STATUS_STRING_DELETION = "deletion";
        #endregion
    }
}