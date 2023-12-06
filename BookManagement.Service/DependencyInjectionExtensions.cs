using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookManagement.Service
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(WriterService));
            services.AddScoped(typeof(BookService));
        }
    }
}
