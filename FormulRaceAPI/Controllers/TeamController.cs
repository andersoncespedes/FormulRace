
using AutoMapper;
using Core.Entities;
using Core.Interface;
using FormulRaceAPI.Dtos;
using FormulRaceAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FormulRaceAPI.Controllers;
public class TeamController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _map;
    public TeamController(IUnitOfWork unitOfWork, IMapper map){
        _unitOfWork = unitOfWork;
        _map = map;
    }   
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TeamDto>>> GetTeams([FromQuery] Params Params){
        var labs = await _unitOfWork.Teams.paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<TeamDto>>(labs.registros);
        if(mapeo == null) return BadRequest();
        return new Pager<TeamDto>(mapeo, labs.totalRegistros, Params.PageIndex,Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> Guardar(TeamDto ent){
        var mapeo = _map.Map<Team>(ent);
        if(mapeo == null){
            return BadRequest();
        }
        _unitOfWork.Teams.Add(mapeo);
        await _unitOfWork.SaveAsync();

        return Ok(ent);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id){
        var dato= await _unitOfWork.Teams.GetById(id);   
        if(dato == null){
            return BadRequest();
        }
        _unitOfWork.Teams.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> GetById(int id){
        var dato= await _unitOfWork.Teams.GetById(id);   
        if(dato == null){
            return BadRequest();
        }
        return _map.Map<TeamDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeamDto>> Update(TeamDto entity){
        var mapeo = _map.Map<Team>(entity);
        if(mapeo == null) return BadRequest();
        _unitOfWork.Teams.Update(mapeo);
        await _unitOfWork.SaveAsync();
        return Ok(entity);
    }
}
