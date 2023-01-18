﻿using Ecommerce.Interface.IProductRepository;
using Ecommerce.Interface.IroductRepository;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.Interface.ProductRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitOfWork.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
            ImageRepository = new ImageRepository(this.context);
            MinimalRepository = new MinimalRepository(this.context);
            PriceLimitRepository = new PriceLimitRepository(this.context);
            ProductRepository = new ProductRepository(this.context);
            RecommendedRepository = new RecommendedRepository(this.context);
            RequirementRepository = new RequirementRepository(this.context);
            RestrictionRepository = new RestrictionRepository(this.context);
            VideoRepository = new VideoRepository(this.context);
        }
        public IImageRepository ImageRepository { get; private set; }

        public IMinimalRepository MinimalRepository { get; private set; }

        public IPriceLimitRepository PriceLimitRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IRecommendedRepository RecommendedRepository { get; private set; }

        public IRequirementRepository RequirementRepository { get; private set; }

        public IRestrictionRepository RestrictionRepository { get; private set; }

        public IVideoRepository VideoRepository { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}