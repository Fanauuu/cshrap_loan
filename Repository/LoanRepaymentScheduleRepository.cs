using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
    public class LoanRepaymentScheduleRepository
    {
        public List<LoanRepaymentSchedule> GetScheduleByLoanContract(int lc)
        {
            List<LoanRepaymentSchedule> schedules = new List<LoanRepaymentSchedule>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT ScheduleID, LC, CID, PaymentDate, DueDate, MonthlyPayment,
                                Principal, Interest, RemainingBalance, Action, PaymentDateActual, CreatedDate
                                FROM LoanRepaymentSchedules
                                WHERE LC = @LC
                                ORDER BY DueDate ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", lc);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new LoanRepaymentSchedule
                            {
                                ScheduleID = reader.GetInt32(0),
                                LC = reader.GetInt32(1),
                                CID = reader.GetInt32(2),
                                PaymentDate = reader.GetDateTime(3),
                                DueDate = reader.GetDateTime(4),
                                MonthlyPayment = reader.GetDecimal(5),
                                Principal = reader.GetDecimal(6),
                                Interest = reader.GetDecimal(7),
                                RemainingBalance = reader.GetDecimal(8),
                                Action = reader.GetString(9),
                                PaymentDateActual = reader.IsDBNull(10) ? null : reader.GetDateTime(10),
                                CreatedDate = reader.GetDateTime(11)
                            });
                        }
                    }
                }
            }
            return schedules;
        }

        public bool CreateRepaymentSchedule(LoanRepaymentSchedule schedule)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO LoanRepaymentSchedules 
                                (LC, CID, PaymentDate, DueDate, MonthlyPayment, Principal, Interest, RemainingBalance, Action) 
                                VALUES (@LC, @CID, @PaymentDate, @DueDate, @MonthlyPayment, @Principal, @Interest, @RemainingBalance, @Action)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", schedule.LC);
                    cmd.Parameters.AddWithValue("@CID", schedule.CID);
                    cmd.Parameters.AddWithValue("@PaymentDate", schedule.PaymentDate);
                    cmd.Parameters.AddWithValue("@DueDate", schedule.DueDate);
                    cmd.Parameters.AddWithValue("@MonthlyPayment", schedule.MonthlyPayment);
                    cmd.Parameters.AddWithValue("@Principal", schedule.Principal);
                    cmd.Parameters.AddWithValue("@Interest", schedule.Interest);
                    cmd.Parameters.AddWithValue("@RemainingBalance", schedule.RemainingBalance);
                    cmd.Parameters.AddWithValue("@Action", schedule.Action);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CreateRepaymentSchedules(List<LoanRepaymentSchedule> schedules)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var schedule in schedules)
                        {
                            string query = @"INSERT INTO LoanRepaymentSchedules 
                                            (LC, CID, PaymentDate, DueDate, MonthlyPayment, Principal, Interest, RemainingBalance, Action) 
                                            VALUES (@LC, @CID, @PaymentDate, @DueDate, @MonthlyPayment, @Principal, @Interest, @RemainingBalance, @Action)";
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@LC", schedule.LC);
                                cmd.Parameters.AddWithValue("@CID", schedule.CID);
                                cmd.Parameters.AddWithValue("@PaymentDate", schedule.PaymentDate);
                                cmd.Parameters.AddWithValue("@DueDate", schedule.DueDate);
                                cmd.Parameters.AddWithValue("@MonthlyPayment", schedule.MonthlyPayment);
                                cmd.Parameters.AddWithValue("@Principal", schedule.Principal);
                                cmd.Parameters.AddWithValue("@Interest", schedule.Interest);
                                cmd.Parameters.AddWithValue("@RemainingBalance", schedule.RemainingBalance);
                                cmd.Parameters.AddWithValue("@Action", schedule.Action);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool MarkPaymentAsPaid(int scheduleID, DateTime paymentDate)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"UPDATE LoanRepaymentSchedules 
                                SET Action='Paid', PaymentDateActual=@PaymentDateActual
                                WHERE ScheduleID=@ScheduleID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
                    cmd.Parameters.AddWithValue("@PaymentDateActual", paymentDate);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteScheduleByLoanContract(int lc)
        {
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM LoanRepaymentSchedules WHERE LC=@LC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", lc);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<LoanRepaymentSchedule> GetAllSchedules()
        {
            List<LoanRepaymentSchedule> schedules = new List<LoanRepaymentSchedule>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT ScheduleID, LC, CID, PaymentDate, DueDate, MonthlyPayment,
                                Principal, Interest, RemainingBalance, Action, PaymentDateActual, CreatedDate
                                FROM LoanRepaymentSchedules
                                ORDER BY DueDate ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new LoanRepaymentSchedule
                            {
                                ScheduleID = reader.GetInt32(0),
                                LC = reader.GetInt32(1),
                                CID = reader.GetInt32(2),
                                PaymentDate = reader.GetDateTime(3),
                                DueDate = reader.GetDateTime(4),
                                MonthlyPayment = reader.GetDecimal(5),
                                Principal = reader.GetDecimal(6),
                                Interest = reader.GetDecimal(7),
                                RemainingBalance = reader.GetDecimal(8),
                                Action = reader.GetString(9),
                                PaymentDateActual = reader.IsDBNull(10) ? null : reader.GetDateTime(10),
                                CreatedDate = reader.GetDateTime(11)
                            });
                        }
                    }
                }
            }
            return schedules;
        }

        public List<LoanRepaymentSchedule> GetOverduePayments(int? lc = null)
        {
            List<LoanRepaymentSchedule> schedules = new List<LoanRepaymentSchedule>();
            using (SqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();
                string query = @"SELECT ScheduleID, LC, CID, PaymentDate, DueDate, MonthlyPayment,
                                Principal, Interest, RemainingBalance, Action, PaymentDateActual, CreatedDate
                                FROM LoanRepaymentSchedules
                                WHERE Action IN ('Unpaid', 'Late') AND DueDate < CAST(GETDATE() AS DATE)";
                
                if (lc.HasValue)
                {
                    query += " AND LC = @LC";
                }
                
                query += " ORDER BY DueDate ASC";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (lc.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@LC", lc.Value);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new LoanRepaymentSchedule
                            {
                                ScheduleID = reader.GetInt32(0),
                                LC = reader.GetInt32(1),
                                CID = reader.GetInt32(2),
                                PaymentDate = reader.GetDateTime(3),
                                DueDate = reader.GetDateTime(4),
                                MonthlyPayment = reader.GetDecimal(5),
                                Principal = reader.GetDecimal(6),
                                Interest = reader.GetDecimal(7),
                                RemainingBalance = reader.GetDecimal(8),
                                Action = reader.GetString(9),
                                PaymentDateActual = reader.IsDBNull(10) ? null : reader.GetDateTime(10),
                                CreatedDate = reader.GetDateTime(11)
                            });
                        }
                    }
                }
            }
            return schedules;
        }
    }
}
