using CARRITO.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Infrastructure.Interface
{
    public interface ICategoriaRepository
    {

        /// public Task<dynamic> getCategoria();

        public Task<List<Categoria>> getCategoria();
        public Task<IEnumerable<Categoria>> GetCategoriaByIdAsync(int Id);
        public Task<int> AddCategoriaAsync(Categoria categoria);
        public Task<int> UpdateCategoriaAsync(Categoria categoria);
        public Task<int> DeleteCategoriaAsync(int Id);

    }
}
