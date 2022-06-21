using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mut_Accout
{
    public class Data_Access
    {
        private string _connectionString;

        public Data_Access(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }


    }

}
