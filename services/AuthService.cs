using WinFormsApp1.Models;
using WinFormsApp1.Repository;
using WinFormsApp1.Utils;

namespace WinFormsApp1.services
{
    public class AuthService
    {
        private UserRepository _userRepository;
        
        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        public User? Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null || !user.IsActive)
            {
                return null;
            }

            // Check if password is hashed (BCrypt hashes start with $2a$, $2b$, or $2y$)
            bool isHashed = user.Password.StartsWith("$2a$") || 
                           user.Password.StartsWith("$2b$") || 
                           user.Password.StartsWith("$2y$");

            bool passwordValid = false;

            if (isHashed)
            {
                // Verify password hash
                passwordValid = PasswordHasher.VerifyPassword(password, user.Password);
            }
            else
            {
                // Legacy: plain text password (for backward compatibility)
                passwordValid = user.Password == password;
                
                // Auto-migrate to hashed password if login successful
                if (passwordValid)
                {
                    try
                    {
                        string hashedPassword = PasswordHasher.HashPassword(password);
                        user.Password = hashedPassword;
                        _userRepository.UpdateUser(user);
                    }
                    catch
                    {
                        // If migration fails, still allow login
                    }
                }
            }

            return passwordValid ? user : null;
        }

        public bool IsAdmin(User? user)
        {
            return user != null && user.Role?.ToLower() == "admin";
        }

        public bool IsStaff(User? user)
        {
            // Since we only have admin and user, staff check is same as admin
            return IsAdmin(user);
        }
    }
}
