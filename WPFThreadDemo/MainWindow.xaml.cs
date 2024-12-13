using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace WPFThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int MatrixDimension { get; set; } = 1000;
        readonly double[,] a;
        readonly double[,] b;


        public MainWindow()
        {
            InitializeComponent();
            a = MatrixLib.Matrix.CreateMatrix(MatrixDimension);
            b = MatrixLib.Matrix.CreateMatrix(MatrixDimension);
        }
        private static readonly Action EmptyDelegate = delegate { };
        void CalcMatrix()
        {
           var c = MatrixLib.Matrix.MultipleMatrix(MatrixDimension, a, b, (n) =>
            {
                Dispatcher.Invoke(new Action(() => 
                {
                    pbOneThread.Value = ((double)n + 1) / MatrixDimension * 100;
                }));
                
            });

        }



        private void Start_Click(object sender, RoutedEventArgs e)
        {
            
            var thread1 = new Thread(() =>
            {
                var c = MatrixLib.Matrix.MultipleMatrix(MatrixDimension, a, b, (n) =>
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        pbOneThread.Value = ((double)n + 1) / MatrixDimension * 100;
                    }));

                });

            });
            var thread2 = new Thread(() =>
            {
                int counter = 0;
                for (var i = 0; i < MatrixDimension; i++)
                    for (var j = 0; j < MatrixDimension; j++)
                    {
                        var thread = new Thread(() =>
                        {
                            var c = MatrixLib.Matrix.MultiplreOneElement(new Mat MatrixParams()  MultipleMatrix(MatrixDimension, a, b, (n) =>
                            {
                                Dispatcher.Invoke(new Action(() =>
                                {
                                    pbOneThread.Value = ((double)n + 1) / MatrixDimension * 100;
                                }));

                            });

                        });
                    }

            });




            thread1.Start();
        }
    }
}