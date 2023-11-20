using TEABackEndCodingChallenge;

namespace TEATests;

[TestClass]
public class Challenge2Tests
{
    private readonly Challenge2 _challenge = new();
    
    [TestMethod]
    [DataRow(7, "gbcjbdha")]
    [DataRow(0, "edcba")]
    [DataRow(18, "teatime")]
    [DataRow(12, "backend")]
    [DataRow(11, "xiceoad")]
    [DataRow(24, "abcdefghijklmnopqrstuvwxyz")]
    public void MaxDistance(int expected, string input)
    {
        int actual = _challenge.MaxDistance(input);
        Assert.AreEqual(expected, actual);
    }
}
