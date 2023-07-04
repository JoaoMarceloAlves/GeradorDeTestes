CREATE TABLE [dbo].[TbQuestao]
(
	[Id] INT NOT NULL, 
    [Enunciado] VARCHAR(MAX) NOT NULL, 
    [Resposta] VARCHAR(200) NOT NULL, 
    [Alternativa_A] VARCHAR(200) NOT NULL, 
    [Alternativa_B] VARCHAR(200) NOT NULL, 
    [Alternativa_C] NCHAR(200) NULL, 
    [Alternativa_D] NCHAR(200) NULL, 
    [Materia_Id] INT NOT NULL,
    CONSTRAINT [PK_Questao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TbQuestao_TbMateria] FOREIGN KEY ([Materia_id]) REFERENCES [dbo].[TbMateria] ([Id])
)
