using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Ef;

namespace Business.DependencyResolvers
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Service Katmanı (Manager'lar)
            builder.RegisterType<CategoryLimitManager>().As<ICategoryLimitService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ExpenseManager>().As<IExpenseService>().InstancePerLifetimeScope();
            builder.RegisterType<RolesManager>().As<IRolesService>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>().InstancePerLifetimeScope();

            // Data Access Katmanı (DAL'lar)
            builder.RegisterType<EfCategoryLimitDal>().As<ICategoryLimitDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfExpenseDal>().As<IExpenseDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfRolesDal>().As<IRolesDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();

        
        }
    }
}
