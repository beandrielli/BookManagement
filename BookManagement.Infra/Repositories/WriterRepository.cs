using BookManagement.Domain.Models;
using BookManagement.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infra.Repositories
{
    public class WriterRepository : Repository<Writer>
    {
        public WriterRepository(BookManagerDbContext context) : base(context)
        { }

        public override Writer? GetById(int id)
        {
            var query = _context.Writers.Where(_writer => _writer.Id == id && _writer.IsActive);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Writer> GetAll()
        {
            throw new NotImplementedException();
        }


        public override Writer? GetByName(string name)
        {
            var query = _context.Set<Writer>()
                .Where(_writer => _writer.Name == name && _writer.IsActive == true);

            return query.Any() ? query.FirstOrDefault() : null;

        }

        public override void Save(Writer writer)
        {

            _context.Writers.Add(writer);

            _context.SaveChanges();

        }

        public override void Update(Writer writer)
        {

            writer.Update();

            _context.SaveChanges();

        }

        public override void Delete(Writer writer)
        {
            _context.Writers.Remove(writer);

            _context.SaveChanges();

        }
    }
}
