using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using AutoDataConnector;

using Moq;

using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class AutoDataTests
    {
        [Test, AutoMoqData]
        public void AnyRandom(DateTime anyTime, CultureInfo cultureInfo)
        {
            Assert.That(anyTime, Is.Not.Null);
            Assert.That(cultureInfo, Is.Not.Null);
        }

        [Theory, AutoMoqData]
        public void AnyFreeze([Frozen] DateTime anytime, [Frozen] DateTime anyOtherTime)
        {
            Assert.That(anytime, Is.EqualTo(anyOtherTime));
        }

        [Theory, AutoMoqData]
        public void AnyDi(string anyMessage, [Frozen] IInjected injected, Injectee injectee)
        {
            Mock.Get(injected).Setup(i => i.Echo(anyMessage)).Returns(anyMessage);

            Assert.That(injectee.Say(anyMessage), Is.EqualTo(anyMessage));
        }

        [Theory, AutoMoqData]
        public void AnyMultiple(IList<string> anyStrings)
        {
            //sanity
            Assume.That(Enumerable.Empty<string>(), Is.Empty);
            Assume.That(String.Empty, Is.Empty);

            Assert.That(anyStrings, Is.Not.Empty);

            foreach (var s in anyStrings)
            {
                Assert.That(s, Is.Not.Empty);
            }
        }
    }

    public class Injectee
    {
        private readonly IInjected injected;

        public Injectee(IInjected injected)
        {
            this.injected = injected;
        }

        public string Say(string anything)
        {
            return this.injected.Echo(anything);
        }
    }

    public interface IInjected
    {
        string Echo(string input);
    }
}
