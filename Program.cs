using System.Runtime.CompilerServices;

namespace MenuLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("======Operazioni======");
                Console.WriteLine("Scegli un operazione");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Logout");
                Console.WriteLine("3: Verifica ora e data di login");
                Console.WriteLine("4: Lista degli accessi");
                Console.WriteLine("5: Esci");
                Console.WriteLine("=====================");

                int scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 1:
                        Utente.Login();
                        break;
                    case 2:
                        Utente.Logout();
                        break;
                    case 3:
                        Utente.VerificaLogin();
                        break;
                    case 4:
                        Utente.ListaAccessi();
                        break;
                    case 5:
                        return;
                        Console.Clear();
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
        }
    }

    public static class Utente
    {
        private static string username;
        private static string password;
        private static DateTime loginTime;
        private static List<DateTime> accessi = new List<DateTime>();

        public static void Login()
        {
            Console.WriteLine("Inserisci Username: ");
            string user = Console.ReadLine();

            Console.WriteLine("Inserisci Password: ");
            string pass = Console.ReadLine();

            string ConfirmPass;
            do
            {
                Console.WriteLine("Conferma Password: ");
                ConfirmPass = Console.ReadLine();

                if (pass != ConfirmPass)
                {
                    Console.WriteLine("Le password non coincidono. Riprova.");
                }
            } while (pass != ConfirmPass);

            username = user;
            password = pass;
            loginTime = DateTime.Now;
            accessi.Add(loginTime);
            Console.WriteLine("Login effettuato con successo.");
        }
        public static void Logout()
        {
            if (username != null)
            {
                username = null;
                password = null;
                Console.WriteLine("Logout effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato.");
            }
        }
        public static void VerificaLogin()
        {
            if (username != null)
            {
                Console.WriteLine($"ultimo accesso effettuato il {loginTime}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato.");
            }
        }
        public static void ListaAccessi()
        {
            if (accessi.Count > 0)
            {
                Console.WriteLine("Lista degli accessi");
                foreach (var accesso in accessi)
                {
                    Console.WriteLine(accesso);
                }
                Console.WriteLine("Nessun utente registrato.");
            }
        }
    }
}
