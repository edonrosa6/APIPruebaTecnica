using APIPrueba.Contexts;
using APIPrueba.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    public class CiudadYEstadoController : ControllerBase
    {
        private readonly AppDbContext context;

        public CiudadYEstadoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<CiudadYEstado> GetAll()
        {
            return context.CiudadYEstado.ToList();
        }
    }
}
