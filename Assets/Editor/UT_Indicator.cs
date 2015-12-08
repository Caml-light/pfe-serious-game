using NUnit.Framework;
using NSubstitute;
using System;
using Unity;

[TestFixture]
public class UT_Indicator
{
    Indicator ind;


    [SetUp]
    public void SetUp()
    {

        ind = Substitute.For<Indicator>("Test", 100.0, 0.99, 50.0, 1.0);
    }

    [Test]
    public void TestVariables()
    {
        Assert.That(ind.Value == 100.0);
        Assert.That(ind.Name == "Test");
    }

  

    [TearDown]
    public void TearDown()
    {
        ind = null;
    }
}
