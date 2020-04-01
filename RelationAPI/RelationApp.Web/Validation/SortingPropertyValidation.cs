using RelationApp.Core.Exceptions;
using RelationApp.Web.ViewModels;
using System.Text;

namespace RelationApp.Web.Validation
{
    public static class SortingPropertyValidation
    {
        public static void ValidateProperty(string sortingProperty)
        {
            if (!string.IsNullOrEmpty(sortingProperty))
            {
                var RelationViewModelPropertiesArray = typeof(GetRelationViewModel).GetProperties();
                var propertyFound = new StringBuilder();

                foreach (var r in RelationViewModelPropertiesArray)
                {
                    if (r.Name == sortingProperty)
                    {
                        propertyFound.Append(sortingProperty);
                        break;
                    }
                }

                if (string.IsNullOrEmpty(propertyFound.ToString()))
                    throw new InvalidSortingPropertyException($"Sorting Property '{sortingProperty}' doesn't exist");
            }
        }
    }
}
