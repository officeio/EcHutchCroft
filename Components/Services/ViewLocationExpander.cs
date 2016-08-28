using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace OfficeIO.EcHutchCroft.Website.Components.Services
{
    /// <summary>
    /// Provides help to find views inside the website in non-typical places.
    /// </summary>
    public class ViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return viewLocations.Concat(new[] {
                $"/Pages/{{1}}/{{0}}.cshtml",
                $"/Pages/{{0}}.cshtml"
            });
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Do nothing.
        }
    }
}
