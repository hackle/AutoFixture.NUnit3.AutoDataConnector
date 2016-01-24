using System;
using System.Reflection;
using Ploeh.AutoFixture;

namespace AutoDataConnector
{
    public class AutoFixtureDataProvider : ITypedDataProvider
    {
        private readonly IFixture _fixture;

        public AutoFixtureDataProvider(IFixture fixture, params ICustomization[] customizations)
        {
            _fixture = fixture;

            foreach (var c in customizations)
            {
                _fixture.Customize(c);
            }
        }

        public object CreateFrozenValue(Type type)
        {
            return this.CallGeneric(type, "Freeze");
        }

        public object CreateValue(Type type)
        {
            return this.CallGeneric(type, "Create");
        }

        private object CallGeneric(Type type, string methodName)
        {
            var methodInfo = this.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            var generic = methodInfo.MakeGenericMethod(type);

            return generic.Invoke(this, null);
        }

        // ReSharper disable once UnusedMember.Local

        private T Create<T>()
        {
            return this._fixture.Create<T>();
        }

        // ReSharper disable once UnusedMember.Local

        private T Freeze<T>()
        {
            return this._fixture.Freeze<T>();
        }
    }
}