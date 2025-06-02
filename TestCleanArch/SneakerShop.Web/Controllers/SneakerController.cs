using Microsoft.AspNetCore.Mvc;
using SneakerShop.Application.Services;
using SneakerShop.Domain.Entities;
using SneakersShop.Mapping;
using SneakersShop.Models.Requests;
using SneakersShop.Models.Responses;

namespace SneakersShop.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SneakerController : ControllerBase
{
    private readonly ISneakerService _sneakerService;

    public SneakerController(ISneakerService sneakerService)
    {
        _sneakerService = sneakerService;
    }

    [HttpGet]
    [ActionName("all")]
    public async Task<ActionResult<List<SneakerResponse>>> GetSneakers()
    {
        return Ok((await _sneakerService.GetAllSneakers()).ToSneakerResponseList());
    }

    [HttpPost]
    [ActionName("create")]
    public async Task<ActionResult<string>> CreateSneaker([FromBody] SneakerRequest request)
    {
        return Ok(await _sneakerService.CreateSneaker(request.ToSneaker()));
    }

    [HttpPatch]
    [ActionName("edit")]
    public async Task<ActionResult<string>> EditSneaker([FromBody] Sneaker request)
    {
        return Ok(await _sneakerService.EditSneaker(request));
    }

    [HttpDelete]
    [ActionName("delete")]
    public async Task<ActionResult<string>> DeleteSneaker([FromBody] string sneakerId)
    {
        return Ok(await _sneakerService.DeleteSneaker(sneakerId));
    }
}