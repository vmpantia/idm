namespace IDM.Common
{
    public class Constants
    {
        public const string NA = "N/A";
        public const string SLASH = "/";
        public const string DASH = "-";

        #region Mail Address

        #region Owner Type
        public const int MAIL_OWNER_TYPE_GROUP = 0;
        #endregion

        #region Primary Flag
        public const int MAIL_FLAG_PRIMARY = 0;
        public const int MAIL_FLAG_SECONDARY = 1;
        #endregion

        #region Mail Type
        public const int MAIL_TYPE_IDM = 0;
        public const int MAIL_TYPE_REGIONAL = 1;
        public const int MAIL_TYPE_COMPANY1 = 2;
        public const int MAIL_TYPE_COMPANY2 = 3;
        #endregion

        #endregion

        #region Status
        public const int STATUS_INT_ENABLED = 0;
        public const int STATUS_INT_DISABLED = 1;
        public const int STATUS_INT_DELETION = 2;
        public const string STATUS_STRING_ENABLED = "Enabled";
        public const string STATUS_STRING_DISABLED = "Disabled";
        public const string STATUS_STRING_DELETION = "Deletion";
        #endregion

        #region Error Messages
        public const int SG_TYPE_INT_INTERNAL = 0;
        public const int SG_TYPE_INT_EXTERNAL = 1;
        public const string SG_TYPE_STRING_INTERNAL = "Internal";
        public const string SG_TYPE_STRING_EXTERNAL = "External";

        public const string FUNCTION_ID_ADD_INTERNAL_SG_BY_USER = "01A01";
        public const string FUNCTION_ID_EDIT_INTERNAL_SG_BY_USER = "01C01";
        public const string FUNCTION_ID_ADD_EXTERNAL_SG_BY_USER = "02A01";
        public const string FUNCTION_ID_EDIT_EXTERNAL_SG_BY_USER = "02C01";

        public const string ERROR_SG_NOT_FOUND = "Security group not found in the database.";
        public const string ERROR_SG_SAVE_REQUEST_NULL = "Save security group request cannot be NULL or EMPTY.";
        public const string ERROR_SG_INSERT = "Error in inserting security group in the database.";
        public const string ERROR_SG_UPDATE = "Error in updating security group in the database.";
        public const string ERROR_SG_NO_CHANGES = "No changes made in security group.";
        public const string ERROR_SG_NAME_INVALID_FOR_INTERNAL = "The {0} is invalid for Internal SG.";
        public const string ERROR_SG_NAME_INVALID_FOR_EXTERNAL = "The {0} is invalid for External SG.";

        public const string ERROR_MAILS_INSERT = "Error in inserting mail addresses in the database.";
        public const string ERROR_MAILS_DELETE = "Error in deleting mail addresses in the database.";

        //Common Error
        public const string ERROR_DATABASE_NOT_FOUND = "Database not found.";
        public const string ERROR_MODEL_NOT_FOUND = "Model not found.";
        public const string ERROR_VALUE_EXIST_DB = "The {0} field is already exist in the database.";
        public const string ERROR_VALUE_EXIST_FORM = "The {0} field is already exist in the form.";
        public const string ERROR_VALUE_NULL = "The {0} field can't be NULL.";

        public const string ATTR_SG_ALIASNAME = "AliasName";
        public const string ATTR_SG_DISPLAYNAME = "DisplayName";
        public const string ATTR_MAILADDRESS = "MailAddress";
        public const string ATTR_PRIMARY_MAIL_ADDRESS = "PrimaryMailAddress";
        #endregion
    }
}