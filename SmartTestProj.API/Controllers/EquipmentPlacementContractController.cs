using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("api/[controller]")]
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
                throw new Exception("Something went wrong",ex);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var result = await _equipmentPlacementContractService.Delete(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
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
                throw new Exception("Something went wrong", ex);
            }
        }
    }
}
