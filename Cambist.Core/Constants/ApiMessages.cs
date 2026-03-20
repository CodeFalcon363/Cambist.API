namespace Cambist.Core.Constants
{
    public static class ApiMessages
    {
        // Success Messages
        public const string ConversionSuccess = "Conversion completed successfully.";
        public const string WatchlistItemAdded = "Watchlist item added.";
        public const string RecordRetrieved = "Record retrieved successfully.";
        public const string RecordsRetrieved = "Records retrieved successfully.";
        public const string RecordDeleted = "Record deleted successfully";

        // Not Found Messages
        public const string CurrencyNotFound = "Currency not found.";
        public const string WatchlistItemNotFound = "Watchlist item not found.";
        public const string RequestNotFound = "Request not found.";

        // Error & Failure Messages
        public const string ExchangeRateFetchFailed = "Failed to fetch exchange rate.";
        public const string InternalError = "An unexpected error occurred. Please try again later.";
        public const string InvalidInput = "The provided input is invalid.";
        public const string Unauthorized = "You are not authorized to perform this action.";
    }
}