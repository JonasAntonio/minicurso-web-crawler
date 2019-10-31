using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CrawlerConsultaRAB.Registro;
using CrawlerConsultaRAB.Utils;

namespace CrawlerConsultaRAB {
    private Utils _utils = new Utils();
    public class Catcher {
        public List<Registro> GetData(HtmlDocument html) {
            HtmlNodeCollection nodesData = html.DocumentNode.SelectNodes("//div[contains(@class, 'retorno-pesquisa')]/table/tbody/tr");
            List<Registro> ListaRegistro = new List<Registro>();
            foreach(HtmlNode node in nodesData) {
                Registro newRegistro = new Registro();
                HtmlDocument nodeHtmlDoc = _utils.ParseToHtmlDocument(node);

                string indice = nodeHtmlDoc.DocumentNode.SelectSingleNode("th/text()");
                string texto = string.Empty;
                if(indice.Contains("Motivo(s)")) {
                    var motivos = nodeHtmlDoc.DocumentNode.SelectNodes("td/br");
                    if(motivos != null) {
                        foreach (var txt in motivos) {
                            newRegistro.Motivo.Add(txt.InnerText);
                        }
                    } else {
                        try {
                            texto = nodeHtmlDoc.DocumentNode.SelectSingleNode("td/text()").OuterHtml;
                        } catch {
                            texto = string.Empty;
                        }

                        newRegistro.Texto = texto;
                    }
                }
                ListaRegistro.Add(newRegistro);
            }
            return ListaRegistro;
        }
    }
}