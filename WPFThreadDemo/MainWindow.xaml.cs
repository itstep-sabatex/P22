using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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

        public MainWindow()
        {
            InitializeComponent();
        }
        private static readonly Action EmptyDelegate = delegate { };
        void CalcMatrix()
        {
            var a = MatrixLib.Matrix.CreateMatrix(MatrixDimension);
            var b = MatrixLib.Matrix.CreateMatrix(MatrixDimension);
            var c = MatrixLib.Matrix.MultipleMatrix(MatrixDimension, a, b, (n) =>
            {
                Dispatcher.Invoke(new Action(() => 
                {
                    pbOneThread.Value = (n + 1) / MatrixDimension * 100;
                    //pbOneThread.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    //pbOneThread.InvalidateVisual();
                    //pbOneThread.UpdateLayout();

                
                 }));
                
            });

        }



        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(CalcMatrix);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}