using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    private readonly DatabaseConfig databaseConfig;

    public DatabaseSetup (DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
        CreateComputerTable();
    }

    private void CreateComputerTable()
    {
        
        var conection = new SqliteConnection("Data Source=database.db");
        conection.Open();

        var command = conection.CreateCommand();
        command.CommandText = @";
        CREATE TABLE IF NOT EXISTS Computers(
            ID int not null primary key,
            ram varchar(100) not null,
            processor varchar(100) not null
        );
        ";
        command.ExecuteNonQuery();

        conection.Close();
    }
}