﻿using System;
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
        public string DostepDoListyUzytkownikow {  get; set; }
        public string DostepDoListyUprawnien {  get; set; }
        public string DodawanieUzytkownika {  get; set; }
        public string UsuwanieUzytkownika {  get; set; }
        public string EdytowanieUzytkownika {  get; set; }
        public string DodawanieRoli { get; set; }
        public string UsuwanieRoli { get; set; }
        public string EdytowanieRoli { get; set; }
    }
}
