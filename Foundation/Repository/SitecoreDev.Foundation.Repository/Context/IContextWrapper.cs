using System.Collections.Specialized;

namespace SitecoreDev.Foundation.Repository.Context
{
  public interface IContextWrapper
  {
    string GetParameterValue(string key);

    bool IsExperienceEditor { get; }
  }
}