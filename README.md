# Automapper Example
Ejemplo de como usuar automapper

## Crear Mapa
```
using AutoMapper;
using AutoMapperExample.DTOs;
using AutoMapperExample.Entities;

namespace AutoMapperExample.Mappers
{
    public class CategoryProfile : Profile
    {
        // Cada Entidad necesita su propia clase que herede de perfil para crear el mapper
        public CategoryProfile() 
        {
            // Create map crea el map
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Desc, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
            // ForMember mapea propiedades que tienen nombre diferente 
            // Si en tu modelo de datos y tu modelo de vista las propiedades son las mismas entonces no te preocupes por usar ForMemeber
            // ReverseMap quiere decir que puedes mapear Category a CategoryViewModel como CategoryViewModel a Category
        }
    }
}

```

## Registrar AutoMapper en Program.cs para DI 
```
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
```

## Uso de AutoMapper
```
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
```
