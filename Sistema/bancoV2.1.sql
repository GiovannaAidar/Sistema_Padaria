/*INF3FM 
PADARIA ALAMEDA 
 
EQUIPE N° 05 
 
Gabriel Victor Valdivia N° 10 
Guilherme Horta dos Santos N° 15 
Lucas Moura Silva Nº 26 
Mateus Alípio dos Santos Silva Nº 27   
*/


/*    EXCLUSÃO DO BANCO DE DADOS */
drop database Projeto 


/*    CRIAR BANCO DE DADOS */
create database Projeto

USE [Projeto]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 19/03/2019 17:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[IDcliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Telefone] [nvarchar](50) NOT NULL,
	[Celular] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Sexo] [nvarchar](50) NOT NULL,
	[DataNascimento] [nvarchar](50) NOT NULL,
	[CEP] [nvarchar](50) NOT NULL,
	[Logradouro] [nvarchar](50) NOT NULL,
	[Cidade] [nvarchar](50) NOT NULL,
	[UF] [nvarchar](50) NOT NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[RG] [nvarchar](50) NOT NULL,
	[CPF] [nvarchar](50) PRIMARY KEY NOT NULL,
UNIQUE NONCLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fornecedor]    Script Date: 19/03/2019 17:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fornecedor](
	[RazaoSocial] [nvarchar](50) NULL,
	[NomeFantasia] [nvarchar](50) NULL,
	[Telefone] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CEP] [nvarchar](50) NULL,
	[CNPJ] [nvarchar](50) NULL,
	[Logradouro] [nvarchar](50) NULL,
	[Cidade] [nvarchar](50) NULL,
	[UF] [nvarchar](50) NULL,
	[Bairro] [nvarchar](50) NULL,
	[Numero] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[funcionario]    Script Date: 19/03/2019 17:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[funcionario](
	[Nome] [nvarchar](50) NOT NULL,
	[Telefone] [nvarchar](50) NOT NULL,
	[Celular] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Sexo] [nvarchar](50) NOT NULL,
	[Cargo] [nvarchar](50) NOT NULL,
	[DataNascimento] [nvarchar](50) NOT NULL,
	[CEP] [nvarchar](50) NOT NULL,
	[Logradouro] [nvarchar](50) NOT NULL,
	[Cidade] [nvarchar](50) NOT NULL,
	[UF] [nvarchar](50) NOT NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[RG] [nvarchar](50) NOT NULL,
	[CPF] [nvarchar](50)PRIMARY KEY NOT NULL 
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[logins]    Script Date: 19/03/2019 17:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[logins](
	[usuario] [varchar](50) NOT NULL unique,
	[senha] [varchar](50) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT into logins(usuario, senha) values('lucas','123'); 
INSERT into logins(usuario, senha) values('admin','123456');
INSERT into logins(usuario, senha) values('mateus','123');
INSERT into logins(usuario, senha) values('coxinha','123'); 
INSERT into logins(usuario, senha) values('gabriel','123');

INSERT into	funcionario(Nome, Telefone, Celular, Email, Sexo, Cargo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Lucas Moura Silva','4201-6111','(11)97355-5694','lucas@gmail.com','MASCULINO','GERENTE','10/12/2001','06435-110','Rua Manoel Bandeira','Barueri','SP','Jd Tupã','220','123.456.789-1','308.643.778-27'); 
INSERT into	funcionario(Nome, Telefone, Celular, Email, Sexo, Cargo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Lucas Moura Silva','4201-6111','(11)97355-5694','lucas@gmail.com','MASCULINO','GERENTE','10/12/2001','06435-110','Rua Manoel Bandeira','Barueri','SP','Jd Tupã','220','123.456.789-1','111.111.111-11'); 
INSERT into	funcionario(Nome, Telefone, Celular, Email, Sexo, Cargo, DataNascimento, CEP, Logradouro, Cidade, UF, Bairro, Numero, RG, CPF) values
('Lucas Moura Silva','4201-6111','(11)97355-5694','lucas@gmail.com','MASCULINO','GERENTE','10/12/2001','06435-110','Rua Manoel Bandeira','Barueri','SP','Jd Tupã','220','123.456.789-1','999.999.999-'); 




GO
SET ANSI_PADDING OFF
GO
