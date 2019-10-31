using HtmlAgilityPack;
using System;

namespace CrawlerConsultaRAB {
    public class Util {
        public HtmlDocument ParseToHtmlDocument(string html) {
            ParseToHtmlDocument htmlDoc = new ParseToHtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        }

        public Uri SelectQueryType(int tipo, string chave) {
            Uri url = new Uri("https://sistemas.anac.gov.br/aeronaves/cons_rab_novo.asp");
            switch(tipo) {
                case 1:
                    url = new Uri(String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_novo_resposta.asp?textMarca={0}"), chave);
                    break;
                // case 2:

                //     break;
            }
        }
    }
}