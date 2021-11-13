using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoAnalisis.modelos;

using proyectoAnalisis.data;

namespace api.Controllers
{
    [Route("api/[action]/{id?}")]
    [ApiController]
    public class marcasController : ControllerBase
    {
        public bool addMarca([FromBody] marcasMod mod)
        {
            return datosMarca.addMarcas(mod);
        }

        public bool updateMarca([FromBody] marcasMod mod)
        {
            return datosMarca.editMarcas(mod);
        }

        public bool deleteMarca([FromBody] marcasMod mod)
        {
            return datosMarca.deleteMarcas(mod);
        }

        

        public List<marcasMod> listDF()
        {
            return datosMarca.listarMarcas();
        }

    
    }
}
