# AutoFixture.NUnit3.AutoDataConnector
Connecting AutoData of AutoFixture with NUnit3. Currently implementations depend on NUnit 2 and is tightly coupled to specific version of NUnit.core.

AutoFixture https://github.com/AutoFixture

AutoData and AutoMoqData http://blog.ploeh.dk/2010/10/08/AutoDataTheorieswithAutoFixture/

# NuGet package ID
AutoFixture.NUnit3.AutoDataConnector

This will add a folder named "AutoFixutre.AutoData.NUnit3" to the current project. Avoid rename this folder as any upgrade to the package will override (or create again) it.

The reason the package is not in dll is I can't figure out a way NOT to depend on specific versions of NUnit, Moq or AutoFixture. If you have to install the package for multiple projects, my suggestion is to put the classes in a common project, which in turn can be referenced by other projects. This way you won't have duplicated classes.

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
