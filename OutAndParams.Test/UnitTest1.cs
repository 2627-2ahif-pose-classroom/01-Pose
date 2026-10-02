namespace OutAndParams.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        double sum; 
        int count = Calculator.Add(out sum, 14, 65, 438, 34, 2, 8);
        Assert.Equal(561, sum); 
        Assert.Equal(6, count); 
    }
    [Fact]
    public void Test2()
    {
        double product;
        int count = Calculator.Multiply(out product, 1, 8, 5);
        Assert.Equal(40, product);
        Assert.Equal(3, count);
    }
    [Fact]
    public void Test3()
    {
        double quotient;
        int count = Calculator.Divide(out quotient, 40, 5, 1);
        Assert.Equal(8, quotient);
        Assert.Equal(3, count);
    }
}
