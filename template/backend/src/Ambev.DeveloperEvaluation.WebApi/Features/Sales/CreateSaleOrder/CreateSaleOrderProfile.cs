using Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleOrder
{
    public class CreateSaleOrderProfile : Profile
    {
        public CreateSaleOrderProfile()
        {
            CreateMap<CreateSaleOrderRequest, CreateSaleOrderCommand>();
            CreateMap<CreateSaleOrderResult, CreateSaleOrderResponse>();
        }
    }
}
