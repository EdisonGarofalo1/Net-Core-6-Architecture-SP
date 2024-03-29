using CARRITO.Domain.Entity;
using CARRITO.Infrastructure.Data;
using CARRITO.Infrastructure.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Infrastructure.Repository
{
    public class CategoriaRepository: ICategoriaRepository
    {
        public readonly IDbConnection connection;
        public CategoriaRepository(ConnectionService connectionService)
          
        {

            string consql = connectionService.getConnection();
            connection = new SqlConnection(consql);

        }

      

        public async Task<List<Categoria>> getCategoria()
        {
            DynamicParameters parametro = new DynamicParameters();
            IEnumerable<Categoria> lista = await connection.QueryAsync<Categoria>("listaCategoria", parametro, commandType: CommandType.StoredProcedure);
            return lista.ToList();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriaByIdAsync(int Id)
        {
            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@IdCategoria", Id);
            IEnumerable<Categoria> list = await connection.QueryAsync<Categoria>("listaBuscarCategoria", parametro, commandType: CommandType.StoredProcedure);
            return list.ToList();


        }

        public async Task<int> AddCategoriaAsync(Categoria categoria)
        {

            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@IdCategoria", categoria.IdCategoria);
            parametro.Add("@Nombre", categoria.Nombre);
            parametro.Add("@Activo", categoria.Activo);
            var resultado  = await connection.ExecuteAsync("insertarModificarCategoria", parametro, commandType: CommandType.StoredProcedure);
            return resultado;

        }

        public async Task<int> UpdateCategoriaAsync(Categoria categoria)
        {
            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@IdCategoria", categoria.IdCategoria);
            parametro.Add("@Nombre", categoria.Nombre);
            parametro.Add("@Activo", categoria.Activo);
            var resultado = await connection.ExecuteAsync("insertarModificarCategoria", parametro, commandType: CommandType.StoredProcedure);
            return resultado;
        }

        public async Task<int> DeleteCategoriaAsync(int Id)
        {
            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@IdCategoria", Id);
      
            var resultado = await connection.ExecuteAsync("DeleteCategoriaByID", parametro, commandType: CommandType.StoredProcedure);
            return resultado;


        }

        
    }
}
