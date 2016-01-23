# AutoFixture.NUnit3.AutoDataConnector
Connecting AutoData of AutoFixture with NUnit3. Currently implementations depend on NUnit 2 and is tightly coupled to specific version of NUnit.core.

AutoFixture https://github.com/AutoFixture
AutoData and AutoMoqData http://blog.ploeh.dk/2010/10/08/AutoDataTheorieswithAutoFixture/

# NuGet package ID
AutoFixture.NUnit3.AutoDataConnector

This will add a folder named "AutoFixutre.AutoData.NUnit3" to the current project.

# Usage
Use [Test, AutoData] to request values to parameters.

        [Test, AutoData]
        public void AnyRandom(DateTime anyTime, CultureInfo cultureInfo)
        {
            Assert.That(anyTime, Is.Not.Null);
            Assert.That(cultureInfo, Is.Not.Null);
        }

Or use [Test, AutoMoqData] to enable Moq customization.

[Frozen] attribute on parameters are also supported.

Implementations is naive at best at this stage, feel free to make improvements.
