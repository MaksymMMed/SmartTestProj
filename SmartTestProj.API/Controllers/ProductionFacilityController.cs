using Microsoft.AspNetCore.Mvc;
using SmartTestProj.BLL.Dto.ProductionFacility;
using SmartTestProj.BLL.Services.Interfaces;

namespace SmartTestProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionFacilityController : ControllerBase
    {
        private readonly IProductionFacilityService _productionFacilityService;

        public ProductionFacilityController(IProductionFacilityService productionFacilityService)
        {
            _productionFacilityService = productionFacilityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _productionFacilityService.GetAll();
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
                var result = await _productionFacilityService.Delete(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductionFacilityDto dto)
        {
            try
            {
                var result = await _productionFacilityService.Insert(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductionFacilityDto dto)
        {
            try
            {
                var result = await _productionFacilityService.Update(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong", ex);
            }
        }
    }
}
