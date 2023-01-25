﻿using Ecommerce.Interface.IProductRepository;
using Ecommerce.Interface.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IImageRepository ImageRepository
        {
            get;
        }
        IMinimalRepository MinimalRepository
        {
            get;
        }
        IPriceLimitRepository PriceLimitRepository
        {
            get;
        }
        IProductRepository.IProductRepository ProductRepository
        {
            get;
        }
        IRecommendedRepository RecommendedRepository
        {
            get;
        }
        IRequirementRepository RequirementRepository
        {
            get;
        }
        IRestrictionRepository RestrictionRepository
        {
            get;
        }
        IVideoRepository VideoRepository
        {
            get;
        }
        IUserRepository.IUserRepository UserRepository
        {
            get;
        }

        int Save();
        Task<int> SaveAsync();
    }
}
