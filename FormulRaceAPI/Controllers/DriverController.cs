using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using FormulRaceAPI.Helpers;
using FormulRaceAPI.Dtos;
using AutoMapper;
namespace FormulRaceAPI.Controllers;
public class DriverController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private  IMapper _map;
    public DriverController(IUnitOfWork unitOfWork, IMapper map)
    {
        _unitOfWork = unitOfWork;
        _map = map;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DriverDto>>> GetTeams([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Drivers.paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<DriverDto>>(labs.registros);
        if(mapeo == null) return BadRequest();
        return new Pager<DriverDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> Guardar(DriverDto ent)
    {
        var mapeo = _map.Map<Driver>(ent);
        if (ent == null)
        {
            return BadRequest();
        }
        _unitOfWork.Drivers.Add(mapeo);
        await _unitOfWork.SaveAsync();

        return Ok(ent);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Drivers.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Drivers.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Drivers.GetById(id);
        var mapeo = _map.Map<DriverDto>(dato);
        if (dato == null)
        {
            return BadRequest();
        }
        return mapeo;
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DriverDto>> Update(DriverDto entity)
    {
        var mapeo = _map.Map<Driver>(entity);
        _unitOfWork.Drivers.Update(mapeo);
        await _unitOfWork.SaveAsync();
        return Ok(entity);
    }
}
