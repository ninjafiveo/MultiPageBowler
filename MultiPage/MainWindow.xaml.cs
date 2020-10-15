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
using MultiPage.ViewModels;
using System.Threading;

namespace MultiPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RedView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RedViewModel();
        }

        private void BlueView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BlueViewModel();
        }

        private void OrangeView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new OrangeViewModel();
        }

        private void OrangeView_DragOver(object sender, DragEventArgs e)
        {
            DataContext = new OrangeViewModel();
        }
        private void YellowView_DragOver(object sender, DragEventArgs e)
        {
            DataContext = new YellowViewModel();
        }

        private void YellowKeyUp(object sender, KeyEventArgs e)
        {
            DataContext = new YellowViewModel();
        }
    }
}
