using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessEquipmentTypeController : ControllerBase
    {
        private readonly IProcessEquipmentTypeService _processEquipmentTypeService;

        public ProcessEquipmentTypeController(IProcessEquipmentTypeService processEquipmentTypeService)
        {
            _processEquipmentTypeService = processEquipmentTypeService;
        }

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

        [HttpDelete]
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
