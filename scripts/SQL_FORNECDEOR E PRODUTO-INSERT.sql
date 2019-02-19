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
