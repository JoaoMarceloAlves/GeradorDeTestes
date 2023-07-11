using GeradorDeTestes.Dominio.ModuloTeste;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Color = iText.Kernel.Colors.Color;

namespace gerador.WinApp.ModuloTeste
{
    public static class GeradorProvasPdf
    {
        public static void GerarProva(Teste teste, bool ehGabarito)
        {
            string arquivo = teste.titulo + (ehGabarito ? "_Gabarito" : "_Prova");
            string caminho = $"{Directory.GetCurrentDirectory()}\\ArquivosPdf\\{arquivo}.pdf";

            PdfWriter escritor = new PdfWriter(caminho);
            PdfDocument pdf = new PdfDocument(escritor);
            Document documento = new Document(pdf);

            string cabecalhoTexto = ObterCabecalho(teste, ehGabarito);
            Paragraph cabecalho = new Paragraph(cabecalhoTexto)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(16)
               .SetBold();

            documento.Add(cabecalho);

            string tituloTexto = ObterTitulo(teste, ehGabarito);
            Paragraph titulo = new Paragraph(tituloTexto)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20)
               .SetBold()
               .SetUnderline();

            documento.Add(titulo);


            EscreverQuestoes(teste, ehGabarito, documento);

            string rodapeTexto = ObterRodape(teste, ehGabarito);
            Paragraph rodape = new Paragraph(rodapeTexto)
               .SetTextAlignment(TextAlignment.RIGHT)
               .SetFontSize(14)
               .SetBold()
               .SetItalic();

            documento.Add(rodape);

            documento.Close();
        }

        private static string ObterCabecalho(Teste teste, bool ehGabarito)
        {
            string texto = "";
            texto += $"\nDisciplina: {teste.disciplina}";
            texto += $"\nMatéria: {(teste.ehRecuperacao ? "RECUPERAÇÃO" : teste.materia.Nome)}";
            texto += $"\nSérie: {teste.materia.Serie}";

            texto += "\n";
            return texto;
        }
        private static string ObterTitulo(Teste teste, bool ehGabarito)
        {
            return $"\n{teste.titulo}{(ehGabarito ? "-GABARITO" : "")}";
        }

        private static void EscreverQuestoes(Teste teste, bool ehGabarito, Document documento) {
 
            for (int i = 0; i < teste.questoes.Count; i++)
            {
                string numeroQuestao = $"\n{i + 1}. ";

                Paragraph numero = new Paragraph(numeroQuestao)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(16)
               .SetBold();
            
                string enunciadoTexto = $"{teste.questoes[i].enunciado}";

                Text enunciado = new Text(enunciadoTexto)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(16);

                numero.Add(enunciado);

                documento.Add(numero);

                for (int j = 0; j < teste.questoes[i].alternativas.Count; j++)
                {
                    string alternativa = teste.questoes[i].alternativas[j].descricao;
                    
                    string letraTexto = Convert.ToChar(65 + j) + ") ";

                    if (ehGabarito && teste.questoes[i].resposta.descricao == alternativa)
                    {
                        Paragraph alternativaCorreta = new Paragraph(letraTexto + alternativa)
                       .SetTextAlignment(TextAlignment.LEFT)
                       .SetFontSize(16)
                       .SetFontColor(new DeviceRgb(40, 200, 60));

                        documento.Add(alternativaCorreta);

                        continue;
                    }

                     Paragraph descricao = new Paragraph(letraTexto + alternativa)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(16);

                    documento.Add(descricao);
                }
            }
        }
        private static string ObterRodape(Teste teste, bool ehGabarito) {
            return $"\n" +
                $"\nArquivo gerado em {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }
    }
}
