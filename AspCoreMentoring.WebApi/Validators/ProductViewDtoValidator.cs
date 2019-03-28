using AspCoreMentoring.Service.Common.DTO;
using FluentValidation;

namespace AspCoreMentoring.WebApi.Validators
{
    public class ProductViewDtoValidator : AbstractValidator<ProductViewDto>
    {
        public ProductViewDtoValidator()
        {
            RuleFor(prop => prop.ProductName).NotEmpty().MinimumLength(5).MaximumLength(30);
            RuleFor(prop => prop.QuantityPerUnit).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(prop => prop.UnitPrice).GreaterThan(0);
            RuleFor(prop => prop.Category).NotNull();
            RuleFor(prop => prop.Supplier).NotNull();
        }
    }
}