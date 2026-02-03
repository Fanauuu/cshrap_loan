using BCrypt.Net;

namespace WinFormsApp1.Utils
{
    /// <summary>
    /// Password hashing utility using BCrypt
    /// Provides secure password hashing and verification
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes a password using BCrypt
        /// </summary>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        /// <summary>
        /// Verifies a password against a hash
        /// </summary>
        public static bool VerifyPassword(string password, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}
