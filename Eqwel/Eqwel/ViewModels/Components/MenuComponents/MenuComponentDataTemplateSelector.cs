using Xamarin.Forms;

namespace Eqwel.ViewModels.Components.MenuComponents
{
    public class MenuComponentDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _menuComponent;

        public MenuComponentDataTemplateSelector()
        { 
            _menuComponent = new DataTemplate(typeof(MenuComponentView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return _menuComponent;
        }
    }
}
