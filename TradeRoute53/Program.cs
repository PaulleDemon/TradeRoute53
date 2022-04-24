
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
            
            char home_choice = 'a'; 
            string user = "";

            do{ 
                // keep looping until login is successful 
                char choice = registrationPage();
                
                if (choice == 'a'){
                    user = this.login.login();

                    if (user.Equals("")){
                        Console.WriteLine("\nInvalid credentials\n");
                    }
                }

                else{

                    if (!this.signup.signUp()){
                        Console.WriteLine("\nThis user name is taken please try with another name\n");
                    }else{
                        Console.WriteLine("\n Successfully registered please login");
                    }
                }

            }while(user.Equals(""));


            home = new Home();

            do {// Continue asking for input until X is pressed to exit
                
                home.listProduct();
                Console.Write(">");
                home_choice = Convert.ToChar(Console.ReadLine()[0]);

                if (home_choice == 'a'){

                }else if(home_choice == 'b'){
                    home.addProduct(user);

                }else if (home_choice == 'c'){

                }
                else if (home_choice == 'x'){}
                else{
                    Console.WriteLine("Invalid choice");
                }

            }while(home_choice != 'x');


        }

    }

    
    class Program{
    
        public static void Main(string[] args){


            Controller ctrller = new Controller();
            ctrller.start();

        }

    }

}