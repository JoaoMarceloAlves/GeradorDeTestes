using GeradorDeTestes.Dominio.ModuloTeste;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace gerador.WinApp.ModuloTeste
{
    public static class GeradorProvasPdf
    {
        public static void GerarProva(Teste teste, bool ehGabarito)
        {
            string texto = ObterTexto(teste, ehGabarito);

            string arquivo = teste.titulo + (ehGabarito ? "_Gabarito" : "_Prova");
            string caminho = $"{Directory.GetCurrentDirectory()}\\ArquivosPdf\\{arquivo}.pdf";

            PdfWriter writer = new PdfWriter(caminho);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph(texto)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(20);

            document.Add(header);
            document.Close();
        }

        private static string ObterTexto(Teste teste, bool ehGabarito)
        {
            string texto = "";
            texto += $"\nDisciplina: {teste.disciplina}";
            texto += $"\nMatéria: {(teste.ehRecuperacao ? "RECUPERAÇÃO" : teste.materia.Nome)}";
            texto += $"\nSérie: {teste.materia.Serie}";
            texto += $"\nTeste: {(teste.ehRecuperacao ? "Recuperação" : "Prova")}";

            texto += "\n";
            texto += $"\nTítulo: {teste.titulo}{(ehGabarito ? "-GABARITO" : "")}";
            for (int i = 0; i < teste.questoes.Count; i++)
            {
                texto += "\n";
                texto += $"\n{i + 1}-{teste.questoes[i].enunciado}";
                texto += "\n";

                for (int j = 0; j < teste.questoes[i].alternativas.Count; j++)
                {
                    texto += "\n";
                    string letra = Convert.ToChar(65 + j) + ") ";
                    string alternativa = teste.questoes[i].alternativas[j].descricao;

                    if(ehGabarito && teste.questoes[i].resposta.descricao == alternativa)
                    {
                        letra = "X->" + letra;
                    }

                    alternativa = letra + alternativa;

                    texto += alternativa; 
                }
            }

            texto += "\n";
            texto += $"\nArquivo gerado em {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            return texto;
        }
    }
}
