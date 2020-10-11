using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf
{
    /// <summary>
    /// Interaction logic for AddCdWindow.xaml
    /// </summary>
    public partial class AddCdWindow : Window
    {
      
        private Cd _newCd;
        public AddCdWindow()
        {
            InitializeComponent();
            Loaded += AddCdWindow_Loaded;// new RoutedEventHandler(AddCdWindow_Loaded);

        }

        void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {

            BtnSave.Click += BtnSave_Click; // new RoutedEventHandler(BtnCancel_Click);
            BtnCancel.Click += BtnCancel_Click; //new RoutedEventHandler(BtnCancel_Click);

            _newCd = new Cd();
            _newCd.AlbumTitle = "<hier Titel eingeben>";
            grdCdFields.DataContext =_newCd;
        }

        void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Repository.GetInstance().AddCd(_newCd);
            Close();
        }

    }
}
