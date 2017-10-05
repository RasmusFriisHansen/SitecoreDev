using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreDev.Feature.Articles.Models
{
  public interface IArticle
  {
    string Id { get; }
    string Title { get; }
    string Body { get; }
  }
}
