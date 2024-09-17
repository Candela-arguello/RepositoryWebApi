using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProyecto2.Models;

namespace WebApiProyecto2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        static List<Articulo> lstArticulos = new List<Articulo>();

        [HttpPost]

        public IActionResult Post([FromBody] Articulo a)
        {
            if (a == null || string.IsNullOrEmpty(a.Nombre) || a.Precio == null)
            {
                return BadRequest("Datos Incorrectos");
            }
            Articulo articulo = new Articulo()
            {
                Nombre = a.Nombre,
                Precio = a.Precio
            };
            lstArticulos.Add(a);
            return Ok("El artículo se registró con éxito");
        }

        //[HttpGet("/{Nombre}")] //No anda

        //public IActionResult GetByName(string nombre)
        //{
        //    foreach (Articulo i in lstArticulos)
        //    {
        //        if (i.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
        //        {
        //            return Ok(i);
        //        }
        //    }
        //    return NotFound();
        //}


        [HttpGet("/{Id}")]

        public IActionResult GetById(int Id)
        {
            foreach (Articulo i in lstArticulos)
            {
                if (i.Id.Equals(Id))
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPut]

        public IActionResult Put(int id, [FromBody] Articulo a)
        {
            foreach (Articulo i in lstArticulos)
            {
                if (i.Id.Equals(id))
                {
                    i.Nombre = a.Nombre;
                    i.Precio = a.Precio;
                    return Ok(i);
                }
            }
            return NotFound("No se pudo actualizar el Artículo");
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            foreach (Articulo i in lstArticulos)
            {
                if (i.Id.Equals(id))
                {
                    lstArticulos.Remove(i);
                    return Ok(i);
                }
            }
            return NotFound("No se ha podido eliminar el artículo");
        }

    }
}
