using Sitecore.Data.Items;
using SitecoreDev.Feature.Articles.Models;

namespace SitecoreDev.Feature.Articles.Repositories
{
  public interface IArticlesRepository
  {
    IArticle GetArticleContent(string contentGuid);
  }
}
