using Fatos.Modelo;
using Fatos.Negocio.FatosNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Fatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FatosController : ControllerBase
    {

        private readonly IFatosNegocio _fatos;

        public FatosController(IFatosNegocio fatos)
        {
            _fatos = fatos;
        }

        [HttpPost]
        public async Task IncluirFatos([FromBody] FatosModel fatosModel)
        {
            fatosModel.DataCriacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _fatos.IncluirFatos(fatosModel);
           
            }
        }

        [HttpGet]
        public async Task<List<FatosModel>> Get() => await _fatos.ObterLista();

    }
}
