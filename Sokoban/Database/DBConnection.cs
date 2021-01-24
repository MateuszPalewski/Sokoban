using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class DBConnection
    {
        private SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database\\Database.mdf;Integrated Security=True");
        
        public List<string> selectMapId()
        {
            List<string> result = new List<string>();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlConnection;
                
                sqlcommand.CommandText = "SELECT DISTINCT(mapID) FROM [dbo].[Table] ";

                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((reader.GetInt32(0).ToString()));
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
            }
            return result;
        }


        public List<string> selectMapValues(string mapID)
        {
            List<string> result = new List<string>();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlConnection;

                sqlcommand.CommandText = $"SELECT value FROM [dbo].[Table] WHERE mapID={mapID}";

                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((reader.GetString(0).Trim()));
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
            }
            return result;
        }
    }
}
