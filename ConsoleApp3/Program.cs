using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;

public class MyClass
{
    static string strSql => ConfigurationManager.ConnectionStrings["Default"].ToString();
    static void Select(SqlConnection connection, string select, string table, params string[] colums)
    {
        SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
        DataSet ds = new DataSet();

        adapter.Fill(ds, table);
        foreach (DataRow iter in ds.Tables[0].Rows)
        {
            foreach (string colum in colums)
            {
                Console.Write(iter[colum] + " ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    static void Main()
    {
        try
        {

            using (SqlConnection connection = new SqlConnection(strSql))
            {
                connection.Open();
                Console.WriteLine("Успешное подключение");

                string select;

                select = "select Product.Id, Product.Name, Product.Type, Product.Count, Product.Price, Product.DateOfReceiving, s.Name as 'Storage', p.Name as 'Provider' from Product "
                    + " join Storage s on s.Id = Product.StorageId"
                    + " join Provider p on p.Id = Product.ProviderId";
                Select(connection, select, "Product", "Id", "Name", "Type", "Count", "Price", "DateOfReceiving", "Storage", "Provider");

                select = "select Type from Product";
                Select(connection, select, "Product", "Type");

                select = "select Name from Provider";
                Select(connection, select, "Provider", "Name");

                select = "select Name from Product where Count = (select max(Count) from Product)";
                Select(connection, select, "Provider", "Name");

                select = "select Name from Product where Count = (select min(Count) from Product)";
                Select(connection, select, "Provider", "Name");

                select = "select Name from Product where Price = (select min(Price) from Product)";
                Select(connection, select, "Provider", "Name");

                select = "select Name from Product where Price = (select max(Price) from Product)";
                Select(connection, select, "Provider", "Name");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.ToString());
        }
    }
}