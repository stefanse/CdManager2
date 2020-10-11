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
using CdManager.Model;

namespace wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cd> _cds;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository rep = Repository.GetInstance();
            _cds = rep.GetAllCds();
            lbxCds.ItemsSource = _cds;
            BtnNew.Click += BtnNew_Click;//new RoutedEventHandler(BtnNew_Click);

        }

        void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddCdWindow addCdWindow = new AddCdWindow();
            addCdWindow.ShowDialog();
            _cds = Repository.GetInstance().GetAllCds();
            lbxCds.ItemsSource = _cds;

        }

        void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Cd selectedCd = (Cd)lbxCds.SelectedItem;

            if (selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine Cd auswählt haben");
            }

            Repository repository = Repository.GetInstance();
            repository.DeleteCd(selectedCd);
            _cds = repository.GetAllCds();
            lbxCds.ItemsSource = _cds;
        }

        void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Cd selectedCd = (Cd)lbxCds.SelectedItem;

            if (selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine Cd auswählt haben");
            }
            Repository repository = Repository.GetInstance();
            EditCd editCd = new EditCd(selectedCd);
           
            editCd.ShowDialog();

            _cds = Repository.GetInstance().GetAllCds();
            lbxCds.ItemsSource = _cds;



        }
    }
}
