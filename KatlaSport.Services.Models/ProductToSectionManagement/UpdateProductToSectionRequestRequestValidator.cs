using FluentValidation;

namespace KatlaSport.Services.ProductManagement
{
    public class UpdateProductToSectionRequestRequestValidator:AbstractValidator<UpdateProductToSectionRequestRequest>
    {
        public UpdateProductToSectionRequestRequestValidator()
        {
            RuleFor(r => r.HiveSectionId).GreaterThan(0);
            RuleFor(r => r.ProductId).GreaterThan(0);
            RuleFor(r => r.Status).Equal(false);
            RuleFor(r => r.Quantity).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
        }
    }
}
