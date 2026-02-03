using WinFormsApp1.Utils;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;

namespace WinFormsApp1
{
    /// <summary>
    /// Tool to migrate existing plain-text passwords to BCrypt hashes
    /// Run this once after deploying password hashing
    /// </summary>
    public static class PasswordMigrationTool
    {
        /// <summary>
        /// Migrates a specific user's password to BCrypt hash
        /// </summary>
        public static void MigrateUserPassword(string username, string plainPassword)
        {
            string hash = PasswordHasher.HashPassword(plainPassword);
            
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Password = @Password WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hash);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Migrates default admin password
        /// Call this once: PasswordMigrationTool.MigrateDefaultAdmin();
        /// </summary>
        public static void MigrateDefaultAdmin()
        {
            MigrateUserPassword("admin", "admin123");
        }
    }
}
