using BackStage.Controllers;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        public FabricController controller;
        [SetUp]
        public void Setup()
        {
            controller = new FabricController();
        }

        [Test]
        public void Test1()
        {
            var a =controller.CallFabric(1.ToString(), 2.ToString());
            Assert.NotNull(a);
        }
    }
}