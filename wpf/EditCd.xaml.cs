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
    /// Interaction logic for EditCd.xaml
    /// </summary>
    public partial class EditCd : Window
    {
        private Cd _alteCdinBearbeitung;
        private Cd _editCd;
        public EditCd(Cd selectedcd)
        {
            InitializeComponent();
            _alteCdinBearbeitung = selectedcd;
            Loaded += EditCd_Loaded;
        }

        void EditCd_Loaded(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSave_Click;
            BtnCancel.Click += BtnCancel_Click;

            _editCd = new Cd();
            _editCd.AlbumTitle = _alteCdinBearbeitung.AlbumTitle;
            _editCd.Artist = _alteCdinBearbeitung.Artist;
            grdCdFields.DataContext = _editCd;
        }

        void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _alteCdinBearbeitung.AlbumTitle = _editCd.AlbumTitle;
            _alteCdinBearbeitung.Artist = _editCd.Artist;
            Close();
        }
    }
}