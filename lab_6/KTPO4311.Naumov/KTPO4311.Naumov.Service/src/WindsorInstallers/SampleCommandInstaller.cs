using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4311.Naumov.Lib.src.SampleCommands;

namespace KTPO4311.Naumov.Service.src.WindsorInstallers
{
    class SampleCommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<ExceptionHandlingDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<SecondCommand>().LifeStyle.Singleton

            );
        }
    }
}
