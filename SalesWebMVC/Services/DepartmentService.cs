using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        //permite que essa dependencia não seja alterada
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //metodo para retornor todos os departamentos        
        public async Task<List<Department>> findAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    
    
    
    
    }
}
