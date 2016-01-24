﻿using System.Linq;
using System.Reflection;

using NUnit.Framework.Interfaces;

using Ploeh.AutoFixture;

namespace AutoDataConnector
{
    public class AutoFixtureParameterValueProvider : IParameterValueProvider
    {
        private readonly IFixture _fixture;

        public AutoFixtureParameterValueProvider(IFixture fixture, params ICustomization[] customizations)
        {
            _fixture = fixture;
            foreach (var c in customizations)
            {
                this._fixture.Customize(c);
            }
        }

        public object Get(IParameterInfo parameterInfo)
        {
            return IsFrozen(parameterInfo) ? this.CreateFrozenValue(parameterInfo) : this.CreateValue(parameterInfo);
        }

        private static bool IsFrozen(IReflectionInfo reflectionInfo)
        {
            return reflectionInfo.GetCustomAttributes<FrozenAttribute>(true).Any();
        }

        private object CreateFrozenValue(IParameterInfo parameter)
        {
            return this.CallGeneric(parameter, "Freeze");
        }

        private object CreateValue(IParameterInfo parameter)
        {
            return this.CallGeneric(parameter, "Create");
        }

        private object CallGeneric(IParameterInfo parameter, string methodName)
        {
            var methodInfo = this.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            var generic = methodInfo.MakeGenericMethod(parameter.ParameterType);

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