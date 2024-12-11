namespace MatrixLib
{
    public static class Matrix
    {
        public static double[,] CreateMatrix(int dimension)
        {
            var result = new double[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    result[i, j] = Random.Shared.NextDouble();
                }
            }
            return result;
        }

        public static void MultiplreOneElement(object? param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            MatrixParams matrixParams = (MatrixParams)param;
            double result = 0;
            for (int mi = 0; mi < matrixParams.dim; mi++)
            {
                result = result + matrixParams.a[matrixParams.i, mi] * matrixParams.b[mi, matrixParams.j];
            }
            matrixParams.c[matrixParams.i, matrixParams.j] = result;
        }

        public static double[,] MultipleMatrix(int dim, double[,] a, double[,] b, Action<int> progress)
        {
            var result = new double[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                progress?.Invoke(i);
                for (int j = 0; j < dim; j++)
                {
                    MultiplreOneElement(new MatrixParams(dim, i, j, a, b, result, null));
                }
            }
            return result;


        }
    }
}
