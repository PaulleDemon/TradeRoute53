
using System.Data.SQLite;

namespace TradeRoute53
{   

    public class Controller{

        SQLiteConnection dbConnection;

        Login login;
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

        }

        public void start(){

            while (!this.login.login()){
                Console.WriteLine("Invalid credentials Try again");
            };

            this.home = new Home();

        }

    }

    
    class Program{
    
        public static void Main(string[] args){


            Controller ctrller = new Controller();
            ctrller.start();

        }

    }

}