using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using CounoGame.Shared.Extensions;
using CounoGame.Shared.Mvvm.ViewModels;

namespace CounoGame.Shared.Mvvm.DataTemplates
{
    public sealed class ViewDataTemplateGenerator
    {
        private const string ViewTemplate = @"<DataTemplate DataType=""{{x:Type vm:{0}}}"">
<v:{1}>
</v:{1}>
</DataTemplate>";

        private static readonly Type ViewModelConventionType = typeof(IViewModel);
        private static readonly Type ViewForTagType = typeof(IViewFor<>);

        private bool TypeRespectsViewModelConvention(Type type)
        {
            var isClass = type.IsClass;
            var isNotAbstract = !type.IsAbstract;
            var isNotInterface = !type.IsInterface;
            var implementsViewModel = ViewModelConventionType.IsAssignableFrom(type);
            return isClass && isNotAbstract && isNotInterface && implementsViewModel;
        }

        private bool TypeRespectsViewConvention(Type type)
        {
            return
                type.GetInterfaces()
                    .Any(intf =>
                        intf.IsGenericType && ViewForTagType.IsAssignableFrom(intf.GetGenericTypeDefinition()));
        }

        public ResourceDictionary GetDataTemplatesFrom(Assembly assembly)
        {
            var dataTemplateResources = new ResourceDictionary();
            var dataTemplates = this.FindViewDataTemplatesInAssembly(assembly);

            if (dataTemplates.Any())
            {
                dataTemplates.ForEach(dt => dataTemplateResources.Add(dt.DataTemplateKey, dt));
            }

            return dataTemplateResources;
        }

        private IEnumerable<Type> FindViewMatchesForViewModel(Type viewModelType, List<Type> viewTypes)
        {
            var genericInterfaces = ViewForTagType.MakeGenericType(viewModelType);
            var viewCandidates = viewTypes.Where(viewType => genericInterfaces.IsAssignableFrom(viewType));
            return viewCandidates;
        }

        private IList<DataTemplate> FindViewDataTemplatesInAssembly(Assembly assembly)
        {
            var viewModelTypes = assembly.GetTypes().Where(this.TypeRespectsViewModelConvention).ToList();
            var viewTypes = assembly.GetTypes().Where(this.TypeRespectsViewConvention).ToList();
            var viewModelTypesWithoutDataTemplate = viewModelTypes;

            if (!viewModelTypesWithoutDataTemplate.Any())
            {
                return new List<DataTemplate>();
            }

            var generatedViewModelDataTemplates = new List<DataTemplate>();
            foreach (var viewModelType in viewModelTypesWithoutDataTemplate)
            {
                var viewTypeCandidates = this.FindViewMatchesForViewModel(viewModelType, viewTypes).ToList();

                if (viewTypeCandidates.Count > 1)
                {
                    throw new MultipleViewDefinitionException(
                        $"Found more than one View match for a single ViewModel. Check Namingconventions. ViewModel - {viewModelType}");
                }

                if (viewTypeCandidates.Count != 1)
                {
                    continue;
                }

                var viewTypeMatch = viewTypeCandidates.First();
                var createdGenericDataTemplate = this.CreateGenericDataTemplate(viewModelType, viewTypeMatch);
                generatedViewModelDataTemplates.Add(createdGenericDataTemplate);
            }

            return generatedViewModelDataTemplates;
        }

        private DataTemplate CreateGenericDataTemplate(Type viewModelType, Type viewType)
        {
            return this.CreateViewModelDataTemplate(viewModelType, viewType);
        }

        private DataTemplate CreateViewModelDataTemplate(Type viewModelType, Type viewType)
        {
            CodeGuard.ArgumentNotNull(viewModelType, "viewModelType");
            CodeGuard.ArgumentNotNull(viewType, "viewType");

            var xaml = string.Format(ViewTemplate, viewModelType.Name, viewType.Name);
            var context = new ParserContext();


            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace,
                viewModelType.Assembly.GetName().Name);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace,
                viewType.Assembly.GetName().Name);

            context.XmlnsDictionary.Add(string.Empty, "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate) XamlReader.Parse(xaml, context);
            return template;
        }
    }
}