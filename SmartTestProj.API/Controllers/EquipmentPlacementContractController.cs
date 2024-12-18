using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.BackgroundService;
using SmartTestProj.BLL.BackgroundServices;
using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("SmartTestProj/[controller]")]
    [ApiController]
    public class EquipmentPlacementContractController : ControllerBase
    {
        private readonly IEquipmentPlacementContractService _equipmentPlacementContractService;
        private readonly LoggingService _loggingService;
        private readonly IBackgroundJobService _backgroundJobService;

        public EquipmentPlacementContractController(IEquipmentPlacementContractService equipmentPlacementContractService,
            LoggingService loggingService,
            IBackgroundJobService backgroundJobService)
        {
            _equipmentPlacementContractService = equipmentPlacementContractService;
            _loggingService = loggingService;
            _backgroundJobService = backgroundJobService;
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
                string message = ($"Contract with units count {dto.UnitsCount} created");
                _backgroundJobService.Enqueue(() => _loggingService.LogMessage(message));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
