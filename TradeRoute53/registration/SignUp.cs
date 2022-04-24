using System.Data.SQLite;

public class SignUp{

    SQLiteConnection dbConnection;

    struct User{
        public string name;
        public string password;
    }


    private bool insertUser(string username, string password){
        // checks if the  user name already exists, if it doesn't exist inserts the user 

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.CHECK_USERNAME_AVAILABLE;

        cmd.Parameters.AddWithValue("@username", username);

        cmd.Prepare();

        SQLiteDataReader reader = cmd.ExecuteReader();
        
        reader.Read();

        bool record_exists = reader.GetBoolean(0);
        reader.Close();
        

        if (!record_exists){
            // inserts the user into database if duplicate username doesn't exist
            cmd.CommandText = DBStmts.INSERT_USER;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        dbConnection.Close();

        return !record_exists; // return if the username is available

    }

    public bool signUp(){
        // returns True if signUp is successful, else false indicating that the username is already taken
        
        User usr;

        Console.WriteLine("\n\t\t\t Sign Up");
        
        Console.Write("Username: ");
        usr.name = Console.ReadLine();
        
        Console.Write("Password: ");
        usr.password = Console.ReadLine();

        return insertUser(usr.name, usr.password);
    }

}