﻿using FluentValidation;

namespace KatlaSport.Services.ProductManagement
{
    public class UpdateProductToSectionRequestRequestValidator:AbstractValidator<UpdateProductToSectionRequestRequest>
    {
        public UpdateProductToSectionRequestRequestValidator()
        {
            RuleFor(r => r.Quantity).GreaterThanOrEqualTo(0).LessThan(100);
        }
    }
}