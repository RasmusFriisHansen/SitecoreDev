using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Media.ViewModels
{
  public class HeroSliderImageViewModel
  {
    public HtmlString Image { get; set; }
    public bool IsActive { get; set; }
    public string Id { get; set; }
    public string MediaUrl { get; set; }
    public string AltText { get; set; }
  }
}