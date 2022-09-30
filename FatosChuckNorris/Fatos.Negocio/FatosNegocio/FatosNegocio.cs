using Fatos.Infra.Entity;
using Fatos.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fatos.Negocio.FatosNegocio
{
    public class FatosNegocio : IFatosNegocio
    {
        private readonly AppDbContext _context;

        public FatosNegocio(AppDbContext context)
        {
            _context = context;
        }

        public async Task IncluirFatos(FatosModel fatosModel)
        {
            await _context.Fatos.AddAsync(fatosModel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FatosModel>> ObterLista()
        {
            return await _context.Fatos.ToListAsync();
        }
    }
}