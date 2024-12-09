namespace MatrixLib
{
    public class Matrix
    {
        public double[,] CreateMatrix(int dimension)
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

        public void MultiplreOneElement(object? param)
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


    }
}
