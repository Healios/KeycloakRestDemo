using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using MapsterMapper;
using Mapster;
using Company = Core.Models.Company.Company;
using Partner = Core.Models.Partner.Partner;
using User = Core.Models.User.User;
using GraphQL.Queries;
using GraphQL.Mutations;
using HotChocolate.AspNetCore;

namespace GraphQL
{
    public static class Block
    {
        /// <summary>
        /// Hooks up GraphQL.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomGraphQL(this IServiceCollection services)
        {
            //services.AddTransient<IValidator<CompanyInput>, CompanyInputValidator>();
            //services.AddTransient<IValidator<EmployeeInput>, EmployeeInputValidator>();
            //services.AddTransient<IValidator<StoreInput>, StoreInputValidator>();
            //services.AddTransient<IValidator<SaleInput>, SaleInputValidator>();
            //services.AddTransient<IValidator<CreateGiftCardInput>, CreateGiftCardInputValidator>();
            //services.AddTransient<IValidator<UpdateGiftCardInput>, UpdateGiftCardInputValidator>();

            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddScoped<IMapper, ServiceMapper>();
            //TypeAdapterConfig<CreateGiftCardInput, GiftCard>.NewConfig().Map(giftCard => giftCard.Balance, input => input.Amount);

            services.AddGraphQLServer()
                .AddType<Company>()
                .AddType<Partner>()
                .AddType<User>()
                .AddQueryType()
                    .AddTypeExtension<CompanyQuery>()
                    .AddTypeExtension<PartnerQuery>()
                    .AddTypeExtension<UserQuery>()
                .AddMutationType()
                    .AddTypeExtension<CompanyMutation>()
                    .AddTypeExtension<PartnerMutation>()
                    .AddTypeExtension<UserMutation>();

            return services;
        }

        /// <summary>
        /// Enables GraphQL for use.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseCustomGraphQL(this WebApplication app)
        {
            app.MapGraphQL();
            app.UsePlayground();

            return app;
        }
    }
}
