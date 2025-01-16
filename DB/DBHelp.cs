using Npgsql;

namespace DB;

public class DBHelp
{
    
    private static string Host = "kandula.db.elephantsql.com";
    private static string User = "vvooypxx";
    private static string DBname = "vvooypxx";
    private static string Password = "SWPqhYQc54Da414vBPGX8Mpsd_0O1f88";
    private static string Port = "5432";
   
   /* 
    private static string Host = "localhost";
    private static string User = "postgres";
    private static string DBname = "smartrooms";
    private static string Password = "";
    private static string Port = "5432";
    */

    public static NpgsqlConnection DBConnection()
    {
        string connString = String.Format(
            "Server={0};Username={1};Database={2};Port={3};Password={4}",
            Host,
            User,
            DBname,
            Port,
            Password);
        NpgsqlConnection conn = new NpgsqlConnection(connString);
        return conn;
    }

}