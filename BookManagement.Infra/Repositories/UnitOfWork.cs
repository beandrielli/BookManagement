using BookManagement.Domain.Interfaces;
using BookManagement.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookManagerDbContext _context;

        public UnitOfWork(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
