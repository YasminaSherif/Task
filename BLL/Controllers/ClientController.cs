using DTO.Client;
using BLL.Services.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientCreateDto client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdClient = await _clientService.CreateClient(client);
                    return Created(nameof(GetClientDetailsById), createdClient);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            else
            {
                var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
                return BadRequest(errors);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var clients = await _clientService.GetAllClients();
                if (clients == null || !clients.Any())
                {
                    return NotFound("No clients found.");
                }
                return Ok(clients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            try
            {
               var result = await _clientService.DeleteClient(id);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch(Exception e)
            {
               return BadRequest(e.Message);
            }
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllClientsWithPaging(int pageNumber,int pageSize)
        {
            try
            {
                var clients = await _clientService.GetAllClientsWithPaging(pageNumber,pageSize);
                if (clients == null || !clients.Any())
                {
                    return NotFound("No clients found for the given page.");
                }
                return Ok(clients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientDetailsById(string id)
        {

            try
            {
                var result = await _clientService.GetClientDetailsById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Client not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, ClientUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedClient = await _clientService.UpdateClient(id, model);
                    if (updatedClient != null)
                    {
                        return Ok(updatedClient);
                    }
                    else
                    {
                        return NotFound("Client not found");
                    }
                }
                catch (ArgumentException e)
                {
                    return BadRequest(e.Message);
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
    }
}

