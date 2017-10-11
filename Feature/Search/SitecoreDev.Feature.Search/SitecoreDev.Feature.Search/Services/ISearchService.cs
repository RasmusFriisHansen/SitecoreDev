using System.Collections.Generic;
using SitecoreDev.Feature.Search.Models;

namespace SitecoreDev.Feature.Search.Services
{
  public interface ISearchService
  {
    IEnumerable<BlogSearchResult> SearchBlogPosts(string searchTerm);
  }
}