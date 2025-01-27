using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation.
    /// </summary>
    public class CreateSaleOrderProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleOrderProfile"/> class.
        /// </summary>
        public CreateSaleOrderProfile()
        {
            // Mapping from command to domain entity
            CreateMap<CreateSaleOrderCommand, SaleOrder>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            // Mapping from sale order product command to sale order product entity
            CreateMap<CreateSaleOrderProductCommand, SaleOrderProduct>();

            // Mapping from domain entity to result object
            CreateMap<SaleOrder, CreateSaleOrderResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SaleOrderNumber, opt => opt.MapFrom(src => src.SalerOrderNumber))
                .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.TotalValue))
                .ForMember(dest => dest.IsSuccessful, opt => opt.MapFrom(_ => true));
        }
    }
}
