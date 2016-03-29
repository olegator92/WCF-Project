using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFScreenTakerApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScreenService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ScreenService.svc or ScreenService.svc.cs at the Solution Explorer and start debugging.
    public class ScreenService : IScreenService
    {
        public void TakeScreen(Byte[] screen, DateTime time, Int32 cursorX, Int32 cursorY)
        {
            string connectionString = @"Data Source=(local);Initial Catalog=ScreensDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Screens VALUES (@screen, @time, @cursorX, @cursorY)";
                command.Parameters.Add("@screen", SqlDbType.Image, 1000000).Value = screen;
                command.Parameters.Add("@time", SqlDbType.DateTime).Value = time;
                command.Parameters.Add("@cursorX", SqlDbType.Int).Value = cursorX;
                command.Parameters.Add("@cursorY", SqlDbType.Int).Value = cursorY;

                command.ExecuteNonQuery();
            }
        }
    }
}
