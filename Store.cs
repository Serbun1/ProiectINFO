using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Administratorul va putea efectua urmatoarele operatii:
//- sa introduca produse noi pe stoc
//- sa scoata produse din stoc
//- sa creasca/scada numarul de bucati dintr-un produs
//- sa vizualizeze toate comenzile plasate(comenzile care au data de livrare in trecut vor fi marcate ca "livrat")
//- sa proceseze comenzi(sa le schimbe statusul din "in asteptare" in "in curs de livrare" si sa le seteze data livrarii)

namespace Proiect_POO
{
    public class Store
    {
        //Utilizator User;
        private List<Comanda> Comenzi;
        private List<Produs> Produse;

        public Store()
        {
            Produse = new List<Produs>();
            Comenzi = new List<Comanda>();
        }
        //comenzi admin
        public void IntroduProdusNou()
        {
            Console.Write("Nume produs: ");
            string nume = Console.ReadLine();
            Console.Write("Pret: ");
            decimal pret = decimal.Parse(Console.ReadLine());
            Console.Write("Stoc: ");
            int stoc = int.Parse(Console.ReadLine());
            Console.Write("Alegeti tipul produsului: ");
            Console.WriteLine("1. Generic");
            Console.WriteLine("2. Perisabil");
            Console.WriteLine("3. Electrocasnic");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    Produs prod1 = new ProdusGeneric(nume, pret, stoc);
                    Produse.Add(prod1);
                    Console.WriteLine("Produs adaugat cu succes!");
                    break;
                case "2":
                    Console.Write("Data expirarii (DD-MM-YYYY): ");
                    DateTime dataexp = DateTime.Parse(Console.ReadLine());
                    Console.Write("Conditii de pastrare: ");
                    string conditii = Console.ReadLine();
                    Produs prod2 = new ProdusPerisabil(nume, pret, stoc, dataexp, conditii);
                    Produse.Add(prod2);
                    Console.WriteLine("Produs adaugat cu succes!");
                    break;
                case "3":
                    Console.Write("Clasa de eficienta energetica (de la A la G): ");
                    string clasa = Console.ReadLine();
                    Console.Write("Putere maxima consumata ");
                    int pwr = Int32.Parse(Console.ReadLine());
                    Produs prod3 = new ProdusElectrocasnic(nume, pret, stoc, clasa, pwr);
                    Produse.Add(prod3);
                    Console.WriteLine("Produs adaugat cu succes!");
                    return;
                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }


        }
        public void EliminaProdus(string nume_produs)
        {
            foreach (var p in Produse)
            {
                if (p.Denumire == nume_produs)
                {
                    Produse.Remove(p);
                    Console.WriteLine("Produsul a fost eliminat din stoc cu succes!");
                }
                else
                    Console.WriteLine("Produsul nu a fost gasit.");
            }
        }
        public void ModificaStoc(string nume_produs, int q)
        {
            foreach (var p in Produse)
            {
                if (p.Denumire == nume_produs)
                {
                    p.Stoc = q;
                    Console.WriteLine("Stoc actualizat cu succes!");
                }
                else
                    Console.WriteLine("Produsul nu a fost gasit.");
            }

        }
        public void VizualizareComenzi()
        {
            foreach (var com in Comenzi)
            {
                string stare = com.DeliveryDate < DateTime.Now ? "Livrat" : com.Status;
                Console.WriteLine($"Lista Comenzi: Numarul comenzii: {com.OrderId}, Client: {com.CustomerName}, Status: {stare}, Data livrare: {com.DeliveryDate}");
            }
        }
        public void ProcesareComenzi(int id)
        {

            foreach(var com in Comenzi)
            {
                if(com.OrderId==id)
                {
                    Console.WriteLine($"Lista Comenzi: Numarul comenzii: {com.OrderId}, Client: {com.CustomerName}, Status: {com.Status}, Data livrare: {com.DeliveryDate}");
                    Console.WriteLine("Introdu data livrarii (DD-MM-YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    com.editare_admin(date);
                }


            }
        }

        //comenzi user
        public void VizualizareProduse()
        {
            foreach (var p in Produse)
            {
                Console.WriteLine(p.ToString());
            }
        }
        public void CautareProduse(string nume)
        {
            foreach (var p in Produse)
            {
                if(nume == p.Denumire)
                    Console.WriteLine(p.ToString());
                else
                    Console.WriteLine("Produsul nu a fost gasit.");
            }
        }
        public void PlaceOrder()
        {
            Console.Write("Nume: ");
            string name = Console.ReadLine();
            Console.Write("Telefon: ");
            string phone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Adresa: ");
            string address = Console.ReadLine();

            var comanda_noua = new Comanda(Comenzi.Count + 1, name, phone, email, address);
            Comenzi.Add(comanda_noua);
            Console.WriteLine("Comanda a fost plasata cu succes!");
        }
    }
}
