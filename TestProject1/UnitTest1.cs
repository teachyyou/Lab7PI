namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(Program.CalculateExpression("3 4 +"),7);
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(Program.CalculateExpression("3 4 * 12 -"), 0);
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(Program.CalculateExpression("3 4 - -1 *"), 1);
        }
    }
}