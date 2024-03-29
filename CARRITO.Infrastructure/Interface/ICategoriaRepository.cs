using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Infrastructure.Interface
{
    public interface ICategoriaRepository
    {

        public Task<dynamic> getCategoria();
    }
}
