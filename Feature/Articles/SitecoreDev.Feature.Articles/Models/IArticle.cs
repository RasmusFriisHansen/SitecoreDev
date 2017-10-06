using System;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Articles.Models
{
  public interface IArticle : ICmsEntity
  {
    Guid Id { get; }
    String Title { get; }
    String Body { get; }
  }
}
