using System;

namespace SitecoreDev.Feature.Articles.Models
{
  public interface IArticle
  {
    Guid Id { get; }
    String Title { get; }
    String Body { get; }
  }
}
