
DROP DATABASE Projeto

CREATE DATABASE Projeto
USE Projeto


CREATE TABLE cliente (
IDcliente INTEGER IDENTITY(1,1) NOT NULL,
Nome VARCHAR(100)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(100),
Sexo VARCHAR(10)NOT NULL,
DataNascimento CHAR(8)NOT NULL,
CEP CHAR(8)NOT NULL,
Logradouro VARCHAR(100)NOT NULL,
Cidade VARCHAR(50)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(50)NOT NULL,
Numero VARCHAR(10) NOT NULL,
RG VARCHAR(20)NOT NULL,
CPF CHAR(11) PRIMARY KEY NOT NULL
)

CREATE TABLE fornecedor (
IDfornecedor INTEGER IDENTITY(1,1)NOT NULL,
RazaoSocial VARCHAR(200)NOT NULL,
NomeFantasia VARCHAR(200)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(200),
CEP CHAR(8)NOT NULL,
CNPJ CHAR(14) PRIMARY KEY NOT NULL,
Logradouro VARCHAR(200)NOT NULL,
Cidade VARCHAR(100)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(100)NOT NULL,
Numero VARCHAR(10)NOT NULL
)

CREATE TABLE Funcionario (
IDfuncionario INTEGER IDENTITY(1,1)NOT NULL,
Nome VARCHAR(100)NOT NULL,
Telefone CHAR(10)NOT NULL,
Celular CHAR(11)NOT NULL,
Email VARCHAR(100),
Sexo VARCHAR(10)NOT NULL,
Cargo VARCHAR(20)NOT NULL,
DataNascimento CHAR(8)NOT NULL,
CEP CHAR(8)NOT NULL,
Logradouro VARCHAR(100)NOT NULL,
Cidade VARCHAR(50)NOT NULL,
UF CHAR(2)NOT NULL,
Bairro VARCHAR(50)NOT NULL,
Numero VARCHAR(10) NOT NULL,
RG VARCHAR(20)NOT NULL,
CPF CHAR(11) PRIMARY KEY NOT NULL
)

CREATE TABLE logins (
IDlogin INTEGER IDENTITY(1,1),
usuario VARCHAR(50) PRIMARY KEY NOT NULL,
senha VARCHAR(50)NOT NULL
)

DROP TABLE Produtos
CREATE TABLE Produtos (
IDproduto INTEGER IDENTITY(1,1)NOT NULL,
CodigoDeBarras VARCHAR(40) PRIMARY KEY NOT NULL,
Marca VARCHAR(50)NOT NULL,
Nome VARCHAR(100)NOT NULL,
ValorUnitario VARCHAR(10)NOT NULL,
Quantidade VARCHAR(10)NOT NULL,
Categoria VARCHAR(30)NOT NULL,
Fornecedor VARCHAR(100)NOT NULL,
DataEntrada CHAR(8)NOT NULL,
DataVencimento CHAR(8)NOT NULL,
Descricao VARCHAR(300)NOT NULL/*falha: chave estrangeira*/
)



/*INSERIR VALORES NA TABELA LOGINS*/
INSERT into logins(usuario, senha) values('lucas','123'); 
INSERT into logins(usuario, senha) values('admin','123456');
INSERT into logins(usuario, senha) values('mateus','123');
INSERT into logins(usuario, senha) values('coxinha','123'); 
INSERT into logins(usuario, senha) values('gabriel','123');

