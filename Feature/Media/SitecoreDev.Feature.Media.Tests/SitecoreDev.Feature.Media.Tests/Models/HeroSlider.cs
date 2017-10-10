using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
  public class HeroSlider : CmsEntity, IHeroSlider
  {
    public IEnumerable<IHeroSliderSlide> Slides { get; set; }
  }
}