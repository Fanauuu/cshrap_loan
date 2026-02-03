using Microsoft.Data.SqlClient;

namespace WinFormsApp1.Utils
{
    /// <summary>
    /// Returns user-friendly messages for delete failures (e.g. foreign key constraint) instead of raw DB errors.
    /// </summary>
    public static class DeleteErrorHelper
    {
        /// <summary>
        /// SQL Server error number for foreign key / constraint violation.
        /// </summary>
        private const int SqlForeignKeyViolation = 547;

        /// <summary>
        /// Gets a user-friendly message for a delete exception. Use constraintMessage when the failure is due to references (e.g. FK).
        /// </summary>
        public static string GetMessage(Exception ex, string entityName, string constraintMessage)
        {
            if (ex is SqlException sqlEx && sqlEx.Number == SqlForeignKeyViolation)
                return constraintMessage;
            if (ex.InnerException is SqlException innerSql && innerSql.Number == SqlForeignKeyViolation)
                return constraintMessage;
            if ((ex.Message ?? "").Contains("REFERENCE constraint") || (ex.Message ?? "").Contains("FK_"))
                return constraintMessage;
            return $"Unable to delete this {entityName}. Please try again or contact support.";
        }
    }
}
