namespace PlatinumDriverAutos.Models;
 using MySql.Data.MySqlClient;

    public class Conexao
    {
       
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=platinumdrive;User=root;Password=;Admin";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida com o banco de dados!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar: " + ex.Message);
                }
            }
        }
    }


