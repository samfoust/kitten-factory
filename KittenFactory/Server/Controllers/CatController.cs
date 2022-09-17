using AutoMapper;
using KittenFactory.Application.Models;
using KittenFactory.Application.Services.Interfaces;
using KittenFactory.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KittenFactory.Server.Controllers
{
    [ApiController]
    [Route("api/cats")]
    public class CatController : ControllerBase
    {
        private readonly ICatService catService;
        private readonly IMapper mapper;
        private readonly ILogger<CatController> _logger;

        public CatController(ICatService catService, IMapper mapper, ILogger<CatController> logger)
        {
            this.catService = catService;
            this.mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CatViewModel>> GetAsync()
        {
            var cats = await catService.GetCatsAsync();
            var mapped = mapper.Map<IEnumerable<CatViewModel>>(cats);
            return mapped;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CatViewModel> GetByIdAsync([FromRoute] int id)
        {
            var cats = await catService.GetByIdAsync(id);
            var mapped = mapper.Map<CatViewModel>(cats);
            return mapped;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<CatViewModel> SaveAsync([FromBody] CatViewModel cat)
        {
            var catModel = mapper.Map<CatModel>(cat);
            var cats = await catService.SaveAsync(catModel);
            var catViewModel = mapper.Map<CatViewModel>(cats);
            return catViewModel;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await catService.DeleteByIdAsync(id);
        }
    }
}
