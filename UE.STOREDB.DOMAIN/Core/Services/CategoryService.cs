using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.STOREDB.DOMAIN.Core.DTO;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.DOMAIN.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var categoriesDTO = new List<CategoryListDTO>();

            foreach (var category in categories)
            {
                var categoryListDTO = new CategoryListDTO();
                categoryListDTO.Id = category.Id;
                categoryListDTO.Description = category.Description;
                categoriesDTO.Add(categoryListDTO);
            }
            return categoriesDTO;
        }

        public async Task<CategoryListDTO> GetById(int id)
        {
            var category =  await _categoryRepository.GetById(id);
            var categoryDTO = new CategoryListDTO();
            categoryDTO.Id = id;
            categoryDTO.Description = category.Description;
            return categoryDTO;
        }
        public async Task<CategoryProductstDTO> GetByIdWithProducts(int id)
        {
            var category = await _categoryRepository.GetById(id);
            var categoryProductDTO = new CategoryProductstDTO();
            categoryProductDTO.Id = id;
            categoryProductDTO.Description = category.Description;
            var productListDTO = new List<ProductListDTO>();
            foreach (var cp in category.Product)
            {
                var product = new ProductListDTO();
                product.Id = cp.Id;
                product.Description = cp.Description;
                productListDTO.Add(product);
            }
            categoryProductDTO.Products = productListDTO;
            return categoryProductDTO;
        }

        public async Task<IEnumerable<CategoryProductstDTO>> GetWithProducts()
        {
            var categories = await _categoryRepository.GetAll();
            var categoryProducts = new List<CategoryProductstDTO>();

            foreach (var category in categories)
            {
                var categoryProductsDTO = new CategoryProductstDTO();
                categoryProductsDTO.Id = category.Id;
                categoryProductsDTO.Description = category.Description;

                var productListDTO = new List<ProductListDTO>();
                foreach (var cp in category.Product)
                {
                    var product = new ProductListDTO();
                    product.Id = cp.Id;
                    product.Description = cp.Description;
                    productListDTO.Add(product);
                }
                categoryProductsDTO.Products = productListDTO;
                categoryProducts.Add(categoryProductsDTO);
            }
            return categoryProducts;
        }

        public async Task<bool> Create(CategoryCreateDTO categoryCreate)
        {
            var category = new Category();
            category.Description = categoryCreate.Description;
            category.IsActive = true;

            return await _categoryRepository.Insert(category);
        }
    }
}