/*INSERIR VALORES NA TABELA FUNCIONARIOS*/
	INSERT into	funcionario(Nome, Telefone, Celular, Email, Sexo, Cargo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Lucas Moura Silva','42016111','11973555694','lucas@gmail.com','MASCULINO','GERENTE','10122001','06435110','Rua Manoel Bandeira','Barueri','SP','Jd Tupã','220','1234567891','30864377869');
	INSERT into	funcionario(Nome, Telefone, Celular, Email, Sexo, Cargo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Mateus Alipo dos Santos Silva','1125634796','11973555694','mateus@gmail.com','MASCULINO','PADEIRO(a)','11102001','12563120','Rua Pato Selvagem','Barueri','SP','Jd. Vila Nova','123','3569875561','78946512327');
	INSERT into	funcionario(Nome, Telefone, Celular, Email, Sexo, Cargo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Victor Gabriel Vasconcelos','1131655461','11945252443','Victor123@gmail.com','MASCULINO','PADEIRO(a)','15031993','25697563','Rua Marcondes Vila','Jandira','SP','Jd. Canadá','1256','2569871592','25836747828');


/*INSERIR VALORES NA TABELA CLIENTE*/
INSERT into cliente(Nome, Telefone, Celular, Email, Sexo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Vinicius Artur','1146959851','11987534541','vinicius@gmail.com','MASCULINO','30041995','07495206','Rua Franco da Rocha','Barueri','SP','Jd Silveira','956','9865156614','64595432162');
INSERT into cliente(Nome, Telefone, Celular, Email, Sexo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Henrique Machado','1148959005','11911506441','henrique@gmail.com','MASCULINO','21091998','47120910','Rua Quinze de Novembro','Barueri','SP','Vila Nova','420','712019811','79518212330'); 
INSERT into cliente(Nome, Telefone, Celular, Email, Sexo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Andressa Oliveira','1140099930','11977856014','andressa@gmail.com','FEMININO','14021997','20148360','Rua Guimarães Rosa','Barueri','SP','Jd Paulista','356','15654616','41569812087');  


/*INSERIR VALORES NA TABELA FORNECEDOR*/

	INSERT into fornecedor(RazaoSocial, NomeFantasia, Telefone, Celular, Email, CEP, CNPJ, Logradouro, Cidade, UF, Bairro, Numero) values
('CocaCola Indústrias Ltda','CocaCola Brasil','1132551597','11945625632','cocacolabrasil@gmail.com','12579752','99999999999999','Rua Alameda Weed','Barueri','SP','Alphaville','15');
	INSERT into fornecedor(RazaoSocial, NomeFantasia, Telefone, Celular, Email, CEP, CNPJ, Logradouro, Cidade, UF, Bairro, Numero) values
('Produtos Dona Benta Br','Dona Benta','1113786579','11931653978','donabenta@gmail.com','35789123','13149135159715','Rua Mauros Misto','Osasco','SP','Jd Camargos','3655');
	INSERT into fornecedor(RazaoSocial, NomeFantasia, Telefone, Celular, Email, CEP, CNPJ, Logradouro, Cidade, UF, Bairro, Numero) values
('PRODUTOS ALIMENTICIOS FLEISCHMANN E ROYAL LTDA','FLEISCHM E ROYAL','1150977373','11950977236','royal1530@gmail.com','13215011','25257349254905','AV ANTONIO FREDERICO OZANAN','JUNDIAI','SP','Vila São Martins','4501');
	INSERT into fornecedor(RazaoSocial, NomeFantasia, Telefone, Celular, Email, CEP, CNPJ, Logradouro, Cidade, UF, Bairro, Numero) values
('PULLMAN ALIMENTOS LTDA','PULLMAN','1198530373','11999997236','pullmanoriginal@gmail.com','97215054','66257349254923','AV ANTONIO FREDERICO PASCOAL','JUNDIAI','SP','Vila São Martins','4509');

/*INSERIR VALORES NA TABELA PRODUTOS*/

 INSERT into Produtos(CodigoDeBarras, Marca, Nome, ValorUnitario, Quantidade, Categoria, Fornecedor, DataEntrada, DataVencimento, Descricao) values 
 ('000111010101','Dona Benta','Farinha de Trigo','0400','30','Farinhas','PRODUTOS ALIMENTICIOS FLEISCHMANN E ROYAL LTDA','10012019','10122020','Saco de farinha de trigo com 500g')
 INSERT into Produtos(CodigoDeBarras, Marca, Nome, ValorUnitario, Quantidade, Categoria, Fornecedor, DataEntrada, DataVencimento, Descricao) values 
 ('000111010102','Pullmam','Pão de Forma','0450','40','Panificação','PULLMAN ALIMENTOS LTDA','10012019','10122020','Pão de forma tradicional com casca 500g')
 INSERT into Produtos(CodigoDeBarras, Marca, Nome, ValorUnitario, Quantidade, Categoria, Fornecedor, DataEntrada, DataVencimento, Descricao) values 
 ('000111000111','Coca-Cola','Refrigerante Coca-Cola','0700','100','Bebidas','ColaCola Indústrias Ltda','04042019','20052020','Refrigerante CocaCola 2Litros')
