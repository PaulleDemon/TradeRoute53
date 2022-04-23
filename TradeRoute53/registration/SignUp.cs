using System.Data.SQLite;

public class SignUp{

    SQLiteConnection dbConnection;

    struct User{
        public string name;
        public string password;
    }


    private bool checkUserExists(string username){
        // checks if the  user name already exists

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.CHECK_USER_EXIST;

        cmd.Parameters.AddWithValue("@username", username);

        cmd.Prepare();

        SQLiteDataReader reader = cmd.ExecuteReader();
        
        reader.Read();

        bool record_exists = reader.GetBoolean(0);

        dbConnection.Close();

        return record_exists;

    }

    public bool signUp(){
        // 
        
        User usr;

        Console.WriteLine("\n\t\t\t Login");
        
        Console.WriteLine("Username: ");
        usr.name = Console.ReadLine();
        
        Console.WriteLine("Password");
        usr.password = Console.ReadLine();

        return checkUserExists(usr.name);
    }

}