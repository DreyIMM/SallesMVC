using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesWebMVC.Services
{
    public class SellerService
    {
        //permite que essa dependencia não seja alterada
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }


        //operações com FindAll que retornara uma lista com  todos os vendedores
        //Isso está de forma sincrona
        public List<Seller> FindAll()
        {
            //acessa o banco de dados Seller e converte para uma lista
            return _context.Seller.ToList();
        }

        //metodo para inserir vendedor ao banco de dados
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}
