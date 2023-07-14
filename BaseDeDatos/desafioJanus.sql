
CREATE DATABASE Test;
USE Test;


CREATE TABLE TipoProducto (
    id INT PRIMARY KEY,
    descripcion VARCHAR(255)
);


CREATE TABLE Producto (
    id INT PRIMARY KEY,
    idTipoProducto INT,
    nombre VARCHAR(255),
    precio DECIMAL(10, 2),
    FOREIGN KEY (idTipoProducto) REFERENCES TipoProducto(id)
);


CREATE TABLE Stock (
    id INT PRIMARY KEY,
    idProducto INT,
    cantidad INT,
    FOREIGN KEY (idProducto) REFERENCES Producto(id)
);


CREATE VIEW vw_StockProducto AS
SELECT p.id AS idProducto, p.nombre, s.cantidad
FROM Producto p
JOIN Stock s ON p.id = s.idProducto;


DELIMITER //
CREATE PROCEDURE sp_InsertarProducto(
    IN p_id INT,
    IN p_idTipoProducto INT,
    IN p_nombre VARCHAR(255),
    IN p_precio DECIMAL(10, 2)
)
BEGIN
    INSERT INTO Producto (id, idTipoProducto, nombre, precio)
    VALUES (p_id, p_idTipoProducto, p_nombre, p_precio);
END //


DELIMITER //
CREATE PROCEDURE sp_ModificarProducto(
    IN p_id INT,
    IN p_idTipoProducto INT,
    IN p_nombre VARCHAR(255),
    IN p_precio DECIMAL(10, 2)
)
BEGIN
    UPDATE Producto
    SET idTipoProducto = p_idTipoProducto, nombre = p_nombre, precio = p_precio
    WHERE id = p_id;
END //


DELIMITER //
CREATE PROCEDURE sp_EliminarProducto(
    IN p_id INT
)
BEGIN
    DELETE FROM Producto WHERE id = p_id;
END //
