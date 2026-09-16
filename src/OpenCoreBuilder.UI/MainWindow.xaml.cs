using System.Windows;
using OpenCoreBuilder.UI.ViewModels;

namespace OpenCoreBuilder.UI;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}