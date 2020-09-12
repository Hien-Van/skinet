using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
             :base( x => (string.IsNullOrEmpty(productSpecParams.Search) 
                    || x.Name.ToLower().Contains(productSpecParams.Search)) 
                    && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId )
                    && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId) 
                   )
        {
            AddInclude(p=> p.ProductType);
            AddInclude(p => p.ProductBrand);
            AddOrderBy(p => p.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex -1), productSpecParams.PageSize);
            if(!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            
        }

        public ProductsWithTypesAndBrandsSpecification(int id) :
         base(p => p.Id == id)
        {

            AddInclude(p=> p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}