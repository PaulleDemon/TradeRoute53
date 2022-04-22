
using System.Data.SQLite;

namespace TradeRoute53
{   

    
    class Program{

        SQLiteConnection dbConnection;
        

        Program(){
            
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

            Console.WriteLine("Hello world2");

        }

        public static void Main(string[] args){
            
            Console.WriteLine("Hello world");
            
            Program pgm = new Program();

            Login login = new Login();

            login.login();

        }

    }

}