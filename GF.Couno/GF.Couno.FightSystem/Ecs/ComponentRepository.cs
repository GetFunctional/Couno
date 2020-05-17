using System;
using System.Collections.Generic;

namespace GF.Couno.FightSystem.Ecs
{
    internal sealed class ComponentRepository : IExternalComponentRepository
    {
        private static readonly Dictionary<Type, int> ComponentTypeLookup = new Dictionary<Type, int>();

        public ComponentRepository()
        {
            InternalComponentDictionary = new Dictionary<int, IComponent>();
        }

        private Dictionary<int, IComponent> InternalComponentDictionary { get; }

        public TComponent GetComponent<TComponent>() where TComponent : IComponent
        {
            return (TComponent) GetComponent(typeof(TComponent));
        }

        public void ChangeComponent<TComponent>(Func<TComponent, TComponent> changeFunction)
            where TComponent : IComponent
        {
            var existingComponent = GetComponent<TComponent>();
            var newComponent = changeFunction(existingComponent);
            ReplaceComponent(newComponent);
        }

        public IComponent GetComponent(Type componentType)
        {
            return InternalComponentDictionary[GetComponentKey(componentType)];
        }

        internal static void RegisterComponentTypes(Dictionary<int, Type> types)
        {
            foreach (var componentType in types) ComponentTypeLookup.Add(componentType.Value, componentType.Key);
        }

        internal void AddComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            InternalComponentDictionary.Add(GetComponentKey(component), component);
        }

        internal void ReplaceComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            InternalComponentDictionary[GetComponentKey(component)] = component;
        }

        internal void RemoveComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            InternalComponentDictionary.Remove(GetComponentKey(component));
        }

        private static int GetComponentKey(IComponent component)
        {
            return GetComponentKey(component.GetType());
        }

        private static int GetComponentKey(Type componentType)
        {
            return ComponentTypeLookup[componentType];
        }

        public void AddComponents(IEnumerable<IComponent> components)
        {
            foreach (var component in components) AddComponent(component);
        }
    }
}