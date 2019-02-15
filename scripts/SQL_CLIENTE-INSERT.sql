USE [db_drvendas]
GO

INSERT INTO Cliente
           (Apelido,Nome       ,CpfCnpj          ,Email               ,Endereco,Bairro,Cidade,UF,CEP)
     VALUES
           ('CLI A','CLIENTE A', '14075485000197','clienteA@gmail.com','RUA A','BAIRRO A', 'CIDADE A','BA','40490454')
GO


INSERT INTO Cliente
           (Apelido,Nome       ,CpfCnpj          ,Email               ,Endereco,Bairro,Cidade,UF,CEP)
     VALUES
           ('CLI B','CLIENTE B', '80504219022','clienteB@gmail.com','RUA B','BAIRRO B', 'CIDADE B','SP','50490454')
GO


INSERT INTO Cliente
           (Apelido,Nome       ,CpfCnpj          ,Email               ,Endereco,Bairro,Cidade,UF,CEP)
     VALUES
           ('CLI A3','CLIENTE A3', '95939227090','clienteA3@gmail.com','RUA A3','BAIRRO A3', 'CIDADE A3','RJ','40490454')
GO

INSERT INTO Cliente
           (Apelido,Nome       ,CpfCnpj          ,Email               ,Endereco,Bairro,Cidade,UF,CEP)
     VALUES
           ('CLI A4','CLIENTE A4', '54362534075','clienteA4@gmail.com','RUA A4','BAIRRO A4', 'CIDADE A4','CE','4490454')
GO

INSERT INTO Cliente
           (Apelido,Nome       ,CpfCnpj          ,Email               ,Endereco,Bairro,Cidade,UF,CEP)
     VALUES
           ('CLI A5','CLIENTE A5', '63878463000170','clienteA5@gmail.com','RUA A5','BAIRRO A5', 'CIDADE A5','BA','50490454')
GO



SELECT * FROM cLIENTE;