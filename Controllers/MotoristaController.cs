using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using v1.Services;
using v1.Models;

namespace v1.Controllers
{
    public class MotoristaController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MotoristasController : ControllerBase
        {
            private readonly MotoristaService _motoristaService;

            public MotoristasController(MotoristaService motoristaService)
            {
                _motoristaService = motoristaService;
            }

            [HttpGet]
            public ActionResult<List<Motorista>> Get() =>
                _motoristaService.Get();

            [HttpGet("{id:length(24)}", Name = "GetMotorista")]
            public ActionResult<Motorista> Get(string id)
            {
                var book = _motoristaService.Get(id);

                if (book == null)
                {
                    return NotFound();
                }

                return book;
            }

            [HttpPost]
            public ActionResult<Motorista> Create(Motorista motorista)
            {
                _motoristaService.Create(motorista);

                return CreatedAtRoute("GetMotorista", new { id = motorista.Id.ToString() }, motorista);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, Motorista bookIn)
            {
                var book = _motoristaService.Get(id);

                if (book == null)
                {
                    return NotFound();
                }

                _motoristaService.Update(id, bookIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var book = _motoristaService.Get(id);

                if (book == null)
                {
                    return NotFound();
                }

                _motoristaService.Remove(book.Id);

                return NoContent();
            }
        }
    }
}