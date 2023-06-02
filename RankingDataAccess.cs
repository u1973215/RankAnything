using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Configuration;

public class RankingDataAccess
{
    private readonly string connectionString;

    public RankingDataAccess()
    {
        // Retrieve the connection string from the configuration
        connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }

    public List<RankingItem> GetAllItems()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM RankingItems";
            return connection.Query<RankingItem>(query).AsList();
        }
    }

    public void InsertItem(RankingItem item)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO RankingItems (Name, ImageUrl) VALUES (@Name, @ImageUrl)";
            connection.Execute(query, item);
        }
    }
}
