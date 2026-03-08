using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VetClinicApp
{
    public static class Database
    {
        public static string ConnectionString =
            "Server=localhost;Database=VetClinicDB;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}