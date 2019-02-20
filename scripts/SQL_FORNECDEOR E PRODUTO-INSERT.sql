USE [db_drvendas]
GO

INSERT INTO [dbo].[Fornecedor]([Apelido],[Nome],[CpfCnpj],[Email],[Endereco],[Bairro],[Cidade],[UF],[CEP])
     VALUES('FORN-A','FORNECEDOR A','86952519000195','fornecedorA@gmail.com','Rua A','Bairro A','Cidade A','BA','41490454')
GO

INSERT INTO [dbo].[Fornecedor]([Apelido],[Nome],[CpfCnpj],[Email],[Endereco],[Bairro],[Cidade],[UF],[CEP])
     VALUES('FORN-B','FORNECEDOR B','34857352052','fornecedorB@gmail.com','Rua B','Bairro B','Cidade B','BA','41490454')
GO

INSERT INTO [dbo].[Fornecedor]([Apelido],[Nome],[CpfCnpj],[Email],[Endereco],[Bairro],[Cidade],[UF],[CEP])
     VALUES('FORN-C','FORNECEDOR C','86952519000195','fornecedorC@gmail.com','Rua C','Bairro C','Cidade C','SP','51490454')
GO

INSERT INTO [dbo].[Fornecedor]([Apelido],[Nome],[CpfCnpj],[Email],[Endereco],[Bairro],[Cidade],[UF],[CEP])
     VALUES('FORN-D','FORNECEDOR D','88585359000119','fornecedorD@gmail.com','Rua D','Bairro D','Cidade D','CE','80490454')
GO

INSERT INTO [dbo].[Fornecedor]([Apelido],[Nome],[CpfCnpj],[Email],[Endereco],[Bairro],[Cidade],[UF],[CEP])
     VALUES('FORN-E','FORNECEDOR E','55009286000168','fornecedorE@gmail.com','Rua E','Bairro E','Cidade E','CE','51490454')
GO

INSERT INTO [dbo].[Cliente]([Apelido],[Nome],[CpfCnpj],[Email],[Endereco],[Bairro],[Cidade],[UF],[CEP])
     VALUES('FORN-F','FORNECEDOR F','12015755000149','fornecedorF@gmail.com','Rua F','Bairro F','Cidade F','CE','80490454')
GO



USE [db_drvendas]
GO

INSERT INTO [dbo].[Produto]  ([Apelido] ,[Nome],[Descricao],[Valor],[Unidade],[FornecedorId])
     VALUES  ('CELJ4','Celular Sunsung J4','Smartphone Samsung Galaxy J4 16GB, Tela 5.5", Dual chip, 4G, Câmera 13MP, Android 8.0, Processador Quad Core e RAM de 2GB - Dourado'
,698.00,'UN',1)
GO

INSERT INTO [dbo].[Produto]  ([Apelido] ,[Nome],[Descricao],[Valor],[Unidade],[FornecedorId])
     VALUES  ('CELJ9','Celular Sunsung J9','Smartphone Samsung Galaxy J4 16GB, Tela 5.5", Dual chip, 4G, Câmera 13MP, Android 8.0, Processador Quad Core e RAM de 2GB - Dourado'
,698.00,'UN',1)
GO

INSERT INTO [dbo].[Produto]  ([Apelido] ,[Nome],[Descricao],[Valor],[Unidade],[FornecedorId])
     VALUES  ('CELMOTO10','Celular MOTOROLA 10','Smartphone SMotorola M10 16GB, Tela 5.5", Dual chip, 4G, Câmera 13MP, Android 8.0, Processador Quad Core e RAM de 2GB - Dourado'
,698.00,'UN',1)
GO

GO
SELECT * FROM CLIENTE 

SELECT * FROM PRODUTO

SELECT * FROM FORNECEDOR

SELECT * FROM ItemPedido

SELECT *  FROM [dbo].[Pedido]

INSERT INTO Pedido VALUES('20190210',NULL,1,'Entrega apenas nas segunda-feira',4000.40)
INSERT INTO Pedido VALUES('20190210',NULL,2,'Entrega apenas nas segunda-feira',4000.40)
INSERT INTO Pedido VALUES('20190215',NULL,3,'Entrega apenas nas segunda-feira',4000.40)
INSERT INTO Pedido VALUES('20190215',NULL,4,'Entrega apenas nas segunda-feira',4000.40)
INSERT INTO Pedido VALUES('20190215',NULL,4,'Entrega apenas nas segunda-feira',4000.40)
INSERT INTO Pedido VALUES('20190215',NULL,3,'Entrega apenas nas segunda-feira',4000.40)


INSERT INTO ItemPedido VALUES (2, 1000,00,1,1)
INSERT INTO ItemPedido VALUES (1, 2000,00,1,2)
INSERT INTO ItemPedido VALUES (1, 2030,00,1,3)

INSERT INTO ItemPedido VALUES (2, 1000,00,2,1)
INSERT INTO ItemPedido VALUES (1, 2000,00,2,2)
INSERT INTO ItemPedido VALUES (1, 2030,00,2,3)

INSERT INTO ItemPedido VALUES (2, 1000,00,3,1)
INSERT INTO ItemPedido VALUES (1, 2000,00,3,2)
INSERT INTO ItemPedido VALUES (1, 2030,00,3,3)

INSERT INTO ItemPedido VALUES (2, 1000,00,4,1)
INSERT INTO ItemPedido VALUES (1, 2000,00,4,2)
INSERT INTO ItemPedido VALUES (1, 2030,00,4,3)

INSERT INTO ItemPedido VALUES (2, 1000,00,5,1)
INSERT INTO ItemPedido VALUES (1, 2000,00,5,2)
INSERT INTO ItemPedido VALUES (1, 2030,00,5,3)

INSERT INTO ItemPedido VALUES (2, 1000,00,6,1)
INSERT INTO ItemPedido VALUES (1, 2000,00,6,2)
INSERT INTO ItemPedido VALUES (1, 2030,00,6,3)
