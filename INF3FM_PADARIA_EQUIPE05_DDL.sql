/*INF3FM 
PADARIA ALAMEDA 
 
EQUIPE N° 05 
 
Gabriel Victor Valdivia N° 10
Guilherme Horta dos Santos N° 15 
Lucas Moura Silva Nº 26 
Mateus Alípio dos Santos Silva Nº 27 
*/

USE MASTER
GO

--DROP DATABASE Projeto
--GO
drop database Projeto


CREATE DATABASE Projeto
GO

USE Projeto
GO

CREATE TABLE cliente_WEB (
IDcliente INTEGER IDENTITY(1,1) PRIMARY KEY NOT NULL ,
Nome VARCHAR(100)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(100),
Sexo VARCHAR(10)NOT NULL,
DataNascimento DATE NOT NULL,
CEP CHAR(8)NOT NULL,
Logradouro VARCHAR(100)NOT NULL,
Cidade VARCHAR(50)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(50)NOT NULL,
Numero VARCHAR(10) NOT NULL,
RG VARCHAR(20) NOT NULL,
CPF VARCHAR(14) unique NOT NULL,
Complemento VARCHAR(100) NULL,
senha nvarchar(20)
)
GO

CREATE TABLE cliente (
IDcliente INTEGER IDENTITY(1,1) PRIMARY KEY NOT NULL ,
Nome VARCHAR(100)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(100),
Sexo VARCHAR(10)NOT NULL,
DataNascimento DATE NOT NULL,
CEP CHAR(8)NOT NULL,
Logradouro VARCHAR(100)NOT NULL,
Cidade VARCHAR(50)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(50)NOT NULL,
Numero VARCHAR(10) NOT NULL,
RG VARCHAR(20) NOT NULL,
CPF VARCHAR(14) unique NOT NULL,
Complemento VARCHAR(100) NULL
)
GO

-- INSERIR CLIENTE BALCÃO
INSERT into cliente(Nome, Telefone, Celular, Email, Sexo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF, Complemento) values
('Balcão','1144556699','11988776655','balcao@gmail.com','FEMININO','04-07-2019','20148360','Rua Guimarães Rosa','Barueri','SP','Jd Paulista','356','15654616','12345678909', null);  
GO

SELECT * FROM CLIENTE

CREATE TABLE fornecedor (
IDfornecedor INTEGER IDENTITY(1,1)NOT NULL PRIMARY KEY,
RazaoSocial VARCHAR(200)NOT NULL,
NomeFantasia VARCHAR(200)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(200),
CEP CHAR(8)NOT NULL,
CNPJ CHAR(14) unique NOT NULL,
Logradouro VARCHAR(200)NOT NULL,
Cidade VARCHAR(100)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(100)NOT NULL,
Numero VARCHAR(10)NOT NULL,
Complemento VARCHAR(100) NULL,
StatusForn varchar(30)
)
GO


CREATE TABLE Funcionario (
IDfuncionario INTEGER IDENTITY(1,1)NOT NULL PRIMARY KEY,
Nome VARCHAR(100)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(100),
Sexo VARCHAR(10)NOT NULL,
Cargo VARCHAR(20)NOT NULL,
DataNascimento DATE	NOT NULL,
CEP CHAR(8)NOT NULL,
Logradouro VARCHAR(100)NOT NULL,
Cidade VARCHAR(50)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(50)NOT NULL,
Numero VARCHAR(10) NOT NULL,
RG VARCHAR(20) NOT NULL,
CPF CHAR(11)  unique NOT NULL,
Complemento VARCHAR(100) NULL,
StatusFunc VARCHAR(30) NOT NULL
)
GO



CREATE TABLE logins (
IDlogin INTEGER IDENTITY(1,1),
usuario VARCHAR(50),
email VARCHAR(50) unique,
senha VARCHAR(50),
StatusFunc VARCHAR(30) NOT NULL,
NivelAcesso VARCHAR(15),
CPF char(11)
)
GO



create trigger LoginFuncionario
on funcionario for insert 
as
begin
declare
@email varchar(50),
@usuario varchar(50),
@status varchar(30),
@NivelAcesso varchar(30),
@CPF char(11)
select @email = email, @usuario = Nome, @status = StatusFunc, @NivelAcesso=cargo, @CPF=CPF from inserted
insert into logins (usuario,email,senha, StatusFunc, NivelAcesso,CPF) values (@usuario,@email,'123456',@status, @NivelAcesso,@CPF)

