using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
    public class LoanTermRepository
    {
        public List<LoanTerm> GetAllLoanTerms()
        {
            List<LoanTerm> terms = new List<LoanTerm>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT TID, Term, AnnualInterestRate, Description, IsActive, CreatedDate 
                                FROM LoanTerms 
                                ORDER BY Term ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            terms.Add(new LoanTerm
                            {
                                TID = reader.GetInt32(0),
                                Term = reader.GetInt32(1),
                                AnnualInterestRate = reader.GetDecimal(2),
                                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                IsActive = reader.GetBoolean(4),
                                CreatedDate = reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }
            return terms;
        }

        public LoanTerm? GetLoanTermById(int tid)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT TID, Term, AnnualInterestRate, Description, IsActive, CreatedDate 
                                FROM LoanTerms 
                                WHERE TID = @TID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TID", tid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LoanTerm
                            {
                                TID = reader.GetInt32(0),
                                Term = reader.GetInt32(1),
                                AnnualInterestRate = reader.GetDecimal(2),
                                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                IsActive = reader.GetBoolean(4),
                                CreatedDate = reader.GetDateTime(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool CreateLoanTerm(LoanTerm term)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO LoanTerms (Term, AnnualInterestRate, Description, IsActive) 
                                VALUES (@Term, @AnnualInterestRate, @Description, @IsActive)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Term", term.Term);
                    cmd.Parameters.AddWithValue("@AnnualInterestRate", term.AnnualInterestRate);
                    cmd.Parameters.AddWithValue("@Description", (object?)term.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", term.IsActive);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateLoanTerm(LoanTerm term)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"UPDATE LoanTerms 
                                SET Term=@Term, AnnualInterestRate=@AnnualInterestRate, 
                                    Description=@Description, IsActive=@IsActive
                                WHERE TID=@TID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TID", term.TID);
                    cmd.Parameters.AddWithValue("@Term", term.Term);
                    cmd.Parameters.AddWithValue("@AnnualInterestRate", term.AnnualInterestRate);
                    cmd.Parameters.AddWithValue("@Description", (object?)term.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", term.IsActive);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteLoanTerm(int tid)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM LoanTerms WHERE TID=@TID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TID", tid);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<LoanTerm> GetActiveLoanTerms()
        {
            List<LoanTerm> terms = new List<LoanTerm>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT TID, Term, AnnualInterestRate, Description, IsActive, CreatedDate 
                                FROM LoanTerms 
                                WHERE IsActive = 1
                                ORDER BY Term ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            terms.Add(new LoanTerm
                            {
                                TID = reader.GetInt32(0),
                                Term = reader.GetInt32(1),
                                AnnualInterestRate = reader.GetDecimal(2),
                                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                IsActive = reader.GetBoolean(4),
                                CreatedDate = reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }
            return terms;
        }
    }
}
