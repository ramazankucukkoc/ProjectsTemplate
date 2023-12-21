using Application.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //-----------------DbContext------------------------------------------
            services.AddDbContext<ProjectDbContext>();

            //-----------------Repositories------------------------------------------
            services.AddScoped<IPersonelRepository, PersonelRepository>();
            services.AddScoped<IProductBranchRepository, ProductBranchRepository>();
            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<IDepartmanRepository, DepartmanRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICreditCartRepository, CreditCartRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserCommentRepository, UserCommentRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IParentCategoryRepository, ParentCategoryRepository>();
            services.AddScoped<IFindeksCreditRateRepository, FindeksCreditRateRepository>();
            services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();

            //-------------------------Core.Domain------------------------------------
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }

    }
}
