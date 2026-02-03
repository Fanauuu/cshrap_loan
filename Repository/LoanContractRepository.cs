using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
    public class LoanContractRepository
    {
        public List<LoanContract> GetAllLoanContracts()
        {
            List<LoanContract> contracts = new List<LoanContract>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT lc.LC, lc.CID, lc.LoanAmount, lc.TermID, lc.MonthlyInterest, 
                                lc.LoanDate, lc.StartPaymentDate, lc.ServicePayment, lc.Status, 
                                lc.ScheduleStatus, lc.CreatedDate, lc.LastModifiedDate,
                                c.FirstName + ' ' + c.LastName AS CustomerName,
                                lt.Term AS TermMonths
                                FROM LoanContracts lc
                                INNER JOIN Customers c ON lc.CID = c.CID
                                INNER JOIN LoanTerms lt ON lc.TermID = lt.TID
                                ORDER BY lc.LoanDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contracts.Add(new LoanContract
                            {
                                LC = reader.GetInt32(0),
                                CID = reader.GetInt32(1),
                                LoanAmount = reader.GetDecimal(2),
                                TermID = reader.GetInt32(3),
                                MonthlyInterest = reader.GetDecimal(4),
                                LoanDate = reader.GetDateTime(5),
                                StartPaymentDate = reader.GetDateTime(6),
                                ServicePayment = reader.GetDecimal(7),
                                Status = reader.GetString(8),
                                ScheduleStatus = reader.GetString(9),
                                CreatedDate = reader.GetDateTime(10),
                                LastModifiedDate = reader.IsDBNull(11) ? null : reader.GetDateTime(11),
                                CustomerName = reader.GetString(12),
                                TermMonths = reader.GetInt32(13)
                            });
                        }
                    }
                }
            }
            return contracts;
        }

        public LoanContract? GetLoanContractById(int lc)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT lc.LC, lc.CID, lc.LoanAmount, lc.TermID, lc.MonthlyInterest, 
                                lc.LoanDate, lc.StartPaymentDate, lc.ServicePayment, lc.Status, 
                                lc.ScheduleStatus, lc.CreatedDate, lc.LastModifiedDate,
                                c.FirstName + ' ' + c.LastName AS CustomerName,
                                lt.Term AS TermMonths
                                FROM LoanContracts lc
                                INNER JOIN Customers c ON lc.CID = c.CID
                                INNER JOIN LoanTerms lt ON lc.TermID = lt.TID
                                WHERE lc.LC = @LC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", lc);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LoanContract
                            {
                                LC = reader.GetInt32(0),
                                CID = reader.GetInt32(1),
                                LoanAmount = reader.GetDecimal(2),
                                TermID = reader.GetInt32(3),
                                MonthlyInterest = reader.GetDecimal(4),
                                LoanDate = reader.GetDateTime(5),
                                StartPaymentDate = reader.GetDateTime(6),
                                ServicePayment = reader.GetDecimal(7),
                                Status = reader.GetString(8),
                                ScheduleStatus = reader.GetString(9),
                                CreatedDate = reader.GetDateTime(10),
                                LastModifiedDate = reader.IsDBNull(11) ? null : reader.GetDateTime(11),
                                CustomerName = reader.GetString(12),
                                TermMonths = reader.GetInt32(13)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int CreateLoanContract(LoanContract contract)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO LoanContracts (CID, LoanAmount, TermID, MonthlyInterest, 
                                LoanDate, StartPaymentDate, ServicePayment, Status, ScheduleStatus) 
                                OUTPUT INSERTED.LC
                                VALUES (@CID, @LoanAmount, @TermID, @MonthlyInterest, 
                                @LoanDate, @StartPaymentDate, @ServicePayment, @Status, @ScheduleStatus)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CID", contract.CID);
                    cmd.Parameters.AddWithValue("@LoanAmount", contract.LoanAmount);
                    cmd.Parameters.AddWithValue("@TermID", contract.TermID);
                    cmd.Parameters.AddWithValue("@MonthlyInterest", contract.MonthlyInterest);
                    cmd.Parameters.AddWithValue("@LoanDate", contract.LoanDate);
                    cmd.Parameters.AddWithValue("@StartPaymentDate", contract.StartPaymentDate);
                    cmd.Parameters.AddWithValue("@ServicePayment", contract.ServicePayment);
                    cmd.Parameters.AddWithValue("@Status", contract.Status);
                    cmd.Parameters.AddWithValue("@ScheduleStatus", contract.ScheduleStatus);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public bool UpdateLoanContract(LoanContract contract)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"UPDATE LoanContracts 
                                SET CID=@CID, LoanAmount=@LoanAmount, TermID=@TermID, 
                                    MonthlyInterest=@MonthlyInterest, LoanDate=@LoanDate, 
                                    StartPaymentDate=@StartPaymentDate, ServicePayment=@ServicePayment, 
                                    Status=@Status, ScheduleStatus=@ScheduleStatus, 
                                    LastModifiedDate=GETDATE()
                                WHERE LC=@LC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", contract.LC);
                    cmd.Parameters.AddWithValue("@CID", contract.CID);
                    cmd.Parameters.AddWithValue("@LoanAmount", contract.LoanAmount);
                    cmd.Parameters.AddWithValue("@TermID", contract.TermID);
                    cmd.Parameters.AddWithValue("@MonthlyInterest", contract.MonthlyInterest);
                    cmd.Parameters.AddWithValue("@LoanDate", contract.LoanDate);
                    cmd.Parameters.AddWithValue("@StartPaymentDate", contract.StartPaymentDate);
                    cmd.Parameters.AddWithValue("@ServicePayment", contract.ServicePayment);
                    cmd.Parameters.AddWithValue("@Status", contract.Status);
                    cmd.Parameters.AddWithValue("@ScheduleStatus", contract.ScheduleStatus);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateLoanContractStatus(int lc, string status)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"UPDATE LoanContracts 
                                SET Status=@Status, LastModifiedDate=GETDATE()
                                WHERE LC=@LC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", lc);
                    cmd.Parameters.AddWithValue("@Status", status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<LoanContract> GetActiveLoanContracts()
        {
            List<LoanContract> contracts = new List<LoanContract>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT lc.LC, lc.CID, lc.LoanAmount, lc.TermID, lc.MonthlyInterest, 
                                lc.LoanDate, lc.StartPaymentDate, lc.ServicePayment, lc.Status, 
                                lc.ScheduleStatus, lc.CreatedDate, lc.LastModifiedDate,
                                c.FirstName + ' ' + c.LastName AS CustomerName,
                                lt.Term AS TermMonths
                                FROM LoanContracts lc
                                INNER JOIN Customers c ON lc.CID = c.CID
                                INNER JOIN LoanTerms lt ON lc.TermID = lt.TID
                                WHERE lc.Status = 'Active'
                                ORDER BY lc.LoanDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contracts.Add(new LoanContract
                            {
                                LC = reader.GetInt32(0),
                                CID = reader.GetInt32(1),
                                LoanAmount = reader.GetDecimal(2),
                                TermID = reader.GetInt32(3),
                                MonthlyInterest = reader.GetDecimal(4),
                                LoanDate = reader.GetDateTime(5),
                                StartPaymentDate = reader.GetDateTime(6),
                                ServicePayment = reader.GetDecimal(7),
                                Status = reader.GetString(8),
                                ScheduleStatus = reader.GetString(9),
                                CreatedDate = reader.GetDateTime(10),
                                LastModifiedDate = reader.IsDBNull(11) ? null : reader.GetDateTime(11),
                                CustomerName = reader.GetString(12),
                                TermMonths = reader.GetInt32(13)
                            });
                        }
                    }
                }
            }
            return contracts;
        }
    }
}
