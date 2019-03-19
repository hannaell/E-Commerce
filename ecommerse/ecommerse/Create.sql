CREATE TABLE Order_Products (
    products_id int NOT NULL,
    orders_id int NOT NULL
    PRIMARY KEY (orders_id, products_id)  
);

CREATE TABLE Orders (
    id int NOT NULL,
    name varchar(128) NOT NULL,
    CONSTRAINT Orders_pk PRIMARY KEY (id)
);

CREATE TABLE Products (
    id int NOT NULL,
    name varchar(128) NOT NULL,
    description text NOT NULL,
    CONSTRAINT Products_pk PRIMARY KEY (id)
);

ALTER TABLE Order_Products ADD CONSTRAINT Order_Products_Orders FOREIGN KEY Order_Products_Orders (orders_id) 
    REFERENCES Orders (id);

ALTER TABLE Order_Products ADD CONSTRAINT Order_Products_Products FOREIGN KEY Order_Products_Products (products_id)
    REFERENCES Products (id);