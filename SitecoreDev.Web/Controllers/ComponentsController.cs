using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

namespace SitecoreDev.Web.Controllers
{
  public class ComponentsController : SitecoreController
  {
    public ViewResult HeroSlider()
    {
      Item contentItem = null;
      var database = Context.Database;
      if (database != null)
        if (!String.IsNullOrEmpty(
          RenderingContext.Current.Rendering.DataSource))
          contentItem = database.GetItem(new ID(
            RenderingContext.Current.Rendering.DataSource));
      return View(contentItem);
    }
  }
}