﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Product.CreateProduct
{
    public sealed class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı boş olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Ürün adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karekter olmalıdır");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori boş olamaz");
            RuleFor(p => p.CategoryId).NotNull().WithMessage("Kategori boş olamaz");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0 olamaz");
            RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Adet 0 olamaz");
        }
    }
}
