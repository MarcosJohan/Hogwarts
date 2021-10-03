using Hogwarts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Services
{
    public interface IRepositorio
    {
        public List<Solicitud> Get();

        public void Post(Solicitud model);

        public void Put(Solicitud model);

        public void Delete(long identificador);
    }
}
