using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCClinica.Data;
using MVCClinica.Models;

namespace MVCClinica.Repository
{
    public static class AdmMedico
    {

        static MedicoDbContext context = new MedicoDbContext();


        public static List<Medico> Listar()
        {
            var medicos = context.Medicos.ToList();
            return medicos;
        }

        public static int Insertar(Medico medico)
        {
            context.Medicos.Add(medico);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

    }
}