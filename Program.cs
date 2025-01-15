using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_POO
{
    class Program
    {
        static bool checkpass(string input)
        {
            string password = "admin";
            if (input == password)
                return true;
            else
                return false;  
        }

        static void Main(string[] args)
        {
            //Store store = Store.LoadData();
            Store store = new Store();
            
            while (true)
            {
                Console.WriteLine("1. Utilizator");
                Console.WriteLine("2. Administrator");
                Console.WriteLine("3. Iesire");
                Console.Write("Alege optiunea: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UserMenu(store);
                        break;
                    case "2":
                        Console.WriteLine("Introdu parola: ");
                        string input = Console.ReadLine();
                        if (checkpass(input))
                            AdminMenu(store);
                        else
                            Console.WriteLine("Nu aveti permisiunea de Admin!");
                        break;
                    case "3":
                        //store.SaveData();
                        return;
                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
        }


        static void UserMenu(Store store)
        {
            while (true)
            {
                Console.WriteLine("1. Vizualizare produse");
                Console.WriteLine("2. Cauta produs");
                Console.WriteLine("3. Sorteaza produse dupa pret");
                Console.WriteLine("4. Adauga produs in cos");
                Console.WriteLine("5. Plaseaza comanda");
                Console.WriteLine("6. Inapoi");
                Console.Write("Alege optiunea: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        store.VizualizareProduse();
                        break;
                    case "2":
                        Console.Write("Introdu numele produsului: ");
                        string name = Console.ReadLine();
                        store.CautareProduse(name);
                        break;
                    case "3":
                        Console.Write("1. Crescator, 2. Descrescator: ");
                        bool ascending = Console.ReadLine() == "1";
                        //store.SortProductsByPrice(ascending);
                        break;
                    case "4":
                        Console.Write("Introdu ID produs: ");
                        int id = int.Parse(Console.ReadLine());
                       // store.AddToCart(id);
                        break;
                    case "5":
                        store.PlaceOrder();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
        }

        static void AdminMenu(Store store)
        {
            while (true)
            {
                Console.WriteLine("1. Adauga produs nou");
                Console.WriteLine("2. Scoate produs");
                Console.WriteLine("3. Modifica stoc");
                Console.WriteLine("4. Vizualizare comenzi");
                Console.WriteLine("5. Proceseaza comenzi");
                Console.WriteLine("6. Inapoi");
                Console.Write("Alege optiunea: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        store.IntroduProdusNou();
                        break;
                    case "2":
                        Console.Write("Introdu numele produsului: ");
                        string id = Console.ReadLine();
                        store.EliminaProdus(id);
                        break;
                    case "3":
                        Console.Write("Introdu nume produs: ");
                        string pid = Console.ReadLine();
                        Console.Write("Introdu cantitate noua: ");
                        int quantity = int.Parse(Console.ReadLine());
                        store.ModificaStoc(pid, quantity);
                        break;
                    case "4":
                        store.VizualizareComenzi();
                        break;
                    case "5":
                       
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
        }
    }
}
