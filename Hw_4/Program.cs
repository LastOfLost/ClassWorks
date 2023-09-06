using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;

internal class Program
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();


    static async Task Main(string[] args)
    {
        try
        {
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
            DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");

            await ReadDataAsync(factory, "select * from vegetablesandfruits", await GetColumNames(factory, "VegetablesAndFruits"));

            await ComandDataAsync(factory, "delete from VegetablesAndFruits");
            await ComandDataAsync(factory, "insert into vegetablesandfruits values ('Яблоко', 'фрукт', 'красный', 52)");
            await ComandDataAsync(factory, "insert into vegetablesandfruits values ('Брокколи', 'овощ', 'зелений', 55)");
            await ComandDataAsync(factory, "insert into vegetablesandfruits values ('Апельсин', 'фрукт', 'оранжевый', 43)");
            await ComandDataAsync(factory, "insert into vegetablesandfruits values ('Морковь', 'овощ', 'оранжевый', 41)");
            await ComandDataAsync(factory, "insert into vegetablesandfruits values ('Морковь2', 'овощ', 'оранжевый', 41)");

            await ComandDataAsync(factory, "update vegetablesandfruits set Name = 'Клубника', Type = 'фрукт', Color = 'красный' where Name = 'Морковь2'");

            await ComandDataAsync(factory, "delete from vegetablesandfruits where Name = 'Брокколи'");

            await ReadDataAsync(factory, "select * from vegetablesandfruits", await GetColumNames(factory, "VegetablesAndFruits"));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    
    private static async Task ReadDataAsync(DbProviderFactory factory, string readCommand, params string[] columns)
    {
        DateTime time = DateTime.Now;
        using (DbConnection connection = factory.CreateConnection())
        {
            connection.ConnectionString = connectionString;

            await connection.OpenAsync();

            using (DbCommand command = factory.CreateCommand())
            {

                command.Connection = connection;
                command.CommandText = readCommand;

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (var column in columns)
                        {
                            Console.Write(reader[column] + " | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n");
                }
            }
        }

        Console.WriteLine($"Reading: {TimeSpan.FromTicks(DateTime.Now.Ticks - time.Ticks).TotalSeconds} sec");
    }
    private static async Task ComandDataAsync(DbProviderFactory factory, string myCommand)
    {
        DateTime time = DateTime.Now;
        using (DbConnection connection = factory.CreateConnection())
        {
            connection.ConnectionString = connectionString;

            await connection.OpenAsync();

            using (DbCommand command = factory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = myCommand;

                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine($"Command ({myCommand.Substring(0, myCommand.IndexOf(' '))}): {TimeSpan.FromTicks(DateTime.Now.Ticks - time.Ticks).TotalSeconds} sec");
    }
    static async Task<string[]> GetColumNames(DbProviderFactory factory, string table)
    {
        DbConnection connection = factory.CreateConnection();
        connection.ConnectionString = connectionString;
        await connection.OpenAsync();
        return connection.GetSchema("Columns", new string[] { null, null, table })
            .AsEnumerable().Select(dr => $"{dr["COLUMN_NAME"]}").ToArray();
    }
}