using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;

namespace UnityCleanArchitectureExample
{
    public class CounterInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<CountUpdatedMessage>(options);
            builder.Register<CountDBGateway>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CountUsecase>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CountPresenter>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
         

        }
        public T RegisterPrefabInject<T>(T prefab, Transform parent) where T : UnityEngine.Object
        {
            return Container.Instantiate(prefab, parent);
        }
        public T RegisterPrefabInject<T>(T prefab) where T : UnityEngine.Object
        {
            return Container.Instantiate(prefab);
        }
        public void Inject(object instance) => Container.Inject(instance);
    }

}

