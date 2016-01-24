using Ploeh.AutoFixture;

namespace AutoDataConnector
{
    public class AutoFixtureParameterValueProvider : ParameterValueProvider
    {
        public AutoFixtureParameterValueProvider() : base(new AutoFixtureDataProvider(new Fixture()))
        {
        }
    }
}