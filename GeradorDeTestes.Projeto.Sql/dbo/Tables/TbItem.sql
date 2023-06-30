CREATE TABLE [dbo].[TbItem] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Descricao]      VARCHAR (200) NOT NULL,
    [Valor] DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_ItemTema] PRIMARY KEY CLUSTERED ([Id] ASC)
);

