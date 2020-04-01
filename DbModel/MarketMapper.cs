using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
                                                                source => source.Product.Name));
                                                     




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
