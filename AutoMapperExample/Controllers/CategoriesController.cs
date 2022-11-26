using AutoMapper;
using AutoMapperExample.DTOs;
using AutoMapperExample.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // El mapper 
        private readonly IMapper _mapper;
        private readonly CategoryRepository _repository;

        public CategoriesController(IMapper mapper, CategoryRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _repository.GetAll();
            var categoriesVM = _mapper.Map<List<CategoryViewModel>>(categories);
            return Ok(categoriesVM);
        }


        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var category = _repository.GetById(categoryId);
            var vm = _mapper.Map<CategoryViewModel>(category);
            return Ok(vm);
        }

    }
}
