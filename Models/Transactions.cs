﻿using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models;

public class Transactions
{
    private static string _conString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public static SqlConnection Con = new(_conString);

    public int TransactionId { get; set; }
    public int UserID { get; set; }
    public int ProductId { get; set; }
    public DateTime TransactionDate { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public string ProductName { get; set; }


    // Method to retrieve all orders
    public static List<Transactions> GetAllOrders()
    {
        var transactions = new List<Transactions>();
        var conString = "YourConnectionStringHere";
        using var con = new SqlConnection(_conString);
        const string sql = "SELECT * FROM Transactions";
        var cmd = new SqlCommand(sql, con);

        con.Open();
        var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Console.WriteLine($"UserID from database: {rdr["UserID"]}");

            var transaction = new Transactions
            {
                TransactionId = Convert.ToInt32(rdr["TransactionID"]),
                UserID = Convert.ToInt32(rdr["UserID"]),
                ProductId = Convert.ToInt32(rdr["ProductID"]),
                TransactionDate = Convert.ToDateTime(rdr["TransactionDate"]),
                Quantity = Convert.ToInt32(rdr["Quantity"]),
                TotalAmount = Convert.ToDecimal(rdr["TotalAmount"]),
                ProductName = rdr["ProductName"].ToString()
            };
            transactions.Add(transaction);
        }


        return transactions;
    }
}
