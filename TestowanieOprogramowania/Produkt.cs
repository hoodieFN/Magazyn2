using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowanieOprogramowania
{
    public class Produkt
    {
    public int ProduktID { get; set; }
    public String NazwaTowaru { get; set; }
    public String RodzajTowaru { get; set; }
    public String JednostkaMiary { get; set; }
    public Double Ilosc { get; set; }
    public Double CenaNetto { get; set; }
    public Double StawkaVAT  { get; set; }
    public String Opis { get; set; }
    public String Dostawca { get; set; }
    public DateTime DataDostawy { get; set; }
    public DateTime DataRejestracji { get; set; }
    public String Rejestrujacy { get; set; }
    }
}
