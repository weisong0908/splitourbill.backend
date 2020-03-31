namespace splitourbill_backend.Utils
{
    public static class Constants
    {
        public static class Database
        {
            public const string UserTable = "users";
            public const string FriendshipTable = "friendships";
            public const string BillPurposeTable = "bill_purposes";
            public const string BillTable = "bills";
            public const string BillSharingTable = "bill_sharings";
            public const string Schema = "backend";
        }

        public static class RelationshipStatuses
        {
            public const string Accepted = "accepted";
            public const string Requested = "requested";
        }
    }
}