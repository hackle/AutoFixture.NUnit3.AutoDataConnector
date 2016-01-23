using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutoDataConnector
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new AutoFixtureParameterValueProvider(new AutoMoqCustomization(), new MultipleCustomization()))
        {
        }
    }
}