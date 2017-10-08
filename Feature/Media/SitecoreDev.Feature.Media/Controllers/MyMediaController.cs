using System;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Fields;
using Sitecore.Resources.Media;
using SitecoreDev.Feature.Media.Models;
using SitecoreDev.Feature.Media.Repositories;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Feature.Media.ViewModels;
using SitecoreDev.Foundation.Repository.Context;

namespace SitecoreDev.Feature.Media.Controllers
{
  public class MyMediaController : Controller
  {
    private readonly IContextWrapper _contextWrapper;
    private readonly IMediaContentService _mediaContentService;
    private readonly IGlassHtml _glassHtml;

    public MyMediaController(IContextWrapper contextWrapper, IMediaContentService
      mediaContentService, IGlassHtml glassHtml)
    {
      _contextWrapper = contextWrapper;
      _mediaContentService = mediaContentService;
      _glassHtml = glassHtml;
    }
    public ViewResult HeroSlider()
    {
      var viewModel = new HeroSliderViewModel();
      if (!String.IsNullOrEmpty(_contextWrapper.Datasource))
      {
        var contentItem = _mediaContentService.GetHeroSliderContent(_contextWrapper.Datasource);
        foreach (var slide in contentItem?.Slides)
        {
          viewModel.HeroImages.Add(new HeroSliderImageViewModel()
          {
            Image = new HtmlString(_glassHtml.Editable<IHeroSliderSlide>(slide, i => i.Image))
          });
        }
      }

      return View(viewModel);
    }
  }
}