
static class DBStmts{

    public const string CREATE_USER_TABLE = @"CREATE TABLE IF NOT EXISTS users (
                                                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                username VARCHAR(30), 
                                                password VARCHAR(30)
                                                );";
    public const string CREATE_PRODUCT_TABLE = @"CREATE TABLE IF NOT EXISTS products (
                                                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                    name VARCHAR(30), 
                                                    category VARCHAR(30),
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


    // public const string INSERT_USER =   

}