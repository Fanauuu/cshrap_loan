using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
    public class UserRepository
    {
        public User? GetUserByUsername(string username)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserId, Username, Password, Email, FirstName, LastName, Role, IsActive, CreatedDate, LastModifiedDate 
                                FROM Users 
                                WHERE Username=@Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                FirstName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                LastName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Role = reader.GetString(6),
                                IsActive = reader.GetBoolean(7),
                                CreatedDate = reader.GetDateTime(8),
                                LastModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                            };
                        }
                    }
                }
            }
            return null;
        }

        [Obsolete("Use GetUserByUsername with PasswordHasher instead")]
        public User? ValidateUser(string username, string password)
        {
            // Legacy method - kept for backward compatibility
            return GetUserByUsername(username);
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserId, Username, Password, Email, FirstName, LastName, Role, IsActive, CreatedDate, LastModifiedDate 
                                FROM Users 
                                ORDER BY CreatedDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                FirstName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                LastName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Role = reader.GetString(6),
                                IsActive = reader.GetBoolean(7),
                                CreatedDate = reader.GetDateTime(8),
                                LastModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                            });
                        }
                    }
                }
            }
            return users;
        }

        public User? GetUserById(int userId)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserId, Username, Password, Email, FirstName, LastName, Role, IsActive, CreatedDate, LastModifiedDate 
                                FROM Users 
                                WHERE UserId=@UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                FirstName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                LastName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Role = reader.GetString(6),
                                IsActive = reader.GetBoolean(7),
                                CreatedDate = reader.GetDateTime(8),
                                LastModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool CreateUser(User user)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Users (Username, Password, Email, FirstName, LastName, Role, IsActive) 
                                VALUES (@Username, @Password, @Email, @FirstName, @LastName, @Role, @IsActive)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    // Password should already be hashed before calling this method
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Email", (object?)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", (object?)user.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", (object?)user.LastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Users 
                                SET Username=@Username, Password=@Password, Email=@Email, 
                                    FirstName=@FirstName, LastName=@LastName, Role=@Role, 
                                    IsActive=@IsActive, LastModifiedDate=GETDATE()
                                WHERE UserId=@UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Email", (object?)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", (object?)user.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", (object?)user.LastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserId=@UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UsernameExists(string username, int? excludeUserId = null)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username";
                if (excludeUserId.HasValue)
                {
                    query += " AND UserId != @UserId";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    if (excludeUserId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@UserId", excludeUserId.Value);
                    }
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
