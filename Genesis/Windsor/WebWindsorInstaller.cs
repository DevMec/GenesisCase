using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Genesis.Controllers;
using Genesis.Domain;
using Genesis.Repository;

namespace Genesis.Windsor
{
    internal class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IContactRepository>()
                .ImplementedBy<ContactRepository>()
                .LifestyleScoped());

            container.Register(Component
                .For<ICompanyRepository>()
                .ImplementedBy<CompanyRepository>()
                .LifestyleScoped());

            container.Register(Component
                .For<IContactDomain>()
                .ImplementedBy<ContactDomain>()
                .LifestyleScoped());

            container.Register(Component
                .For<ICompanyDomain>()
                .ImplementedBy<CompanyDomain>()
                .LifestyleScoped());

            container.Register(Classes
                .FromAssemblyContaining<ContactController>()
                .BasedOn<IHttpController>()
                .LifestyleScoped());
        }
    }
}