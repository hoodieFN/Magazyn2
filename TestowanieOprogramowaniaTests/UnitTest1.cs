using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestowanieOprogramowania;


namespace TestowanieOprogramowaniaTests
{
    [TestClass]
    public class WalidacjaTest
    {
        [TestMethod]
        public void TestWalidacjiPlec_PoprawnaKobieta()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();

            // Act
            bool wynik = walidacja.WalidujPlec("K");

            // Assert
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidacjiPlec_PoprawnyMezczyzna()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();

            // Act
            bool wynik = walidacja.WalidujPlec("M");

            // Assert
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidacjiPlec_NiepoprawnaPlec()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();

            // Act
            bool wynik = walidacja.WalidujPlec("X");

            // Assert
            Assert.IsFalse(wynik);
        }


        [TestMethod]
        public void TestWalidacjiDaty_PoprawnaData()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string dataUrodzenia = "2000-01-01";

            // Act
            bool wynik = walidacja.WalidujDate(dataUrodzenia);

            // Assert
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidacjiDaty_NieprawidlowaData()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string dataUrodzenia = "2023-02-30";//luty ma 28

            // Act
            bool wynik = walidacja.WalidujDate(dataUrodzenia);

            // Assert
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidacjiDaty_DataWPrzyszlosci()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string dataUrodzenia = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            // Act
            bool wynik = walidacja.WalidujDate(dataUrodzenia);

            // Assert
            Assert.IsFalse(wynik);
        }
        [TestMethod]
        public void TestWalidacjiNumeruTelefonu_PoprawnyNumer()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string numerTelefonu = "123456789";

            // Act
            bool wynik = walidacja.WalidujNumerTelefonu(numerTelefonu);

            // Assert
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidacjiNumeruTelefonu_NieprawidlowaDlugosc()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string numerTelefonu = "12345678"; // 8 cyfr zamiast 9

            // Act
            bool wynik = walidacja.WalidujNumerTelefonu(numerTelefonu);

            // Assert
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidacjiNumeruTelefonu_NiepoprawnyFormat()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string numerTelefonu = "123456789A"; // Niecyfrowy znak na koñcu

            // Act
            bool wynik = walidacja.WalidujNumerTelefonu(numerTelefonu);

            // Assert
            Assert.IsFalse(wynik);
        }
        [TestMethod]
        public void TestWalidacjiEmail_PoprawnyEmail()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string email = "example@example.com";

            // Act
            bool wynik = walidacja.WalidujEmail(email);

            // Assert
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidacjiEmail_WieleZnakowAt()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string email = "example@exam@ple.com";

            // Act
            bool wynik = walidacja.WalidujEmail(email);

            // Assert
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidacjiEmail_DlugoscZaDluga()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string email = new string('a', 256) + "@example.com";

            // Act
            bool wynik = walidacja.WalidujEmail(email);

            // Assert
            Assert.IsFalse(wynik);
        }



        [TestMethod]
        public void TestWalidacjiPesel_PoprawnyPesel()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string pesel = "85072912345"; 

            // Act
            bool wynik = walidacja.WalidujPesel(pesel);

            // Assert
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidacjiPesel_NieprawidlowaDlugosc()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string pesel = "1234567890123"; 

            // Act
            bool wynik = walidacja.WalidujPesel(pesel);

            // Assert
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidacjiPesel_NieprawidlowaCyfraKontrolna()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string pesel = "85072912346"; 

            // Act
            bool wynik = walidacja.WalidujPesel(pesel);

            // Assert
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidacjiPesel_NieprawidlowaDataUrodzenia()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string pesel = "00000000000"; 

            // Act
            bool wynik = walidacja.WalidujPesel(pesel);

            // Assert
            Assert.IsFalse(wynik);
        }































        [TestMethod]
        public void TestWyszukiwaniaUzytkownikow_PoprawnySzukanyTekst()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string szukanyTekst = "Ewa"; 

            // Act
            List<Uzytkownik> listaUzytkownikow = walidacja.WyszukajUzytkownikow(szukanyTekst);

            // Assert
            Assert.IsNotNull(listaUzytkownikow);
            Assert.IsTrue(listaUzytkownikow.Count > 0); // niepusta lista
            foreach (var uzytkownik in listaUzytkownikow)
            {
                StringAssert.Contains(uzytkownik.Imie, szukanyTekst);
            }
        }

        [TestMethod]
        public void TestWyszukiwaniaUzytkownikow_NieznalezionySzukanyTekst()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();
            string szukanyTekst = "xyz"; // Szukany tekst, który nie powinien byæ w bazie

            // Act
            List<Uzytkownik> listaUzytkownikow = walidacja.WyszukajUzytkownikow(szukanyTekst);

            // Assert
            Assert.IsNotNull(listaUzytkownikow);
            Assert.AreEqual(0, listaUzytkownikow.Count); // Oczekujemy, ¿e lista bêdzie pusta
        }

        [TestMethod]
        public void TestPobierzUzytkownikow_ZwracaListeUzytkownikow()
        {
            // Arrange
            Walidacja walidacja = new Walidacja();

            // Act
            List<Uzytkownik> result = walidacja.PobierzUzytkownikow();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
