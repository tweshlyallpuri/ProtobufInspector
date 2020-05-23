using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ProtobufInspector
{
    /// <summary>
    /// Interaction logic for ProtobufInspectorView.xaml
    /// </summary>
    public partial class ProtobufInspectorView : UserControl
    {
        public ProtobufInspectorViewModel ViewModel { get; }
        public ProtobufInspectorView()
        {
            InitializeComponent();
            ViewModel = new ProtobufInspectorViewModel();
            DataContext = ViewModel;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if(result==true)
            {
                txtAssemblyFilePath.Text = openFileDlg.FileName;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (txtAssemblyFilePath.Text.EndsWith(".dll"))
            {
                ViewModel.AsmFilePath = txtAssemblyFilePath.Text;
                ViewModel.SelectedAssembly = Assembly.LoadFrom(txtAssemblyFilePath.Text);
                ViewModel.ClassNames = new ObservableCollection<string>(ViewModel.SelectedAssembly.GetTypes().
                    OrderBy(o => o.Name).Select(s => s.FullName).ToList());
            }
            else
                MessageBox.Show("Please browse to a dll and try loading again");
        }
    }
}
