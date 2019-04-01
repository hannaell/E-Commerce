CREATE TABLE Orders (
    Id int NOT NULL AUTO_INCREMENT,
    Firstname varchar(128) NOT NULL,
    Lastname varchar(128) NOT NULL,
    Adress varchar(128) NOT NULL,
    Zipcode int NOT NULL,
    City text NOT NULL,
    CONSTRAINT Orders_pk PRIMARY KEY (id)
);

CREATE TABLE Products (
    Id int NOT NULL AUTO_INCREMENT,
    Product varchar(128) NOT NULL,
    Description text NOT NULL,
    Price int NOT NULL,
    Quantity int NOT NULL,
    CONSTRAINT Products_pk PRIMARY KEY (id)
);

CREATE TABLE Order_Products (
    products_id int NOT NULL,
    orders_id int NOT NULL,
    PRIMARY KEY (orders_id, products_id),
    
    FOREIGN KEY (products_id) REFERENCES Products(id),
    FOREIGN KEY (orders_id) REFERENCES Orders(id)
);





SELECT Orders.* , Products.* FROM Order_Products
LEFT JOIN Orders ON Order_Products.orders_id = orders_id
LEFT JOIN Products ON Order_Products.products_id = products_id


Img BLOB NOT NULL? i products?
Stock int NOt NULL?