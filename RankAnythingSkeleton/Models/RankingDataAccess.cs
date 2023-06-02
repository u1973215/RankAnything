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
            string query = "SELECT * FROM RankingItems ORDER BY VoteCount DESC";
            return connection.Query<RankingItem>(query).AsList();
        }
    }

    public void InsertItem(RankingItem item)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO RankingItems (Name, ImageUrl, VoteCount) VALUES (@Name, @ImageUrl, @VoteCount)";
            connection.Execute(query, item);
        }
    }
}
