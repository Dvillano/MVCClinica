using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCClinica.Models;

namespace MVCClinica.Data
{
    internal class MedicoDbContext : DbContext
    {
        public MedicoDbContext() : base("KeyDb") { } //Constructor
        public DbSet<Medico> Medicos { get; set; }
    }
}