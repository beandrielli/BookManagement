using BookManagement.Domain.Interfaces;
using BookManagement.Domain.Models;
using BookManagement.Infra.Context;
using BookManagement.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infra
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterInfra(this IServiceCollection services, IConfiguration configuration) { 
            services.AddDbContext<BookManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<Book>), typeof(BookRepository));
            services.AddScoped(typeof(IRepository<Writer>), typeof(WriterRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        }

    }
}
