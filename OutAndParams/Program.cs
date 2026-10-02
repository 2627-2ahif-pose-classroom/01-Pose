//Julia Qiana Wimmer 2AHIF -> 1. Project

public static class Calculator
{
    //Add als method
    public static int Add (out double sum, double summand1, double summand2, params double[] summand3)
    {
        sum = summand1 + summand2;
        int count = 2;
        for (int i = 0; i < summand3.Length; i++)
        {
            sum += summand3[i];
            count++;
        }
        return count;
    }
    // sum wird aus den zwei summanden gebildet und mit jedem parameter in summand3 wieder addiert
    //count zählt mit wie oft addiert wurde im gesammten

    //Multiply als method
    public static int Multiply (out double product, double factor1, double factor2, params double[] factor3)
    {
        product = factor1 * factor2;
        int count = 2;
        for (int i = 0; i < factor3.Length; i++)
        {
            product *= factor3[i];
            count++;
        }
        return count;
    }
    // product wird aus den zwei faktoren gebildet und mit jedem parameter in factor3 wieder multipliziert
    //count zählt mit wie oft multipliziert wurde im gesammten

    //Divide als method
    public static int Divide (out double quotient, double divident1, double divident2, params double[] divident3)
    {
        quotient = divident1 / divident2;
        int count = 2;

        for(int i = 0; i < divident3.Length; i++)
        {
            quotient /= divident3[i];
            count++;
        }
        return count;
    }
    // quotient wird aus den zwei dividenten gebildet und mit jedem parameter in divident3 wieder dividiert
    //count zählt mit wie oft dividiert wurde im gesammten
}