namespace IDM.Common
{
    public class Constants
    {
        public const string NA = "N/A";

        public const int STATUS_INT_ENABLED = 0;
        public const int STATUS_INT_DISABLED = 1;
        public const int STATUS_INT_DELETION = 2;
        public const string STATUS_STRING_ENABLED = "Enabled";
        public const string STATUS_STRING_DISABLED = "Disabled";
        public const string STATUS_STRING_DELETION = "Deletion";

        public const int SG_TYPE_INT_INTERNAL = 0;
        public const int SG_TYPE_INT_EXTERNAL = 1;
        public const string SG_TYPE_STRING_INTERNAL = "Internal";
        public const string SG_TYPE_STRING_EXTERNAL = "External";

        public const string FUNCTION_ID_ADD_INTERNAL_SG_BY_USER = "01A01";
        public const string FUNCTION_ID_EDIT_INTERNAL_SG_BY_USER = "01C01";
        public const string FUNCTION_ID_ADD_EXTERNAL_SG_BY_USER = "02A01";
        public const string FUNCTION_ID_EDIT_EXTERNAL_SG_BY_USER = "02C01";

        public const string ERROR_SG_NOT_FOUND = "Security Group NOT found in the database.";
        public const string ERROR_SG_SAVE_REQUEST_NULL = "Save security group request cannot be NULL or EMPTY.";
        public const string ERROR_SG_INSERT = "Error in inserting security group in the database.";
        public const string ERROR_SG_UPDATE = "Error in updating security group in the database.";
        public const string ERROR_SG_ALIASNAME_EXIST = "Alias Name is already exist in the database.";
        public const string ERROR_SG_DISPLAYNAME_EXIST = "Display Name is already exist in the database.";
        public const string ERROR_NO_DATABASE_FOUND = "No database found.";
    }
}