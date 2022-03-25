using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
           
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;          
        }

        //Adicionando um vendedor ao departamento
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //Total de vendas do departamento em um intervalo de Datas

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final));
        }


    }
}
