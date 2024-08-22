namespace AuctionApp.Constants
{
    public static class GeneralConstants

    {
#if ANDROID || IOS
        public const string SERVER_URL = @"http://10.0.2.2:8000";
#else 
        public const string SERVER_URL = @"http://localhost:8000";
#endif
        public const string PWD_STORAGE_KEY = "pwd";
        public const string EMAIL_STORAGE_KEY = "email";
    }
}
