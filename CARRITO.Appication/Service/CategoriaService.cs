using CARRITO.Appication.Interface;
using CARRITO.Domain.Entity;
using CARRITO.Infrastructure.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Appication.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {

            _repository = repository;
        }

      

        public async Task<List<Categoria>> getCategoria()
        {
            return await _repository.getCategoria();


        }

        public async Task<IEnumerable<Categoria>> GetCategoriaByIdAsync(int Id)
        {
            return await _repository.GetCategoriaByIdAsync(Id);
        }

        public async Task<int> AddCategoriaAsync(Categoria categoria)
        {
            return await _repository.AddCategoriaAsync(categoria);
        }
        public async Task<int> UpdateCategoriaAsync(Categoria categoria)
        {
            return await _repository.UpdateCategoriaAsync(categoria);
        }

        public async Task<int> DeleteCategoriaAsync(int Id)
        {
            return await _repository.DeleteCategoriaAsync(Id);
        }
      
    }
    }
