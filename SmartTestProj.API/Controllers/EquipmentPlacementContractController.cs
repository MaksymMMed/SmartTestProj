using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.BackgroundServices;
using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Services.Interfaces;
using System.Diagnostics.Contracts;

namespace SmartTestProj.API.Controllers
{
    [Route("SmartTestProj/[controller]")]
    [ApiController]
    public class EquipmentPlacementContractController : ControllerBase
    {
        private readonly IEquipmentPlacementContractService _equipmentPlacementContractService;
        private readonly LoggingService _loggingService;

        public EquipmentPlacementContractController(IEquipmentPlacementContractService equipmentPlacementContractService, LoggingService loggingService)
        {
            _equipmentPlacementContractService = equipmentPlacementContractService;
            _loggingService = loggingService;
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
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid equipmentId,Guid facilityId)
        {
            try
            {
                var result = await _equipmentPlacementContractService.Delete(equipmentId,facilityId);

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

                Hangfire.BackgroundJob.Enqueue(() =>
                _loggingService.LogMessage($"Contract with units count {dto.UnitsCount} created"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
