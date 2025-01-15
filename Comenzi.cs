using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_POO
{
    public class Comanda
    {
        public int OrderId;
        public List<Produs> Produse;
        public string CustomerName;
        public string PhoneNumber;
        public string Email;
        public string Address;
        public string Status;
        public DateTime DeliveryDate;

        public Comanda(int orderid, string nume, string nrtel, string mail, string adresa)
        {
            OrderId = orderid;
            Produse = new List<Produs>();
            CustomerName = nume;
            PhoneNumber = nrtel;
            Email = mail;
            Address = adresa;
            Status = "In asteptare";
        }

        public void editare_admin(DateTime date)
        {
            Console.WriteLine("Alegeti noul status al comenzii: ");
            Console.WriteLine("1. In asteptare ");
            Console.WriteLine("2. In curs de livrare ");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    Status = "In asteptare";
                    break;
                case "2":
                    Status = "In curs de livrare";
                    break;
                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }
            DeliveryDate = date;
            Console.WriteLine("Datele comenzii au fost actualizate!");
        }
    }
}
