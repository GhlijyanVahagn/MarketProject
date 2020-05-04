using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbModel.Model.BasketModel;
using DbModel.Products;
using DbModel.ViewModel;

namespace DbModel
{
    public static class MarketMapper
    {
        public static  Mapper Mapper;
        private static MapperConfiguration configuration;
        static MarketMapper()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Unit, ProductUnitViewModel>().ReverseMap();
                cfg.CreateMap<Producer, ProducerViewModel>().ReverseMap();
                cfg.CreateMap<ProductGroup, ProductGroupViewModel>().ReverseMap();

                cfg.CreateMap<Product, ProductViewModel>().ForMember(destination => destination.producerView,
                                                                map => map.MapFrom(
                                                                source => source.Producer))
                                                     .ForMember(destination => destination.groupView,
                                                                map => map.MapFrom(
                                                                source => source.ProductGroup))
                                                      .ForMember(destination => destination.unitView,
                                                                map => map.MapFrom(
                                                                source => source.Unit)).ReverseMap() ;

                cfg.CreateMap<Warehouse, WarehouseViewModel>().ForMember(destination => destination.ProductView,
                                                                    map => map.MapFrom(source => source.Products))
                                                             .ForMember(destination => destination.ProductId,
                                                                    map => map.MapFrom(source => source.ProductId))
                                                             .ForMember(destination => destination.Id,
                                                                    map => map.MapFrom(source => source.Id))

                                                              .ForMember(destination => destination.Price,
                                                                    map => map.MapFrom(source => source.Price))
                                                              .ForMember(destination => destination.RetailSalePrice,
                                                                    map => map.MapFrom(source => source.RetailPrice))
                                                              .ForMember(destination => destination.WholeSalePrice,
                                                                    map => map.MapFrom(source => source.WholeSalePrice))
                                                              .ForMember(destination => destination.Remind,
                                                                    map => map.MapFrom(source => source.TotalRemind))

                                                              .ForMember(destination => destination.Unit,
                                                                    map => map.MapFrom(source => source.Products.Unit.Name))
                                                              .ForMember(destination => destination.Group,
                                                                    map => map.MapFrom(source => source.Products.ProductGroup.Name))
                                                              .ForMember(destination => destination.Producer,
                                                                    map => map.MapFrom(source => source.Products.Producer.Name))

                                                                        .ForMember(destination => destination.Code,
                                                                    map => map.MapFrom(source => source.Products.UnicCode))
                                                              .ForMember(destination => destination.BarCode,
                                                                    map => map.MapFrom(source => source.Products.BarCode))
                                                              .ForMember(destination => destination.Product,
                                                                    map => map.MapFrom(source => source.Products.Name))
                                                                    ;


                //cfg.CreateMap<ProductViewModel, Product>().ForMember(destination => destination.ProducerId,
                //                                               map => map.MapFrom(
                //                                               source => source.ProducerId))
                //                                    .ForMember(destination => destination.GroupId,
                //                                               map => map.MapFrom(
                //                                               source => source.GroupId))
                //                                     .ForMember(destination => destination.UnitId,
                //                                               map => map.MapFrom(
                //                                               source => source.UnitId))
                //                                    .ForMember(destination => destination.Producer,
                //                                               map => map.MapFrom(x=>x.))
                //                                    .ForMember(destination => destination.GroupId,
                //                                               map => map.MapFrom(
                //                                               source => source.GroupId))
                //                                     .ForMember(destination => destination.UnitId,
                //                                               map => map.MapFrom(
                //                                               source => source.UnitId));

                cfg.CreateMap<Sale, SaleViewModel>().ForMember(destination => destination.ProductName,
                                                                map => map.MapFrom(
                                                                source => source.Product.Name))
                                                    .ForMember(destination => destination.ProductUnit,
                                                                map => map.MapFrom(
                                                                source => source.Product.Unit.Name))
                                                     .ForMember(destination => destination.ProductCode,
                                                                map => map.MapFrom(
                                                                source => source.Product.UnicCode)) ;
                                                               

                cfg.CreateMap<BasketItem, Sale>().ForMember(destination => destination.TransactionId,
                                                                map => map.Ignore())
                                                  .ForMember(destination => destination.Transaction,
                                                                map => map.Ignore())
                                                   .ForMember(destination => destination.Id,
                                                                map => map.Ignore())
                                                   .ForMember(destination => destination.Payed,
                                                                map => map.MapFrom(
                                                                    source => source.Payed))
                                                   .ForMember(destination => destination.Product,
                                                                map => map.Ignore())
                                                                    ;



                cfg.CreateMap<BasketItem, Buy>().ForMember(destination => destination.TransactionId,
                                                                map => map.Ignore())
                                                  .ForMember(destination => destination.Transaction,
                                                                map => map.Ignore())
                                                  .ForMember(destination => destination.Id,
                                                                map => map.Ignore())
                                                  .ForMember(destination => destination.Product,
                                                                map => map.Ignore())
                                                                ;


                cfg.CreateMap<Transaction, TransactionVieweModel>();

            });
            configuration.AssertConfigurationIsValid();

        }
        public static void RegisterAutoMapper()
        {
            if(Mapper==null)
                Mapper = new Mapper(configuration);
        }
    }
}
