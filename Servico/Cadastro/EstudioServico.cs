using Modelo.Cadastro;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastro
{
    public class EstudioServico
    {
        private EstudioDAL estudioDAL = new EstudioDAL();
        public IQueryable<Estudio> ObterEstudiosClassificadosPorNome()
        {
            return estudioDAL.ObterEstudiosClassificadosPorNome();
        }
        public Estudio ObterEstudioPorId(long id)
        {
            return estudioDAL.ObterEstudioPorId(id);
        }
        public void GravarEstudio(Estudio estudio)
        {
           estudioDAL.GravarEstudio(estudio);
        }
        public Estudio EliminarEstudioPorId(long id)
        {
            Estudio estudio = estudioDAL.ObterEstudioPorId(id);
            estudioDAL.EliminarEstudioPorId(id);
            return estudio;
        }
    }
}
