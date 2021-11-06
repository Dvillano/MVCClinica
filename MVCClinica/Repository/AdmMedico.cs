using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static Medico Detalle(int id)
        {
            return context.Medicos.Find(id);
        }

        public static Medico Buscar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }

        public static int Insertar(Medico medico)
        {
            context.Medicos.Add(medico);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Editar(Medico medico)
        {
            context.Medicos.Attach(medico);
            return context.SaveChanges();
        }

        public static void Eliminar(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }

        public static List<Medico> ListarPorEspecialidad(string especialidad)
        {
            List<Medico> medicosEspecialidad = (from m in context.Medicos
                                                where m.Especialidad == especialidad
                                                select m).ToList();
            return medicosEspecialidad;
        }


    }
}