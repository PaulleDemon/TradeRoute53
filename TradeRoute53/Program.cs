
using System.Data.SQLite;

namespace TradeRoute53
{   

    public class Controller{

        SQLiteConnection dbConnection;

        Login login;
        SignUp signup;
        Home home;

        class RegistrationPage{

            void display(){
                char choice;

                do{
                    Console.WriteLine("\t\t\t\t a. Login b. SignUp");
                    Console.Write(">");
                    choice = Convert.ToChar(Console.ReadLine()[0]);
                }while(choice != 'a' && choice != 'b');
            
            }

        }

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
            
            while (true){



            }
            
        }

    }

    
    class Program{
    
        public static void Main(string[] args){


            Controller ctrller = new Controller();
            ctrller.start();

        }

    }

}