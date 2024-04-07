using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowanieOprogramowania
{
    public class Uprawnienia
    {
        public int UprawnienieID { get; set; }
        public string Nazwa_stanowiska { get; set; }
        public string DostepDoRaportow {  get; set; }
        public string ObslugaWozkowWidlowych {  get; set; }
        public string ZarzadzanieMagazynem {  get; set; }
        public string NaprawaUrzadzen {  get; set; }
        public string PakowaniePaczek {  get; set; }
    }
}
