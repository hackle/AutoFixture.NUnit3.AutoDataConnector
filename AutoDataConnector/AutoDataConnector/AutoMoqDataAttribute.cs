using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutoDataConnector
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(
                new ParameterValueProvider(new AutoFixtureDataProvider(new Fixture(), new AutoMoqCustomization(),
                    new MultipleCustomization())))
        {
        }
    }
}