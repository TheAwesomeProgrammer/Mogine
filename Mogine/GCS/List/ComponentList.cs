using System.Collections;
using System.Collections.Generic;
using Mogine.Graphics;

namespace Mogine.GCS.List
{
    public class ComponentList : IEnumerable<Component>
    {
        private List<Component> _components;
        private List<Updateable> _updateableComponents;
        private List<RenderableComponent> _renderableComponents;
        private List<Component> _componentsToAdd;
        private List<Component> _componentsToRemove;

        public ComponentList()
        {
            _components = new List<Component>();
            _updateableComponents = new List<Updateable>();
            _renderableComponents = new List<RenderableComponent>();
            _componentsToAdd = new List<Component>();
            _componentsToRemove = new List<Component>();
        }

        public void Add(Component component)
        {
            _componentsToAdd.Add(component);
        }

        public void Remove(Component component)
        {
            _componentsToRemove.Add(component);
        }
         
        public void UpdateLists()
        {
            foreach (var componentToRemove in _componentsToRemove)
            {
                if (componentToRemove is Updateable)
                {
                    _updateableComponents.Remove(componentToRemove as Updateable);
                }
                else if (componentToRemove is RenderableComponent)
                {
                    _renderableComponents.Remove(componentToRemove as RenderableComponent);
                }
                _components.Remove(componentToRemove);
            }
            _componentsToRemove.Clear();

            foreach (var componentToAdd in _componentsToAdd)
            {
                if (componentToAdd is Updateable)
                {
                    _updateableComponents.Add(componentToAdd as Updateable);
                }
                else if (componentToAdd is RenderableComponent)
                {
                    _renderableComponents.Add(componentToAdd as RenderableComponent);
                }
                _components.Add(componentToAdd);
            }
            _componentsToAdd.Clear();
        }


        public IEnumerator<Component> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }
    }
}