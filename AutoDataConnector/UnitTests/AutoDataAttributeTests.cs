﻿using System.Collections.Generic;
using System.Linq;
using AutoDataConnector;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace UnitTests
{
    [TestFixture]
    public class AutoDataAttributeTests : TestBase
    {
        [Test]
        public void BuildFrom_Calls_ParameterProvdier_To_Get_Value_For_Each_Parameter()
        {
            //Arrange
            var parameterValueProvider = Any<IParameterValueProvider>();
            var parameterInfos = Any<IList<IParameterInfo>>();
            var methodInfo = Any<IMethodInfo>();
            var testSuite = Any<TestSuite>();

            var autoDataAttribute = new AutoDataAttribute(parameterValueProvider);
            Mock.Get(methodInfo).Setup(m => m.GetParameters()).Returns(parameterInfos.ToArray());

            //Act
            //must call ToArray()
            autoDataAttribute.BuildFrom(methodInfo, testSuite).ToArray();

            //Assert
            foreach (var pi in parameterInfos)
            {
                var piLocal = pi;
                Mock.Get(parameterValueProvider).Verify(p => p.Get(piLocal));
            }
        }
    }
}
