using System;
using System.Linq;
using Sitecore.Mvc.Presentation;
namespace SitecoreDev.Foundation.Repository.Context
{
  public class SitecoreContextWrapper : IContextWrapper
  {
    public string GetParameterValue(string key)
    {
      var value = String.Empty;
      var parameters = RenderingContext.Current.Rendering.Parameters;
      if (parameters != null && parameters.Count() > 0)
        value = parameters[key];
      return value;
    }

    public bool IsExperienceEditor
    {
      get
      {
        return Sitecore.Context.PageMode.
          IsExperienceEditor;
      }
    }
  }
}