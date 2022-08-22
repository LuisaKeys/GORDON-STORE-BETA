using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Context;
using Modelo.Cadastro;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class EstudioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Estudio> ObterEstudiosClassificadosPorNome()
        {
            return context.Estudios.OrderBy(b => b.Nome);
        }
        public Estudio ObterEstudioPorId(long id)
        {
            return context.Estudios.Where(f => f.EstudioId == id).First();
        }
        public void GravarEstudio(Estudio estudio)
        {
            if (estudio.EstudioId == 0)
            {
                context.Estudios.Add(estudio);
            }
            else
            {
                context.Entry(estudio).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Estudio EliminarEstudioPorId(long id)
        {
            Estudio estudio = ObterEstudioPorId(id);
            context.Estudios.Remove(estudio);
            context.SaveChanges();
            return estudio;
        }
    }
}
