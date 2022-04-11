using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class SalesRecordService : Controller
    {
        //Criando uma dependencia do context do Entity Framework

        private readonly SalesWebMvcContext _context;
              
         public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //criar uma operação Encontra por data
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? mindate, DateTime? maxdate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (mindate.HasValue)
            {
                result = result.Where(x => x.Date >= mindate.Value);
            }
            if (maxdate.HasValue)
            {
                result = result.Where(x => x.Date <= maxdate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }


    }
}
