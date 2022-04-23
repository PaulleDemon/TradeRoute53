using System;
using System.Data;
using System.Data.SQLite;


public class Login{

    SQLiteConnection dbConnection;

    struct User{
        public string name;
        public string password;
    }

    protected bool checkUser(string username, string password){
        
        // returns if a user exists

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.CHECK_USER_EXIST;

        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);

        cmd.Prepare();
        Console.WriteLine(username+":"+password);

        SQLiteDataReader reader = cmd.ExecuteReader();

        reader.Read();
        // string exists = cmd.ExecuteScalar().ToString();

        // Console.WriteLine("GU: "+reader.GetBoolean(0));

        bool record_exists = reader.GetBoolean(0);

        dbConnection.Close();

        return record_exists;
    }

    public bool login(){
        
        User usr;

        Console.WriteLine("\n\t\t\t Login");
        
        Console.WriteLine("Username: ");
        usr.name = Console.ReadLine();
        
        Console.WriteLine("Password");
        usr.password = Console.ReadLine();


        Console.WriteLine(checkUser(usr.name, usr.password));

        return false;
    }

}