CREATE TABLE [dbo].[TbTeste]
(
	  [Id]            INT           IDENTITY (1, 1) NOT NULL,
      [Titulo]        VARCHAR (200)  NOT NULL,
      [Recuperacao]   BIT NOT NULL,
      [Quantidade_Questoes] INT NOT NULL,
      [Materia_Id] INT NOT NULL,
      [Disciplina_Id] INT NOT NULL,
      CONSTRAINT [PK_TbTeste] PRIMARY KEY CLUSTERED ([Id] ASC),
      CONSTRAINT [FK_TbTeste_TbMateria] FOREIGN KEY ([Materia_id]) REFERENCES [dbo].[TbMateria] ([Id]),
      CONSTRAINT [FK_TbTeste_TbDisciplina] FOREIGN KEY ([Disciplina_id]) REFERENCES [dbo].[TbDisciplina] ([Id])
)
