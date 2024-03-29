using CARRITO.Appication.Interface;
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

        public async Task<dynamic> getCategoria()
        {
            return await _repository.getCategoria();


        }

    }
    }
