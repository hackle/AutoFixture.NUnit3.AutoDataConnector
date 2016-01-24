using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace UnitTests
{
    public class TestBase
    {
        protected IFixture Fixture;

        protected TestBase()
        {
            this.Fixture = new Fixture();

            this.Fixture.Customize(new AutoMoqCustomization());
            this.Fixture.Customize(new MultipleCustomization());
        }

        protected T Any<T>()
        {
            return this.Fixture.Create<T>();
        }
    }
}