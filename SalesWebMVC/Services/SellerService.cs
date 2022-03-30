using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



    }
}
