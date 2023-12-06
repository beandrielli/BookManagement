using BookManagement.Domain.Interfaces;
using BookManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Service
{
    public class WriterService
    {
        private readonly IRepository<Writer> _writerRepository;

        public WriterService(IRepository<Writer> writerRepoitory)
        {
            _writerRepository = writerRepoitory;
        }

        public Writer GetOrCreateWriter(string name) {

            Writer? writer = _writerRepository.GetByName(name);
            if (writer == null)
            {
                writer = new Writer(name);
                _writerRepository.Save(writer);
            }

            return writer;
        }

    }
}
