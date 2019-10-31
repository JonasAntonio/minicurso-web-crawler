using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using CrawlerConsultaRAB.Utils;
using CrawlerConsultaRAB.Catcher;
using CrawlerConsultaRAB.Registro;

namespace CrawlerConsultaRAB {
    public class Navigator {
        private Utils _utils = new Utils();
        private Connect _connect = new Connect();
        private Catcher _catcher = new Catcher();
        public List<Registro> ListaRegistro = new List<Registro>();
        public List<Registro> NavToQueryPage(string chave) {
            Uri url = _utils.SelectQueryType(1, chave);
            HtmlDocument html= _connect.RequestGET(url);
            ListaRegistro.AddRange(_catcher.GetData(html));
            return ListaRegistro;
        }                
    }
}