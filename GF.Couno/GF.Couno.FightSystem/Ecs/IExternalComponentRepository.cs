using System;

namespace GF.Couno.FightSystem.Ecs
{
    internal interface IExternalComponentRepository
    {
        TComponent GetComponent<TComponent>() where TComponent : IComponent;
        void ChangeComponent<TComponent>(Func<TComponent, TComponent> changeFunction) where TComponent : IComponent;
    }
}