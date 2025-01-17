DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `SPU_GERARVENDA`(
    IN nr_id_produto INT,
    IN nr_id_cliente INT,
    IN nr_id_status INT
)
BEGIN
    DECLARE nr_estoque_produto INT;
    DECLARE nr_valor_produto DECIMAL(10,2);
    DECLARE nr_id_sale INT;

    SELECT 
        nr_quantidade,
        nr_preco
    INTO
        nr_estoque_produto,
        nr_valor_produto
    FROM TB_PRODUCT
    WHERE pk_id = nr_id_produto;

    IF nr_estoque_produto <= 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Estoque insuficiente';
    END IF;

    START TRANSACTION;

    INSERT INTO TB_SALESRECORD(SaleStatus, ds_valor, fk_seller, dh_inclusao)
    VALUES (nr_id_status, nr_valor_produto, nr_id_cliente, NOW());

    SET nr_id_sale = LAST_INSERT_ID();

    INSERT INTO TB_VENDAPRODUTO(fk_salesrecord, fk_product, Quantity, dh_inclusao)
    VALUES (nr_id_sale, nr_id_produto, 1, NOW());
    
    UPDATE TB_PRODUCT 
    SET nr_quantidade = nr_quantidade - 1 
    WHERE pk_id = nr_id_produto;
    
    COMMIT;
END //

DELIMITER ;