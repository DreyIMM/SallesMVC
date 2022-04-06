using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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
        public async Task<List<Seller>> FindAllAsync()
        {
            //acessa o banco de dados Seller e converte para uma lista
            return await  _context.Seller.ToListAsync();
        }

        //metodo para inserir vendedor ao banco de dados
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj); // Feita em memoria local
            //E Save ocorre no banco de dados

            await _context.SaveChangesAsync(); 
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityExceptions("Cannot delete this seller because has sales for her/him ");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
            
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

           

        }

    }
}
