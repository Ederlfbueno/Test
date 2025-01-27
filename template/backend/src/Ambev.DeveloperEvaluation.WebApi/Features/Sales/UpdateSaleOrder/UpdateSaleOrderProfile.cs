using Ambev.DeveloperEvaluation.Application.SalesOrder.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleOrderProfile : Profile
    {
        public UpdateSaleOrderProfile()
        {
            CreateMap<UpdateSaleOrderRequest, UpdateSaleOrderCommand>();
        }
    }
}
