using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Configuration;

using System.Security.Cryptography.X509Certificates;

using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace QualyteamTeste.Models
{
    public class DbConection : DbContext
    {
        public DbConection(DbContextOptions<DbConection> options) : base(options) { 
        }


        public DbSet<Document> Document { get; set; }
        public DbSet<Process> Process { get; set; }

    }


}