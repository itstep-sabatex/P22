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
    /// Interaction logic for NomenclatureEdit.xaml
    /// </summary>
    public partial class NomenclatureEdit : UserControl
    {
        public int? Id { get; set; }
        
        public event Action<bool> Success;
        public Nomenclature?  EditItem { get; set; }
        public NomenclatureEdit()
        {
            InitializeComponent();
            
        }

        public void Refresh()
        {
            if (Id != null)
            {
                using (var dbContext = Config.GetDbContext())
                {
                    EditItem = dbContext.Nomenclatures.Find(Id); // ??  
                }
            }
            else
            {
                EditItem = new Nomenclature();
            }
        }

        private void Button_ClickOk(object sender, RoutedEventArgs e)
        {
            using (var dbContext = Config.GetDbContext())
            {

                if (Id == null)
                {
                    dbContext.Add(EditItem);
                }
                else
                {
                    dbContext.SaveChanges();
                }
            }
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            Success?.Invoke(false);
        }
    }
}
