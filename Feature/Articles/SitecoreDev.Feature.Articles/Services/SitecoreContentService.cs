using SitecoreDev.Feature.Articles.Models;
using SitecoreDev.Feature.Articles.Repositories;

namespace SitecoreDev.Feature.Articles.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IArticlesRepository _repository;

    public SitecoreContentService()
    {
      _repository = new SitecoreArticlesRepository();
    }

    public IArticle GetArticleContent(string contentGuid)
    {
      Article article = null;
      var item = _repository.GetArticleContent(contentGuid);
      if (item != null)
      {
        article = new Article();
        article.Id = item.ID.ToString();
        article.Title = item.Fields["Title"]?.Value;
        article.Body = item.Fields["Body"]?.Value;
      }
      return article;
    }
  }
}