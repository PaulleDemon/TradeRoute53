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

        SQLiteDataReader reader = cmd.ExecuteReader();

        reader.Read();

        bool record_exists = reader.GetBoolean(0);

        reader.Close();
        dbConnection.Close();

        return record_exists;
    }

    public string login(){
        
        User usr;
        usr.password = String.Empty;

        ConsoleKeyInfo key;

        Console.WriteLine("\n\t\t\t\t\t\t Login");
        
        Console.Write("Username: ");
        usr.name = Console.ReadLine();
        
        Console.Write("Password: ");

        do{
            key = Console.ReadKey(true);

             if (key.Key == ConsoleKey.Backspace && usr.password.Length > 0)
            {
                Console.Write("\b \b");
                usr.password = usr.password[0..^1];
            }
            else if (!char.IsControl(key.KeyChar))
            {
                Console.Write("*");
                usr.password += key.KeyChar;
            }

        }while(key.Key != ConsoleKey.Enter && usr.password.Length < 30);

        if (checkUser(usr.name, usr.password))
            return usr.name;

        return "";
    }

}