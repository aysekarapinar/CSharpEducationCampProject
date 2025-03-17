using CSharpEducationCamp501.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducationCamp501.Repositories
{
    public class ProductRepository:IProductRepository
    {
        

        Task<List<ResultProductDto>> IProductRepository.GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.CreateProductAsync(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.GetByProductIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
