
using KittenFactory.Application.Mapper;
using KittenFactory.Application.Models;
using KittenFactory.Application.Services.Interfaces;
using KittenFactory.Core.Entities;
using KittenFactory.Core.Repositories;

namespace KittenFactory.Application.Services
{
    public class CatService : ICatService
    {
        private readonly ICatRepository catRepository;

        public CatService(ICatRepository catRepository)
        {
            this.catRepository = catRepository;
        }
        public async Task<IEnumerable<CatModel>> GetCatsAsync()
        {
            var cats = await catRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CatModel>>(cats);
            return mapped;

        }
        public async Task<CatModel> GetByIdAsync(int id)
        {
            var cat = await catRepository.GetByIdAsync(id);
            var mapped = ObjectMapper.Mapper.Map<CatModel>(cat);
            return mapped;
        }
        public async Task<CatModel> SaveAsync(CatModel catm)
        {
            var cat = ObjectMapper.Mapper.Map<Cat>(catm);
            await catRepository.SaveAsync(cat);
            catm = ObjectMapper.Mapper.Map<CatModel>(cat);
            return catm;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await catRepository.DeleteByIdAsync(id);
        }
    }
}
