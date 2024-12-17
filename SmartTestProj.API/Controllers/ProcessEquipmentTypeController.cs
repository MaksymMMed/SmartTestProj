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
                throw new Exception("Something went wrong",ex);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var result = await _processEquipmentTypeService.Delete(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProcessEquipmentType dto)
        {
            try
            {
                var result = await _processEquipmentTypeService.Insert(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProcessEquipmentType dto)
        {
            try
            {
                var result = await _processEquipmentTypeService.Update(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }
    }
}
