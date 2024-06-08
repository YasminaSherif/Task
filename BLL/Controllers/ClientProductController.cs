using BLL.DTO.ClientProduct;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProductController : ControllerBase
    {
        private readonly IClinetProductService _clinetProductService;

        public ClientProductController(IClinetProductService clinetProductService)
        {
            _clinetProductService = clinetProductService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientProduct(ClientProductCreateDto clientProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdClientProduct = await _clinetProductService.CreateClientProduct(clientProduct);
                    return Created(nameof(GetClientProductById), createdClientProduct);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProduct(string id)
        {
            try
            {
                var result = await _clinetProductService.DeleteClientProduct(id);
                if (result)
                {
                    return Ok();
                }
                return NotFound("ClientProduct not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClientProduct(string id, ClientProductUpdate clientProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedClientProduct = await _clinetProductService.UpdateClientProduct(id, clientProduct);
                    if (updatedClientProduct != null)
                    {
                        return Ok(updatedClientProduct);
                    }
                    return NotFound("ClientProduct not found");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientProductById(string id)
        {
            try
            {
                var clientProduct = await _clinetProductService.GetClientProductById(id);
                if (clientProduct != null)
                {
                    return Ok(clientProduct);
                }
                return NotFound("ClientProduct not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
