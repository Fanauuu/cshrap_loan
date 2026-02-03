namespace WinFormsApp1.Utils
{
    /// <summary>
    /// Helper class for consistent icon usage across the application
    /// </summary>
    public static class IconHelper
    {
        // KPI Card Icons
        public const string TotalAmount = "💰";
        public const string TotalContracts = "📋";
        public const string ActiveLoans = "✅";
        public const string TotalCustomers = "👥";
        public const string LatePayments = "⚠️";

        // Menu Icons
        public const string Dashboard = "📊";
        public const string Customers = "👤";
        public const string LoanTerms = "📅";
        public const string LoanContracts = "📋";
        public const string RepaymentSchedule = "💰";
        public const string UserManagement = "👥";
        public const string Logout = "🚪";

        /// <summary>
        /// Gets icon font for consistent rendering
        /// </summary>
        public static System.Drawing.Font GetIconFont(float size = 22F)
        {
            try
            {
                return new System.Drawing.Font("Segoe UI Emoji", size);
            }
            catch
            {
                return new System.Drawing.Font("Segoe UI", size);
            }
        }
    }
}
