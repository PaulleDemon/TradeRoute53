using System;


public class Login{

    struct User{
        public string name;
        public string password;
    }

    protected bool checkUser(string username, string password){

        

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