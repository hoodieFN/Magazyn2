using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowanieOprogramowania.Models
{
    public class Produkt
    {
        public int ProduktID { get; set; }
        public string NazwaTowaru { get; set; }
        public string RodzajTowaru { get; set; }
        public string JednostkaMiary { get; set; }
        public double Ilosc { get; set; }
        public double CenaNetto { get; set; }
        public string StawkaVAT { get; set; }
        public string Opis { get; set; }
        public string Dostawca { get; set; }
        public DateTime DataDostawy { get; set; }
        public DateTime DataRejestracji { get; set; }
        public string Rejestrujacy { get; set; }
    }
}
