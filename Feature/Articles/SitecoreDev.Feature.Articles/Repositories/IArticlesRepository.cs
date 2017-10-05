using Sitecore.Data.Items;

namespace SitecoreDev.Feature.Articles.Repositories
{
  public interface IArticlesRepository
  {
    Item GetArticleContent(string contentGuid);
  }
}
