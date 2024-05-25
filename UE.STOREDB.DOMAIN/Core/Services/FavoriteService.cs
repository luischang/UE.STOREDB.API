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
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteListDTO>> GetAll(int userId)
        {
            var favorites = await _favoriteRepository.GetAll(userId);
            if (favorites.Count() == 0)
                return null;
            var favoritesDTO = favorites.Select(favorite => new FavoriteListDTO
            {
                Id = favorite.Id,
                Product = new ProductCategoryDTO
                {
                    Id = favorite.Product.Id,
                    Description = favorite.Product.Description,
                    Price = favorite.Product.Price,
                    Stock = favorite.Product.Stock,
                    Discount = favorite.Product.Discount,
                    ImageUrl = favorite.Product.ImageUrl,
                    Category = new CategoryListDTO
                    {
                        Id = favorite.Product.Category.Id,
                        Description = favorite.Product.Category.Description
                    }
                }
            }).ToList();

            return favoritesDTO;
        }

        public async Task<bool> Insert(FavoriteInsertDTO favoriteDTO)
        {
            var favorite = new Favorite()
            {
                UserId = favoriteDTO.UserId,
                ProductId = favoriteDTO.ProductId,
                CreatedAt = DateTime.Now
            };

            return await _favoriteRepository.Insert(favorite);
        }

        public async Task<bool> Delete(int id)
        {
            return await _favoriteRepository.Delete(id);
        }
    }
}
