using System;
using Sitecore.Diagnostics;
using Glass.Mapper.Sc;
using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Repositories
{
  public class SitecoreArticlesRepository : IArticlesRepository
  {
    private readonly ISitecoreContext _sitecoreContext;

    public SitecoreArticlesRepository()
    {
      _sitecoreContext = new SitecoreContext();
    }

    public IArticle GetArticleContent(string contentGuid)
    {
      Assert.ArgumentNotNullOrEmpty(contentGuid, "contentGuid");
      return _sitecoreContext.GetItem<IArticle>(Guid.Parse(contentGuid));
    } 
  }
}