﻿using FluentValidation;

namespace BusinessRulesAndValidationsRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage(ProductErrors.ProductErrorMessage)
                .Length(2, 25)
                .Must(IsValidName).WithMessage("{Descricao} should be all letters.");
        }

        private bool IsValidName(string arg)
        {
            return false;
        }
    }

    public static class ProductErrors
    {
        public static string IdErrorMessage { get; set; } = "Id field cannot be null or empty.";
        public static string ProductErrorMessage { get; set; } = "Product field cannot be null or empty.";
        public static string NameErrorMessage { get; set; } = "Name field cannot be null or empty.";
        public static string SellerErrorMessage { get; set; } = "Seller field cannot be null or empty.";
        public static string CatRefIdErrorMessage { get; set; } = "CatRefId field cannot be null or empty.";
        public static string QuantityErrorMessage { get; set; } = "Quantity field must be greater than 0.";
    }
}