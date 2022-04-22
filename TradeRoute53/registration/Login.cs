using System;
using System.Data.SQLite;


public class Login{

    SQLiteConnection dbConnection;


    struct User{
        public string name;
        public string password;
    }

    protected bool checkUser(string username, string password){

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;");
        dbConnection.Open();

        // dbConnection.

        return false;
    }

    public bool login(){
        
        User usr;

        Console.WriteLine("\n\t\t\t Login");
        
        Console.WriteLine("Username: ");
        usr.name = Console.ReadLine();
        
        Console.WriteLine("Password");
        usr.password = Console.ReadLine();



        return false;
    }

}