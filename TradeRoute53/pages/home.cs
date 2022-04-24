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
        Console.WriteLine("\n\t\t\ta.list \t b.Search \t c.Sell \t d.Cart \t x.logout");
    }

    public void addProduct(string user){
        
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

        int user_id = -1;

        using(dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;")){

            dbConnection.Open();

            using(SQLiteCommand cmd = new SQLiteCommand(dbConnection)){

                cmd.CommandText = DBStmts.GET_USER_FROM_NAME;
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Prepare();
                
                using (SQLiteDataReader reader = cmd.ExecuteReader()){

                    reader.Read();
                    user_id = reader.GetInt32(0);

                }
            }

            using(SQLiteCommand cmd = new SQLiteCommand(dbConnection)){

                cmd.CommandText = DBStmts.INSERT_PRODUCT;

                cmd.Parameters.AddWithValue("@name", prod.name);
                cmd.Parameters.AddWithValue("@about", prod.about);
                cmd.Parameters.AddWithValue("@category", prod.category);
                cmd.Parameters.AddWithValue("@price", prod.price);
                cmd.Parameters.AddWithValue("@user", user_id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }


            

        }

    }

    public void searchProduct(string search){

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.SEARCH_PRODUCT;
        cmd.Parameters.AddWithValue("@productname", search);

        cmd.ExecuteNonQuery();


        SQLiteDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Products: ");

        while (reader.Read()){
            Console.WriteLine($"id: {reader.GetInt32(0)}");
            Console.WriteLine($"product: {reader.GetString(1)}");
            Console.WriteLine($"Price: {reader.GetFloat(4)}");
        }

        reader.Close();

        dbConnection.Close();

    }

    public void listProduct(){

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.LIST_PRODUCT;

        cmd.ExecuteNonQuery();


        SQLiteDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Products: ");

        while (reader.Read()){
            Console.WriteLine($"id: {reader.GetInt32(0)}");
            Console.WriteLine($"product: {reader.GetString(1)}");
            Console.WriteLine($"Price: {reader.GetFloat(4)}");
        }

        reader.Close();

        dbConnection.Close();


    }

    public void displayProductFromId(int id){

        dbConnection = new SQLiteConnection("Data Source=./db.sqlite;Version=3;New=False;");
        dbConnection.Open();

        SQLiteCommand cmd = new SQLiteCommand(dbConnection);
        cmd.CommandText = DBStmts.PRODUCT_FROM_ID;
        cmd.Parameters.AddWithValue("@productid", id);
        
        cmd.ExecuteNonQuery();


        SQLiteDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Products: ");

        while (reader.Read()){
            Console.WriteLine($"id: {reader.GetInt32(0)}");
            Console.WriteLine($"product: {reader.GetString(1)}");
            Console.WriteLine($"about: {reader.GetString(2)}");
            Console.WriteLine($"product: {reader.GetString(3)}");
            Console.WriteLine($"Price: {reader.GetFloat(4)}");
            Console.WriteLine($"seller: {reader.GetString(4)}");
        }

        reader.Close();

        dbConnection.Close();


    }

}
