CREATE TABLE [dbo].[TbMateria] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [nome]          VARCHAR (200) NOT NULL,
    [Disciplina_id] INT           NOT NULL,
    [serie]         VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_TbMateria] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TbMateria_TbDisciplina] FOREIGN KEY ([Disciplina_id]) REFERENCES [dbo].[TbDisciplina] ([Id])
);

