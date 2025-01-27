using Ambev.DeveloperEvaluation.Application.SalesOrder.DeleteSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSaleOrder
{
    public class DeleteSaleOrderProfile : Profile
    {
        public DeleteSaleOrderProfile()
        {
            CreateMap<DeleteSaleOrderRequest, DeleteSaleOrderCommand>();
        }
    }
}
