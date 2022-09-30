using Fatos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatos.Negocio.FatosNegocio
{
    public interface IFatosNegocio
    {
        Task IncluirFatos(FatosModel fatosModel);
        Task<List<FatosModel>> ObterLista();
    }
}