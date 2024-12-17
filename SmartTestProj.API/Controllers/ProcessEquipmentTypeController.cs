using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("SmartTestProj/[controller]")]
    [ApiController]
    public class ProcessEquipmentTypeController : ControllerBase
    {
        private readonly IProcessEquipmentTypeService _processEquipmentTypeService;

        public ProcessEquipmentTypeController(IProcessEquipmentTypeService processEquipmentTypeService)
        {
            _processEquipmentTypeService = processEquipmentTypeService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _processEquipmentTypeService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _processEquipmentTypeService.Delete(id);
                return Ok(result);
            }
            catch (KeyNotFoundException notFound)
            {
                return StatusCode(404, notFound.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProcessEquipmentTypeDto dto)
        {
            try
            {
                var result = await _processEquipmentTypeService.Insert(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProcessEquipmentTypeDto dto)
        {
            try
            {
                var result = await _processEquipmentTypeService.Update(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