end
go

SELECT * FROM logins

CREATE TABLE Produtos (
IDproduto INTEGER IDENTITY(1,1)NOT NULL PRIMARY KEY,
CodigoDeBarras varchar(40) unique,
Marca VARCHAR(50),
Nome VARCHAR(100),
ValorUnitario DECIMAL(10,2),
Quantidade INTEGER ,
Categoria VARCHAR(30),
Fornecedor INTEGER FOREIGN KEY references fornecedor(IDfornecedor),
DataEntrada DATE,
DataVencimento DATE,
Descricao VARCHAR(300),
Foto VARCHAR(MAX),
NomeArquivo varchar(Max),
)
GO

SELECT * FROM fornecedor




CREATE TABLE venda (
IDvenda INTEGER IDENTITY(1,1) PRIMARY KEY NOT NULL,
CPFcliente VARCHAR(14)NOT NULL,
DataVenda DATE NOT NULL,
ValorTotal DECIMAL(15,2)NOT NULL,
FormaPagamento varchar(50)NOT NULL
)
GO

CREATE TABLE assuntos(
id_assunto int identity (1,1) primary key,
assunto nvarchar(50) not null
)

CREATE TABLE item (
IDitem INTEGER IDENTITY(1,1) PRIMARY KEY NOT NULL,
IDvenda INTEGER FOREIGN KEY references venda (IDvenda),
IDproduto INTEGER FOREIGN KEY references produtos (IDproduto),
Quantidade INTEGER NOT NULL,
SubTotal DECIMAL(5,2)NOT NULL,
)
GO

CREATE TABLE Faleconosco(
id int identity(1,1) primary key,
idcliente int foreign key (idcliente) references cliente (IDcliente),
nome nvarchar(100),
email nvarchar(150),
telefone nvarchar(20),
DataDeEnvio date,
respondido varchar(20),
assunto int foreign key (assunto) references assuntos(id_assunto),
mensagem nvarchar(max),
resposta nvarchar(max)
)

GO

CREATE TABLE Encomendas(
idPedido int identity (1,1) primary key,
idcliente int foreign key (idcliente) references cliente(idcliente),
data_entrega date,
ocasiao varchar(30),
telefone varchar(50),
email nvarchar(100),
descricao_pedido nvarchar(max)

)



GO


select * from cliente

go 

insert into Encomendas (idcliente, data_entrega, ocasiao, telefone, email, descricao_pedido) values ('1','29/10/2019','Casamento','(11)1234-5678','teste@gamil.com','3 bolos de casamento 3kg cada um')


insert into Faleconosco (idcliente, nome, email, telefone, DataDeEnvio, respondido, assunto, mensagem, resposta) values ('4','koki','koki@gmail.com','11973755694','29/10/2019','Não','3','travou','')


--insert into Faleconosco (idcliente, nome, email, DataDeEnvio, respondido, assunto, mensagem, resposta) values ('2','Mateus Alipio dos Santos','kokimateus@gmail.com','28/10/2019','sim','Elogio','Seus lindos','')

GO

--select Faleconosco.id, Faleconosco.idcliente, Faleconosco.nome, Faleconosco.email, Faleconosco.telefone, Faleconosco.DataDeEnvio, Faleconosco.respondido, assuntos.assunto, Faleconosco.mensagem from Faleconosco
--inner join assuntos on assuntos.id_assunto = Faleconosco.assunto where assuntos.assunto = 'Reclamações'
--GO

select * from Faleconosco


--create table Cupom(
--Id_Cupom int identity Primary key  not null,
--Desconto varchar(100) not null,
--)
--insert  into Cupom values ('20%')

-- create table Desconto (
-- Id_Desconto int identity  primary key not null,
-- Id_Cupom int foreign key (Id_Cupom)references Cupom (Id_Cupom) not null,
-- Id_Produto int foreign key (Id_Produto)references Produtos(IDproduto) not null,
-- Status char(1) not null
-- )

--insert  into Desconto values (1,1,'A')

--select Cupom.Desconto,Produtos.Nome from Cupom ,Produtos
--where Desconto.Id_Desconto = 1 and  Desconto.Status = 'A'  


--select Produtos.nome ,Cupom.Desconto,Desconto.Status from Produtos inner join Desconto
--on Produtos.IDproduto = Desconto.Id_Produto inner join Cupom on Cupom.Id_Cupom = Desconto.Id_Cupom


