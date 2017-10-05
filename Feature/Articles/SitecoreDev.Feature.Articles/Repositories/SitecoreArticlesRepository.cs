using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace SitecoreDev.Feature.Articles.Repositories
{
  public class SitecoreArticlesRepository : IArticlesRepository
  {
    private Database _database;
    public SitecoreArticlesRepository()
    {
      _database = Context.Database;
    }
    public Item GetArticleContent(string contentGuid)
    {
      Assert.ArgumentNotNullOrEmpty(contentGuid, "contentGuid");
      return _database.GetItem(ID.Parse(contentGuid));
    }
  }
}