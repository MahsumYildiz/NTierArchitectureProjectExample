using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.WebApi.Abstractions;
using NTierArchitecture.Business.Features.Categories.RemoveCategory;
using NTierArchitecture.Business.Features.Categories.GetCategories;
using NTierArchitecture.DataAccess.Authorization;

namespace NTierArchitecture.WebApi.Controllers
{
    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [RoleFilter("Category.Add")]
        public async Task<IActionResult>Add(CreateCategoryCommands request,CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.Update")]
        public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.Remove")]
        public async Task<IActionResult> RemoveById(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.GetAll")]
        public async Task<IActionResult> GetAll(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
    }
}
