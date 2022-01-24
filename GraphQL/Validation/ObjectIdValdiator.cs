using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Localization;
using MongoDB.Bson;

namespace GraphQL.Validation
{
    internal class ObjectIdValidator<T, TProperty> : PropertyValidator<T, string>
    {
        private readonly IStringLocalizer localizer;

        public ObjectIdValidator(IStringLocalizer localizer)
        {
            this.localizer = localizer;
        }

        public override string Name => "ObjectIdValidator";

        protected override string GetDefaultMessageTemplate(string errorCode) => localizer["ObjectIdValidationError"].ToString();

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (value == null) return false;

            ObjectId resultId;
            return ObjectId.TryParse(value, out resultId);
        }
    }
}
