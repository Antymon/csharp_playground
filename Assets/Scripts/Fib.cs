
//fibonaci numbers in O(logn) time, 0(1) space
//todo: overflow
public class Fib  {

	public static int Get(int index)
    {
        if(index < 0)
        {
            return 0;
        }

        int[][] result = new[] { new[] { 1, 0 }, new[] { 0, 1 } }; //identity matrix

        int[][] powMatrix = new[] { new[] { 0, 1 }, new[] { 1, 1 } }; //magic matrix whose powers are fib numbers with indeces 2^exponent-1

        do
        {
            if (index % 2 == 1)
            {
                result = Mul2x2(result, powMatrix);
            }

            powMatrix = Mul2x2(powMatrix, powMatrix);
        }
        while ((index >>= 1) > 0);

        return result[1][1];
    }

    private static int[][] Mul2x2(int[][] m1, int[][] m2)
    {
        int[][] res = new int[2][];

        res[0] = new int[2];
        res[1] = new int[2];

        res[0][0] = m1[0][0] * m2[0][0] + m1[1][0] * m2[0][1];
        res[1][0] = m1[0][0] * m2[1][0] + m1[1][0] * m2[1][1];
        res[0][1] = m1[0][1] * m2[0][0] + m1[1][1] * m2[0][1];
        res[1][1] = m1[0][1] * m2[1][0] + m1[1][1] * m2[1][1];

        return res;
    }
}
