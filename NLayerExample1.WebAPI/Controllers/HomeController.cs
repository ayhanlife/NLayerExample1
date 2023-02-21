using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerExample1.Core;
using NLayerExample1.Core.Dtos;
using NLayerExample1.Core.Service;

namespace NLayerExample1.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        public HomeController(IService<Product> service, IMapper mapper)
        {
            this._service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var p = await _service.GetAllAsync();
            var pr = _mapper.Map<List<ProductDto>>(p.ToList());
            return Ok(pr);
        }
    }
}
