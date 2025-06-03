using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Application.Services;
using SneakerShop.Domain.Entities;
using SneakersShop.Mapping;
using SneakersShop.Models.Requests;
using SneakersShop.Models.Responses;

namespace SneakersShop.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class JerseyController : ControllerBase
{
    private readonly IJerseyService _jerseyService;

    public JerseyController(IJerseyService jerseyService)
    {
        _jerseyService = jerseyService;
    }

    [HttpGet]
    [ActionName("all")]
    public async Task<ActionResult<List<JerseyResponse>>> GetJerseys()
    {
        return Ok((await _jerseyService.GetAllJerseys()).ToJerseyResponseList());
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ActionName("create")]
    public async Task<ActionResult<string>> CreateJersey([FromBody] JerseyRequest request)
    {
        return Ok(await _jerseyService.CreateJersey(request.ToJersey()));
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch]
    [ActionName("edit")]
    public async Task<ActionResult<string>> EditJersey([FromBody] Jersey request)
    {
        return Ok(await _jerseyService.EditJersey(request));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    [ActionName("delete")]
    public async Task<ActionResult<string>> DeleteJersey([FromBody] string jerseyId)
    {
        return Ok(await _jerseyService.DeleteJersey(jerseyId));
    }
}