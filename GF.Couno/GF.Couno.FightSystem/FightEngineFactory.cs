using System;
using System.Reflection;
using LightInject;
using MediatR;
using MediatR.Pipeline;

namespace GF.Couno.FightSystem
{
    internal class FightEngineFactory
    {
        internal FightEngine CreateFightEngine()
        {
            var dependencyContainer = new ServiceContainer();
            UseMediatR(dependencyContainer);

            // Return new Runtime
            var mediator = dependencyContainer.GetInstance<IMediator>();
            return new FightEngine(mediator);
        }


        private void UseMediatR(IServiceContainer dependencyContainer)
        {
            // Register Classes in DI Container
            dependencyContainer.Register<IMediator, Mediator>();
            dependencyContainer.Register<ServiceFactory>(x => x.GetInstance);
            RegisterPipelines(dependencyContainer, Assembly.GetAssembly(typeof(FightEngine)));
        }

        private void RegisterPipelines(IServiceContainer serviceContainer, Assembly localAssembly)
        {
            serviceContainer.RegisterAssembly(localAssembly, IsRequestHandler);

            serviceContainer.RegisterOrdered(typeof(IPipelineBehavior<,>),
                new[]
                {
                    typeof(RequestPreProcessorBehavior<,>),
                    typeof(RequestPostProcessorBehavior<,>)
                }, type => new PerContainerLifetime());
        }

        private bool IsRequestHandler(Type serviceType, Type implementingType)
        {
            return serviceType.IsConstructedGenericType &&
                   (
                       serviceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                       serviceType.GetGenericTypeDefinition() == typeof(INotificationHandler<>)
                   );
        }
    }
}