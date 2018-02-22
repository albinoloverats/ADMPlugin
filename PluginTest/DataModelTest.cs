using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgGateway.ADAPT.ADMPlugin;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest
{
    [TestFixture]
    public class DataModelTest
    {
        [Test]
        public void GivenTheDataModelTheInstanceIsCreated()
        {
            Assert.NotNull(DataModel.Instance);
        }

        [Test]
        public void GivenTheDataModelInstanceTheModelIsCreated()
        {
            Assert.NotNull(DataModel.Instance.Model);
        }

        [Test]
        public void GivenTheDataModelInstanceModelThereAreTheRightNumberOfTypes()
        {
            Assert.AreEqual(142, DataModel.Instance.Model.GetTypes().Cast<object>().Count());
        }
    }
}
