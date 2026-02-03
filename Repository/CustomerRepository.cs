using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
    public class CustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT CID, FirstName, LastName, Gender, PlaceOfBirth, DateOfBirth, 
                                CurrentAddress, Status, CreatedDate, LastModifiedDate 
                                FROM Customers 
                                ORDER BY LastName, FirstName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Gender = reader.GetString(3),
                                PlaceOfBirth = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DateOfBirth = reader.GetDateTime(5),
                                CurrentAddress = reader.GetString(6),
                                Status = reader.GetString(7),
                                CreatedDate = reader.GetDateTime(8),
                                LastModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                            });
                        }
                    }
                }
            }
            return customers;
        }

        public Customer? GetCustomerById(int cid)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT CID, FirstName, LastName, Gender, PlaceOfBirth, DateOfBirth, 
                                CurrentAddress, Status, CreatedDate, LastModifiedDate 
                                FROM Customers 
                                WHERE CID = @CID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CID", cid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Gender = reader.GetString(3),
                                PlaceOfBirth = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DateOfBirth = reader.GetDateTime(5),
                                CurrentAddress = reader.GetString(6),
                                Status = reader.GetString(7),
                                CreatedDate = reader.GetDateTime(8),
                                LastModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool CreateCustomer(Customer customer)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Customers (FirstName, LastName, Gender, PlaceOfBirth, DateOfBirth, CurrentAddress, Status) 
                                VALUES (@FirstName, @LastName, @Gender, @PlaceOfBirth, @DateOfBirth, @CurrentAddress, @Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@PlaceOfBirth", (object?)customer.PlaceOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@CurrentAddress", customer.CurrentAddress);
                    cmd.Parameters.AddWithValue("@Status", customer.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Customers 
                                SET FirstName=@FirstName, LastName=@LastName, Gender=@Gender, 
                                    PlaceOfBirth=@PlaceOfBirth, DateOfBirth=@DateOfBirth, 
                                    CurrentAddress=@CurrentAddress, Status=@Status, 
                                    LastModifiedDate=GETDATE()
                                WHERE CID=@CID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CID", customer.CID);
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    cmd.Parameters.AddWithValue("@PlaceOfBirth", (object?)customer.PlaceOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@CurrentAddress", customer.CurrentAddress);
                    cmd.Parameters.AddWithValue("@Status", customer.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteCustomer(int cid)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Customers WHERE CID=@CID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CID", cid);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Customer> GetActiveCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT CID, FirstName, LastName, Gender, PlaceOfBirth, DateOfBirth, 
                                CurrentAddress, Status, CreatedDate, LastModifiedDate 
                                FROM Customers 
                                WHERE Status = 'Active'
                                ORDER BY LastName, FirstName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Gender = reader.GetString(3),
                                PlaceOfBirth = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DateOfBirth = reader.GetDateTime(5),
                                CurrentAddress = reader.GetString(6),
                                Status = reader.GetString(7),
                                CreatedDate = reader.GetDateTime(8),
                                LastModifiedDate = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                            });
                        }
                    }
                }
            }
            return customers;
        }
    }
}
