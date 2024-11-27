using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cafe
{
    /// <summary>
    /// Interaction logic for NomenclatureItems.xaml
    /// </summary>
    public partial class NomenclatureItems : UserControl
    {
        public event Action<int?> EditItem;
        public event Action CloseFrame;
        public NomenclatureItems()
        {
            InitializeComponent();
        }

        public void Refresh()
        {

            using (var dbContext = Config.GetDbContext())
            {
                dGrid.ItemsSource = dbContext.Nomenclatures.ToArray();
            }
        }

        private void dGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditItem?.Invoke(((Nomenclature)dGrid.CurrentItem).Id);
        }
    }
}
