
using NUnit.Framework;
using Math;

class ArithTest
{
    [Test]
    public void SimpleArithmetic()
    {
        int r1 = Basic.add(3, 3);
        Assert.AreEqual(r1, 6);

        int r2 = Basic.sub(3, 3);
        Assert.AreEqual(r2, 0);

        int r3 = Basic.mul(3, 3);
        Assert.AreEqual(r3, 9);

        int r4 = Basic.div(3, 3);
        Assert.AreEqual(r4, 1);
    }
    [TestCase(1, 2, 3)]
    [TestCase(2, 2, 4)]
    [TestCase(-1, 4, 3)]
    public void Add(int x, int y, int z)
    {
        int r = Basic.add(x, y);
        Assert.AreEqual(r, z);
    }

    [TestCase(1, 2, -1)]
    [TestCase(2, 2, 0)]
    [TestCase(3, 2, 1)]
    public void Sub(int x, int y, int z)
    {
        int r = Basic.sub(x, y);
        Assert.AreEqual(r, z);
    }

    [TestCase(9, 3, 27)]
    [TestCase(3, 3, 9)]
    [TestCase(-3, -3, 9)]
    public void Mul(int x, int y, int z)
    {
        int r = Basic.mul(x, y);
        Assert.AreEqual(r, z);
    }

    [TestCase(9, 3, 3)]
    [TestCase(3, 3, 1)]
    [TestCase(8, 2, 4)]
    public void Div(int x, int y, int z)
    {
        int r = Basic.div(x, y);
        Assert.AreEqual(r, z);
    }
}