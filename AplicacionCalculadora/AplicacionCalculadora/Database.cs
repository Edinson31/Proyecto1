using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AplicacionCalculadora
{
    public static class Database
    {
        // Cambia esto por tu cadena de conexión:
        // Ejemplos:
        // 1) Autenticación integrada: "Server=TU_SERVIDOR;Database=CalculadoraDB;Trusted_Connection=True;"
        // 2) SQL Auth: "Server=TU_SERVIDOR;Database=CalculadoraDB;User Id=usuario;Password=pass;"
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CalculadoraDB;Trusted_Connection=True;";

        public static void SaveCalculation(CalculationRecord rec)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Calculations (Expression, Result, DatePerformed) VALUES (@expr, @res, @date)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@expr", rec.Expression);
                    cmd.Parameters.AddWithValue("@res", rec.Result);
                    cmd.Parameters.AddWithValue("@date", rec.DatePerformed);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<CalculationRecord> GetAllCalculations()
        {
            var list = new List<CalculationRecord>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Expression, Result, DatePerformed FROM Calculations ORDER BY DatePerformed DESC";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new CalculationRecord
                        {
                            Id = r.GetInt32(0),
                            Expression = r.GetString(1),
                            Result = r.GetString(2),
                            DatePerformed = r.GetDateTime(3)
                        });
                    }
                }
            }
            return list;
        }
    }
}

