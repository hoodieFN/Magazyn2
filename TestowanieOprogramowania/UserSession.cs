using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowanieOprogramowania
{
    public static class UserSession
    {
        // Zmieniamy typ CurrentUser na int i ustawiamy domyślną wartość -1, oznaczającą 'brak użytkownika'
        public static int CurrentUserId { get; private set; } = -1;

        public static void StartSession(int userId)
        {
            CurrentUserId = userId;
            ///////===============Debug==================/////////////MessageBox.Show("Klasa User session - ustawiono user id na: " + userId);
            // Możesz dodać więcej logiki związanej z sesją tutaj
        }

        public static void EndSession()
        {
            CurrentUserId = -1;
            // Dodatkowe czynności związane z końcem sesji
        }
    }
}
/*
Teraz klasa UserSession używa zmiennej CurrentUserId typu int 
do przechowywania identyfikatora zalogowanego użytkownika. 
Wartość -1 jest używana do wskazania, że żaden użytkownik nie jest obecnie zalogowany. 
Kiedy sesja się rozpoczyna, ustawiasz CurrentUserId na ID zalogowanego użytkownika. 
Aby zakończyć sesję, ponownie ustawiasz CurrentUserId na -1.
*/