﻿using CARRITO.Appication.Interface;
using CARRITO.Appication.Service;
using CARRITO.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARRITO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;

        }
       

        [HttpGet("listar")]
        public async Task<ActionResult<List<Categoria>>> getCategoria()
        {

           // return new JsonResult(await _service.getCategoria());
            try
            {

                var response = await _service.getCategoria();

                if (response == null || response.Count == 0)
                {
                    return NotFound(); // Devolver 404 Not Found si no se encontraron categorías
                }

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, "Se produjo un error al recuperar la lista de categorías.");
            }

        }

        [HttpGet("ListId")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriaByIdAsync(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("El ID de la categoría debe ser mayor que cero.");
                }

                var response = await _service.GetCategoriaByIdAsync(Id);

                if (response == null)
                {
                    return NotFound(); // Devolver 404 Not Found si no se encuentra la categoría
                }

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Se produjo un error al recuperar la lista de categorías.");
            }
        }
        [HttpPost("Save")]
        public async Task<IActionResult> AddCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("La categoria enviada es nula");
            }
            if (string.IsNullOrEmpty(categoria.Nombre) || categoria.Activo <= 0)
            {
                return BadRequest("Todos los campos de la categoría son obligatorios.");
            }

            try
            {
                var response = await _service.AddCategoriaAsync(categoria);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al guardar la categoría en la base de datos.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Se produjo un error al agregar la categoría.");
            }

        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("La categoria enviada es nula");
            }
            try
            {
                var result = await _service.UpdateCategoriaAsync(categoria);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al Actualizar la categoría en la base de datos.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Se produjo un error al Actualizar la categoría.");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategoriaAsync(int Id)
        {
            try
            {
                var response = await _service.DeleteCategoriaAsync(Id);

                if (response == 0)
                {
                    return NotFound(); // Devuelve 404 Not Found si la categoría no fue encontrada
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error al eliminar la categoría."); // Devuelve 500 Internal Server Error si ocurre un error inesperado
            }
        }


    }
}
