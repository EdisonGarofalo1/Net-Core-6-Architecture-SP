using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARRITO.Infrastructure.Data
{
    
    public class ConnectionService
    {
        private readonly IConfiguration _configuration;

        public ConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string getConnection()
        {

            return _configuration.GetConnectionString("Connection");
        }

    }
}
