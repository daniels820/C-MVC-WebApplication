using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();


            //var connectionString = @"Data Source=tcp:tky4ecqv9m.database.windows.net,1433;Initial Catalog=AteraDevServerForInterviews;Integrated Security=False;User ID=TestUser69326@tky4ecqv9m;Password=Password69326;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //List<Device> DevicesList = new List<Device>();

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    //
            //    // Open the SqlConnection.
            //    //
            //    con.Open();
            //    //
            //    // The following code uses an SqlCommand based on the SqlConnection.
            //    //
            //    using (SqlCommand command = new SqlCommand( "SELECT DeviceId, Name, OwnerId, Created  FROM Devices", con))
            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {

            //       //     Debug.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
            //            var d = new Device();
            //            d.DeviceId = reader.GetInt32(0);
            //            d.Name = reader.GetString(1);
            //            d.OwnerId = reader.GetInt32(2);
            //            d.Created = reader.GetDateTime(3);
           
            //            DevicesList.Add(d);
            //        }
                   
            //        DevicesList.ForEach(Console.WriteLine);
            //        foreach (object o in DevicesList)
            //        {
            //            Debug.WriteLine("{0 }" , o);
            //        }
            //    }
            //}
            host.Run();
        }
    }
}