
using System.Data.SQLite;

namespace TradeRoute53
{   



    public class Controller{

        SQLiteConnection dbConnection;

        Login login;
        SignUp signup;
        Home home;

        public Controller(){
            // create tables in database if it doesn't already exits
            dbConnection = new SQLiteConnection("Data Source=db.sqlite;New=False;");
            dbConnection.Open();

            Console.WriteLine();

            SQLiteCommand cmd = new SQLiteCommand(dbConnection);
            
            cmd.CommandText = DBStmts.CREATE_USER_TABLE;
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = DBStmts.CREATE_PRODUCT_TABLE;
            cmd.ExecuteNonQuery();

            cmd.CommandText = DBStmts.CREATE_CART_TABLE;
            cmd.ExecuteNonQuery();

            dbConnection.Close();

                
            Console.WriteLine("\n\t\t\t\t\t TradeRoute53");
            this.login = new Login();
            this.signup = new SignUp();

        }
        

        private char registrationPage(){
            
            char choice='x';
            Console.WriteLine("\n\t a. Login b. Signup");

            do{
                Console.Write(">");
                choice = Convert.ToChar(Console.ReadLine());
            
            }while(choice != 'a' && choice != 'b');

            return choice;
        }


        public void start(){
            
            
            bool signup_success = false;
            bool login_success = false;

            do{ 
                // keep looping until login is successful 
                char choice = registrationPage();
                
                if (choice == 'a'){
                    login_success = this.login.login();

                    if (!login_success){
                        Console.WriteLine("\nInvalid credentials\n");
                    }
                }

                else{
                    signup_success = this.signup.signUp();

                    if (!signup_success){
                        Console.WriteLine("\nThis user name is taken please try with another name\n");
                    }else{
                        Console.WriteLine("\n Successfully registered please login");
                    }
                }

            }while(!login_success);

            home = new Home();


        }

    }

    
    class Program{
    
        public static void Main(string[] args){


            Controller ctrller = new Controller();
            ctrller.start();

        }

    }

}