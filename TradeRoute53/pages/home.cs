using System.Data.SQLite;

public class Home{

    SQLiteConnection dbConnection;

    public Home(){
        Console.WriteLine("\n\t\t\t1.search \t 2.cart \t 3.logout");
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
