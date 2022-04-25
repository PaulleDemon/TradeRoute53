
using System.Data.SQLite;

namespace TradeRoute53
{   



    public class Controller{

        SQLiteConnection dbConnection;

        Login login;
        SignUp signup;
        Home home;

        Insert insprd;
        Search srch;
        List lstPrds;
        Stock stk;
        Display dsp;


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
                        Console.WriteLine("\nInvalid credentials. Login again.\n");
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
            insprd = new Insert();
            srch = new Search();
            lstPrds = new List();
            stk = new Stock();
            dsp = new Display();

            // home.listProduct();
            do {// Continue asking for input until X is pressed to exit
                
                Console.WriteLine("\n\t\t\t\t\t\t Home");
                Console.WriteLine("\n\t\ta.list \t b.detail \t c.search \t d.sell \t x.logout & Exit");
                

                Console.Write(">");
                home_choice = Convert.ToChar(Console.ReadLine()[0]);

                // home.listProduct();

                if (home_choice == 'a'){
                    lstPrds.listProduct();

                }else if(home_choice == 'b'){
                    
                    Console.WriteLine("Enter the product id of the Product you want the detail about");
                    Console.Write("\n> ");
                    int product_id = Convert.ToInt32(Console.ReadLine());

                    dsp.displayProductFromId(product_id);

                    Console.WriteLine("\nPress B to buy, Enter any other key to go back");
                    Console.Write("> ");

                    string ch = Console.ReadLine();

                    if (ch.ToLower().Equals("b")){
                        
                        Console.WriteLine("\nPlease enter the shipping address");
                        string shipping_address = Console.ReadLine();
                        
                        Console.WriteLine("\nThank you for purchasing from TradeRoute53");
                        Console.WriteLine($"\nThe Product will arive to \"{shipping_address}\" in 2 days");
                        stk.updateStock(product_id);
                    }

                }else if (home_choice == 'c'){
                    
                    Console.WriteLine("\t\t\t\t Search");
                    Console.Write("\n> ");
                    string search = Console.ReadLine();
                    srch.searchProduct(search);

                }else if(home_choice == 'd'){
                    insprd.addProduct(user);
                }
                else if (home_choice == 'x'){

                    //exits the program do nothing here
                }
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