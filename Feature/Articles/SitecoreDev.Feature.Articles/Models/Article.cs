using System;

namespace SitecoreDev.Feature.Articles.Models
{
  public class Article : IArticle
  {
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String Body { get; set; }
  }
}