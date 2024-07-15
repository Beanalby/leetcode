using _29___Divided_Two_Integers;
namespace _29___Divided_Two_Integers.Test;

[TestFixture]
public class Tests {
    private Solution solution;
    [SetUp]
    public void Setup() {
        solution = new();
    }

    public static IEnumerable<(int dividend, int divisor, int result)> DataProvider() {
        yield return (int.MaxValue, 1, int.MaxValue);
        yield return ( int.MaxValue, -1, int.MinValue + 1 );
        yield return ( int.MinValue, 1, int.MinValue );
        yield return ( int.MinValue, -1, int.MaxValue );
        yield return (0, 10, 0);
        yield return (3, 3, 1);
        yield return (-3, 3, -1);
        yield return (3, -3, -1);
        yield return (-3, -3, 1);
        yield return (10000, 5, 2000);
        yield return (10, 3, 3);
        yield return (7, -3, -2);
    }

    [TestCaseSource(nameof(DataProvider))]
    public void TestData((int dividend, int divisor, int result) p) {
        Assert.That(p.result, Is.EqualTo(solution.Divide(p.dividend, p.divisor)));
    }
}