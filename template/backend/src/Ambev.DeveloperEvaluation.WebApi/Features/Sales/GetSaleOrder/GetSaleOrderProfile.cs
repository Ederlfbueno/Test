using Ambev.DeveloperEvaluation.Application.SalesOrder.GetSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleOrder
{
    public class GetSaleOrderProfile : Profile
    {
        public GetSaleOrderProfile()
        {
            CreateMap<GetSaleOrderResult, GetSaleOrderResponse>();
            CreateMap<SaleOrderProductResult, GetSaleOrderProductResponse>();
        }
    }
}
