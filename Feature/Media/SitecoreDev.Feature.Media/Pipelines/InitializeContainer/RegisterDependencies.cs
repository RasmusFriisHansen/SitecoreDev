using Glass.Mapper.Sc;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Ioc.Pipelines.InitializeContainer;
using SitecoreDev.Foundation.Repository.Context;

namespace SitecoreDev.Feature.Media.Pipelines.InitializeContainer
{
  public class RegisterDependencies
  {
    public void Process(InitializeContainerArgs args)
    {
      args.Container.Register<IMediaContentService, SitecoreMediaContentService>();
      args.Container.Register<IContextWrapper, SitecoreContextWrapper>();
      args.Container.Register<IGlassHtml, GlassHtml>();
    }
  }
}