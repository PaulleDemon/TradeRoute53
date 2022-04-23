/*
* This file contains all the sql statements to create, update and insert data. 
*
*/

static class DBStmts{

    public const string CREATE_USER_TABLE = @"CREATE TABLE IF NOT EXISTS users (
                                                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                username VARCHAR(30) UNIQUE, 
                                                password VARCHAR(30)
                                                );";
    public const string CREATE_PRODUCT_TABLE = @"CREATE TABLE IF NOT EXISTS products (
                                                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                    name VARCHAR(30), 
                                                    category VARCHAR(30),
                                                    about VARCHAR(100),
                                                    price REAL,
                                                    user_id INTEGER,
                                                    CONSTRAINT fk_user
                                                        FOREIGN KEY (user_id)
                                                        REFERENCES users(id)
                                                );";
    public const string CREATE_CART_TABLE = @"CREATE TABLE IF NOT EXISTS cart (
                                                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                    product_id INTEGER, 
                                                    user_id INTEGER,
                                                    CONSTRAINT fk_product
                                                        FOREIGN KEY (product_id)
                                                        REFERENCES products(id),
                                                    CONSTRAINT fk_user
                                                        FOREIGN KEY (user_id)
                                                        REFERENCES users(id)
                                                    );";

    public const string INSERT_USER = @"INSERT INTO users (username, password) 
                                          VALUES (@username, @password);";

    // check the login credentials
    public const string CHECK_USER_EXIST = @"SELECT EXISTS(
                                            SELECT 1 FROM users WHERE 
                                            username=@username AND password=@password);";

    // Check if the username is available
    public const string CHECK_USERNAME_AVAILABLE = @"SELECT EXISTS(SELECT 1 From users WHERE username=@username);"; 

    public const string LIST_PRODUCT = @"SELECT * FROM products;";

    public const string SEARCH_PRODUCT = @"SELECT * from products WHERE name LIKE @name%";

    public const string INSERT_PRODUCT = @"INSERT INTO products(name, category, about, price, user_id) 
                                                VALUES(@name, @category, @about, @price, @user);";
}