using AutoMapper;
using FayShop.Catalog.Dtos.CategoryDtos;
using FayShop.Catalog.Entities;
using FayShop.Catalog.Settings;
using MongoDB.Driver;
using System.Collections.Generic;

namespace FayShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    { 
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollactionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            var value=_mapper.Map<Category>(createcategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }


        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {

            var values = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);


        }

        public async Task<List<ResultCategoryDto>> GettAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map< List < ResultCategoryDto >>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto)
        {
            var values = _mapper.Map<Category>(updatecategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updatecategoryDto.CategoryID, values);
        }
    }
}
