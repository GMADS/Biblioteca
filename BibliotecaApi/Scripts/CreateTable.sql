USE [Livros]

CREATE TABLE [dbo].[Livros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeDoLivro] [varchar](80) NULL,
	[NomeDoAutor] [varchar](80) NULL,
	[NumeroDePaginas] [int] NULL
) ON [PRIMARY]


