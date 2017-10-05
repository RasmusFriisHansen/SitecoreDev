using System;
using System.Collections.Generic;

namespace SitecoreDev.Feature.Articles.ViewModels
{
  public class BlogCommentViewModel
  {
    public string Name { get; set; }
    public string Comment { get; set; }
    public DateTime DatePosted { get; set; }
  }
  public class BlogPostViewModel
  {
    public string Title { get; set; }
    public bool HasTitle => !String.IsNullOrEmpty(Title);
    public string Body { get; set; }
    public List<BlogCommentViewModel> Comments { get; set; } =
      new List<BlogCommentViewModel>();
    public bool HasComments => Comments.Count > 0;
  }
}