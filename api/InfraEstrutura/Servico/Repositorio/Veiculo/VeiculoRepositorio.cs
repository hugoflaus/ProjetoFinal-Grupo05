

using System;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade.Usuario;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;


namespace api.InfraEstrutura.Servico.Repositorio.Veiculo
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {

        private readonly EntityContext context;

        public VeiculoRepositorio(EntityContext context){
            this.context = context;
        }

       
    }
}

  