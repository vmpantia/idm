namespace IDM.Common
{
    public class Constants
    {
        public const string NA = "N/A";
        public const string SLASH = "/";
        public const string DASH = "-";
        public const int ZERO = 0;
        public const int DELAY_PROCESS = 500;

        #region Status
        public const int STATUS_INT_ENABLED = 0;
        public const int STATUS_INT_DISABLED = 1;
        public const int STATUS_INT_DELETION = 2;
        public const string STATUS_STRING_ENABLED = "Enabled";
        public const string STATUS_STRING_DISABLED = "Disabled";
        public const string STATUS_STRING_DELETION = "Deletion";
        #endregion

        #region Type
        public const int SG_TYPE_INT_INTERNAL = 0;
        public const int SG_TYPE_INT_EXTERNAL = 1;
        public const string SG_TYPE_STRING_INTERNAL = "Internal";
        public const string SG_TYPE_STRING_EXTERNAL = "External";
        #endregion

        #region Mail Address

        #region Domain
        public const string DOMAIN_IDM = "@idm.com";
        public const string DOMAIN_PH_IDM = "@ph.idm.com";
        #endregion

        #region Owner Type
        public const int MAIL_OWNER_TYPE_GROUP = 0;
        #endregion

        #region Primary Flag
        public const int MAIL_FLAG_INT_PRIMARY = 0;
        public const int MAIL_FLAG_INT_SECONDARY = 1;
        public const string MAIL_FLAG_STRING_PRIMARY = "Primary";
        public const string MAIL_FLAG_STRING_SECONDARY = "Secondary";
        #endregion

        #region Mail Type
        public const int MAIL_TYPE_INT_IDM = 0;
        public const int MAIL_TYPE_INT_REGIONAL = 1;
        public const int MAIL_TYPE_INT_COMPANY1 = 2;
        public const int MAIL_TYPE_INT_COMPANY2 = 3;
        public const string MAIL_TYPE_STRING_IDM = "IDM Mail Address";
        public const string MAIL_TYPE_STRING_REGIONAL = "Regional Mail Address";
        public const string MAIL_TYPE_STRING_COMPANY1 = "Company Mail Address 1";
        public const string MAIL_TYPE_STRING_COMPANY2 = "Company Mail Address 2";
        #endregion

        #endregion

        #region Error Messages
        public const string FUNCTION_ID_ADD_INTERNAL_SG_BY_USER = "01A01";
        public const string FUNCTION_ID_EDIT_INTERNAL_SG_BY_USER = "01C01";
        public const string FUNCTION_ID_ADD_EXTERNAL_SG_BY_USER = "02A01";
        public const string FUNCTION_ID_EDIT_EXTERNAL_SG_BY_USER = "02C01";

        public const string ERROR_SG_SAVE_REQUEST_NULL = "Save security group request cannot be NULL or EMPTY.";
        public const string ERROR_SG_INSERT = "Error in inserting security group in the database.";
        public const string ERROR_SG_UPDATE = "Error in updating security group in the database.";
        public const string ERROR_SG_NAME_INVALID_FOR_INTERNAL = "The {0} is invalid for Internal SG.";
        public const string ERROR_SG_NAME_INVALID_FOR_EXTERNAL = "The {0} is invalid for External SG.";

        public const string ERROR_EMAILS_INSERT = "Error in inserting mail addresses in the database.";
        public const string ERROR_EMAILS_DELETE = "Error in deleting mail addresses in the database.";

        //Common Error
        public const string ERROR_MODEL_NOT_FOUND = "{0} model not found.";
        public const string ERROR_VALUE_EXIST_DB = "{0} is already exist in the database.";
        public const string ERROR_VALUE_NOT_FOUND_DB = "{0} not found in the database.";
        public const string ERROR_NO_CHANGES_MADE = "No changes made in {0}.";
        #endregion

        #region Properties
        public const string PROPERTY_SG_ALIASNAME = "AliasName";
        public const string PROPERTY_SG_DISPLAYNAME = "DisplayName";

        public const string PROPERTY_EMAIL_ADDRESS = "EmailAddress";
        public const string PROPERTY_PRIMARY_EMAIL_ADDRESS = "PrimaryEmailAddress";
        public const string PROPERTY_IDM_EMAIL_ADDRESS = "IDMEmailAddress";
        public const string PROPERTY_REG_EMAIL_ADDRESS = "RegionalEmailAddress";
        public const string PROPERTY_COMP1_EMAIL_ADDRESS = "CompanyEmailAddress1";
        public const string PROPERTY_COMP2_EMAIL_ADDRESS = "CompanyEmailAddress2";
        #endregion
    }
}