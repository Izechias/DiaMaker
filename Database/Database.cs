using System;
using System.Data.SqlClient;
using System.IO;

namespace DiaMaker.Sql
{
  public class Database
  {
    protected SqlConnection _sqlConnection;
    private string _connectionString;
    private string _logFilePath;
    public bool Connected {get; private set;}

    public Database(string connectionString)
    {
     _connectionString = connectionString;
     _sqlConnection = new SqlConnection(_connectionString);
     _logFilePath = "OdbcLog.txt" ;
     CreateLog();
     Connect();
    }

    ~Database()
    {
      Disconnect();
    }

    private void Connect()
    {
      try
      {
        _sqlConnection.Open();
        Connected = true;
        LogMessage("Successfuly connected to database", "DEBUG");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(String.Format("Error: {0}\n", ex.Message));
        LogMessage(ex.Message, "ERROR");
      }
    }

    private void Disconnect()
    {
      _sqlConnection.Close();
      LogMessage("Disconnected from the database", "DEBUG");
    }

    private void LogMessage(string message, string severity)
    {
      Console.WriteLine("[{0}][{1}] {2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), severity, message);
    }

    private void CreateLog()
    {
      LogMessage(String.Format("Connecting to databse using connection string \"{0}\"", _connectionString), "NOTICE");
    }
  }
}