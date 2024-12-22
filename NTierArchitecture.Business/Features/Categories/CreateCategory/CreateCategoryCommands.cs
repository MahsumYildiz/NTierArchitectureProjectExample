using MediatR;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryCommands(string Name ) : IRequest;
}
