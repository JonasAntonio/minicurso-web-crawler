using CrawlerConsultaRAB.Registro;
using System;

namespace CrawlerConsultaRAB {
    public class Index {
        public static void Main(string[] args) {
            Index index = new Index();
            index.Menu();
        }

        private void Menu() {
            ConsultaRAB();
            Console.WriteLine("Deseja efetuar uma nova consulta? [S/N]");
            string option = Console.ReadLine().ToUpper();
            Console.Clear();
            switch(option) {
                case "S":
                case "SIM":
                    Menu();
                    break;
                case "N":
                case "NAO":
                default:
                    Console.WriteLine("Obrigado por utilizar o sistema :)");
            }
        }

        private void ConsultaRAB() {
            Navigator navigator = new Navigator();
            Console.WriteLine("Digite uma Chave:");
            string chave = Console.ReadLine().ToUpper();
            Console.Clear();
            Console.WriteLine("Pesquisando...");
            Console.Clear();
            navigator.NavToQueryPage(chave);
            Console.Clear();
            Console.WriteLine("----------------");
            var lista = navigator.ListaRegistro;
            foreach(Registro captura in lista) {
                Console.WriteLine(captura.Indice);
                if(captura.Indice.Contains("Motivo(s)") && captura.Motivo.Count > 0) {
                    foreach(string motivo in captura.Motivo) {
                        Console.WriteLine(motivo);
                    }
                } else {
                    Console.WriteLine(captura.Texto+"\n");
                }
            }
            Console.WriteLine("----------------");
        }
    }
}