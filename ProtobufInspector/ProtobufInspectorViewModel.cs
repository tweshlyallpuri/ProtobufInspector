using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProtobufInspector
{
    public class ProtobufInspectorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string AsmFilePath { get => _asmFilePath; set => _asmFilePath = value; }
        public string JsonString
        {
            get => _jsonString;
            set
            {
                _jsonString = value;
                NotifyPropertyChanged();
            }
        }
        public string SelectedClass
        {
            get => _selectedClass; 
            set
            {
                _selectedClass = value;
                NotifyPropertyChanged("SelectedClass");
            }
        }
        public Assembly SelectedAssembly { get; internal set; }
        public ObservableCollection<string> ClassNames
        {
            get { return _classNames; }
            set
            {
                _classNames = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        internal void Clear()
        {
            JsonString = string.Empty;
        }
        private string _jsonString = string.Empty;
        private string _selectedClass = string.Empty;
        private string _asmFilePath = string.Empty;
        private ObservableCollection<string> _classNames;
    }
}
