using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using SimpleInjector;
using SitecoreDev.Feature.Media.Tests.Models;

namespace SitecoreDev.Feature.Media.Tests
{
  public class TestHarnessBase :ITestHarness
  {
    protected Container _container = new Container();
    protected IFixture _fixture;
    public IFixture Fixture { get { return _fixture; } }
  }
}
