using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Appication.Interface
{
    public interface ICategoriaService
    {
        public Task<dynamic> getCategoria();
    }
}
