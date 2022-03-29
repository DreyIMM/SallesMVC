using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;


        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }


        //operações com FindAll que retornar todos os vendedores
        //Isso está de forma sincrona
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }



    }
}
