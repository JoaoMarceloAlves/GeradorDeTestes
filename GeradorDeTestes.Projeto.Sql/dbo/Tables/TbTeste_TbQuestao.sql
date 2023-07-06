CREATE TABLE [dbo].[TbTeste_TbQuestao]
(
	  [Teste_Id] INT NOT NULL,
      [Questao_Id] INT NOT NULL,
      CONSTRAINT [FK_TbTeste_TbQuestao_TbTeste] FOREIGN KEY ([Teste_id]) REFERENCES [dbo].[TbTeste] ([Id]),
      CONSTRAINT [FK_TbTeste_TbQuestao_TbQuestao] FOREIGN KEY ([Questao_id]) REFERENCES [dbo].[TbQuestao] ([Id])
)
