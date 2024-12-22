using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.Business.Features.Product.CreateProduct;
using NTierArchitecture.Business.Features.Product.GetProducts;
using NTierArchitecture.Business.Features.Product.RemoveProductById;
using NTierArchitecture.Business.Features.Product.UpdateProduct;
using NTierArchitecture.DataAccess.Authorization;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers
{
    public sealed class ProductsController:ApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [RoleFilter("Product.Add")]
        public async Task<IActionResult> Add(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Product.Update")]
        public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Product.Remove")]
        public async Task<IActionResult> RemoveById(RemoveProductByIdCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Product.GetAll")]
        public async Task<IActionResult> GetAll(GetProductQuery request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
    }
}
