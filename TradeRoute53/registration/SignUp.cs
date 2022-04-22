using System.Data.SQLite;

public class SignUp{

    SQLiteConnection dbConnection;

    struct User{
        public string name;
        public string password;
    }


    private bool userExists(string username){
        // checks if the  user name already exists

        return false;
    }

    public bool signUp(){
        // 
        
        User usr;

        Console.WriteLine("\n\t\t\t Login");
        
        Console.WriteLine("Username: ");
        usr.name = Console.ReadLine();
        
        Console.WriteLine("Password");
        usr.password = Console.ReadLine();

        return userExists(usr.name);
    }

}