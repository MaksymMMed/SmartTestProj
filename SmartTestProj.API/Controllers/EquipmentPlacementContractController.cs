using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("SmartTestProj/[controller]")]
    [ApiController]
    public class EquipmentPlacementContractController : ControllerBase
    {
        private readonly IEquipmentPlacementContractService _equipmentPlacementContractService;

        public EquipmentPlacementContractController(IEquipmentPlacementContractService equipmentPlacementContractService)
        {
            _equipmentPlacementContractService = equipmentPlacementContractService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _equipmentPlacementContractService.GetAll();
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
                var result = await _equipmentPlacementContractService.Delete(id);
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
        public async Task<IActionResult> Create([FromBody] CreateEquipmentPlacementContractDto dto)
        {
            try
            {
                var result = await _equipmentPlacementContractService.Insert(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
