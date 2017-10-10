using Sitecore.Mvc.ExperienceEditor.Presentation;

namespace SitecoreDev.Foundation.SitecoreExtensions.RenderingWrapper.Markers
{
  public class EditorComponentRenderingMarker : IMarker
  {
    private readonly string _componentName;

    public EditorComponentRenderingMarker(string componentName)
    {
      _componentName = componentName;
    }

    public string GetStart()
    {
      var formatstring =
        "<div class=\"component-wrapper {0}\"><span class=\"wrapperheader\">{1}</span><div class=\"component-content clearfix\">";

      return string.Format(formatstring, _componentName.Replace(" ", string.Empty), _componentName);
    }

    public string GetEnd()
    {
      return "</div></div>";
    }
  }
}