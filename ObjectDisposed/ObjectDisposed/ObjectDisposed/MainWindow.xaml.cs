using Dapplo.Microsoft.Extensions.Hosting.Wpf;
using System.Windows;

namespace ObjectDisposed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWpfShell
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
