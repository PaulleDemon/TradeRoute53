using System.Data.SQLite;

public class Home{

    SQLiteConnection dbConnection;

    struct Product{
        public string name;
        public string category;
        public string about;
        public float price;

    }

    public Home(){
        display();
    }

    public void display(){
        Console.WriteLine("\n\t\t\t\t\t\t Home");
        Console.WriteLine("\n\t\t\t1.search \t 2.Sell \t 3.Cart \t 4.logout");
    }

    public void addProduct(int user_id){
        
        Product prod;

        Console.WriteLine("\n\t\t\t\t\t\tSell product");

        Console.Write("\n productname: ");
        prod.name = Console.ReadLine();

        Console.Write("\n category: ");
        prod.category = Console.ReadLine();

        Console.Write("\n about: ");
        prod.about = Console.ReadLine();

        Console.Write("\n price: ");
        prod.price = Convert.ToInt32(Console.ReadLine());

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.INSERT_PRODUCT;

        cmd.Parameters.AddWithValue("@name", prod.name);
        cmd.Parameters.AddWithValue("@about", prod.about);
        cmd.Parameters.AddWithValue("@category", prod.category);
        cmd.Parameters.AddWithValue("@price", prod.price);
        cmd.Parameters.AddWithValue("@name", user_id);

        cmd.Prepare();

        cmd.ExecuteNonQuery();

        dbConnection.Close();

    }

    public void listProduct(){

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.CHECK_USER_EXIST;

        cmd.ExecuteNonQuery();


        SQLiteDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Products: ");

        while (reader.Read()){
            Console.WriteLine(@$"Product: {reader.GetString(1)}
                                 about: {reader.GetString(3)}
            ");
        }

        dbConnection.Close();


    }

}
