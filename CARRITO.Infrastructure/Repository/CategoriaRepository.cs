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
        public async Task<dynamic> getCategoria()
        {
            DynamicParameters parametro = new DynamicParameters();
            IEnumerable<dynamic> lista = await connection.QueryAsync<dynamic>("listaCategoria", parametro, commandType: CommandType.StoredProcedure);
            return lista.ToList();
        }

    }
}
