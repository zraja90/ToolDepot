using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolDepot.Areas.Admin.Models.Products;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Models;
using ToolDepot.Models.Common;
using ToolDepot.Models.Products;

namespace ToolDepot.Mappers
{
    public static class MappingExtensions
    {
        
        #region Product
        public static CreateProductModel ToModel(this Product entity)
        {
            return Mapper.Map<Product, CreateProductModel>(entity);
        }

        public static Product ToEntity(this CreateProductModel model)
        {
            return Mapper.Map<CreateProductModel, Product>(model);
        }

        public static Product ToEntity(this CreateProductModel model, Product destination)
        {
            return Mapper.Map(model, destination);
        }

        public static CreateCategoryModel ToModel(this ProductCategory entity)
        {
            return Mapper.Map<ProductCategory, CreateCategoryModel>(entity);
        }

        public static ProductCategory ToEntity(this CreateCategoryModel model)
        {
            return Mapper.Map<CreateCategoryModel, ProductCategory>(model);
        }

        public static ProductCategory ToEntity(this CreateCategoryModel model, ProductCategory destination)
        {
            return Mapper.Map(model, destination);
        }


        public static SubscriptionModel ToModel(this EmailSubscription entity)
        {
            return Mapper.Map<EmailSubscription, SubscriptionModel>(entity);
        }

        public static EmailSubscription ToEntity(this SubscriptionModel model)
        {
            return Mapper.Map<SubscriptionModel, EmailSubscription>(model);
        }

        public static EmailSubscription ToEntity(this SubscriptionModel model, EmailSubscription destination)
        {
            return Mapper.Map(model, destination);
        }


        public static ContactUsModel ToModel(this ContactUs entity)
        {
            return Mapper.Map<ContactUs, ContactUsModel>(entity);
        }

        public static ContactUs ToEntity(this ContactUsModel model)
        {
            return Mapper.Map<ContactUsModel, ContactUs>(model);
        }

        public static ContactUs ToEntity(this ContactUsModel model, ContactUs destination)
        {
            return Mapper.Map(model, destination);
        }


        public static RequestQuoteModel ToModel(this RequestAQuote entity)
        {
            return Mapper.Map<RequestAQuote, RequestQuoteModel>(entity);
        }

        public static RequestAQuote ToEntity(this RequestQuoteModel model)
        {
            return Mapper.Map<RequestQuoteModel, RequestAQuote>(model);
        }

        public static RequestAQuote ToEntity(this RequestQuoteModel model, RequestAQuote destination)
        {
            return Mapper.Map(model, destination);
        }


        public static RepairApptModel ToModel(this RepairAppt entity)
        {
            return Mapper.Map<RepairAppt, RepairApptModel>(entity);
        }

        public static RepairAppt ToEntity(this RepairApptModel model)
        {
            return Mapper.Map<RepairApptModel, RepairAppt>(model);
        }

        public static RepairAppt ToEntity(this RepairApptModel model, RepairAppt destination)
        {
            return Mapper.Map(model, destination);
        }

        public static ProductReviewModel ToModel(this ProductReviews entity)
        {
            return Mapper.Map<ProductReviews, ProductReviewModel>(entity);
        }

        public static ProductReviews ToEntity(this ProductReviewModel model)
        {
            return Mapper.Map<ProductReviewModel, ProductReviews>(model);
        }

        public static ProductReviews ToEntity(this ProductReviewModel model, ProductReviews destination)
        {
            return Mapper.Map(model, destination);
        }


        public static EditProductModel ToModel(this ProductSpecs entity)
        {
            return Mapper.Map<ProductSpecs, EditProductModel>(entity);
        }

        public static ProductSpecs ToEntity(this EditProductModel model)
        {
            return Mapper.Map<EditProductModel, ProductSpecs>(model);
        }

        public static ProductSpecs ToEntity(this EditProductModel model, ProductSpecs destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion
    }
}