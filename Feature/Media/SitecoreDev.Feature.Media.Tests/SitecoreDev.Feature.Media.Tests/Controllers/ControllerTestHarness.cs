using Glass.Mapper.Sc;
using Moq;
using Ploeh.AutoFixture;
using SimpleInjector;
using SitecoreDev.Feature.Media.Controllers;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Repository.Context;

namespace SitecoreDev.Feature.Media.Tests.Controllers
{
  public class ControllerTestHarness : TestHarnessBase
  {
    private MyMediaController _controller;
    private Mock<IMediaContentService> _mockContentService;
    private Mock<IContextWrapper> _mockContextWrapper;
    private Mock<IGlassHtml> _mockGlassHtml;

    public ControllerTestHarness()
    {
      InitializeContainer();
      _fixture = new Fixture();
      ContextWrapper
        .SetupGet(rc => rc.Datasource)
        .Returns(Fixture.Create<string>());
    }

    public Mock<IContextWrapper> ContextWrapper
    {
      get
      {
        if (_mockContextWrapper == null)
          _mockContextWrapper = Mock.Get(
            _container.GetInstance<IContextWrapper>());
        return _mockContextWrapper;
      }
    }

    public Mock<IMediaContentService> ContentService
    {
      get
      {
        if (_mockContentService == null)
          _mockContentService = Mock.Get(
            _container.GetInstance<IMediaContentService>());
        return _mockContentService;
      }
    }

    public Mock<IGlassHtml> GlassHtml
    {
      get
      {
        if (_mockGlassHtml == null)
          _mockGlassHtml = Mock.Get(_container.GetInstance<IGlassHtml>());
        return _mockGlassHtml;
      }
    }

    public MyMediaController Controller
    {
      get
      {
        if (_controller == null)
          _controller = _container.GetInstance<MyMediaController>();
        return _controller;
      }
    }

    protected void InitializeContainer()
    {
      _container.Register(() =>
        new Mock<IContextWrapper>().Object, Lifestyle.Singleton);
      _container.Register(() =>
        new Mock<IMediaContentService>().Object, Lifestyle.Singleton);
      _container.Register(() =>
        new Mock<IGlassHtml>().Object, Lifestyle.Singleton);
      _container.Register<MyMediaController>(Lifestyle.Transient);
    }
  }
}