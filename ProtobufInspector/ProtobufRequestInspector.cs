using Fiddler;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

[assembly: Fiddler.RequiredVersion("2.3.0.0")]
namespace ProtobufInspector
{
    public class ProtobufRequestInspector : Inspector2, IRequestInspector2
    {
        #region Constructor
        public ProtobufRequestInspector()
        {
            view = new ProtobufInspectorView();
            view.ViewModel.PropertyChanged += OnClassNameSelectionChanged;
        }
        #endregion
        #region Properties
        public HTTPRequestHeaders headers { get; set; }
        public byte[] body
        {
            get => _body;
            set
            {
                _body = value;
                if (body != null && body.Length > 0)
                {
                    try
                    {
                        var t = view.ViewModel.SelectedAssembly.GetType(view.ViewModel.SelectedClass);
                        string errorMessage;
                        var obj = ProtoHelper.Deserialize(t, _body, out errorMessage);
                        if (obj == null)
                            view.ViewModel.JsonString = errorMessage;
                        else
                        {
                            view.ViewModel.JsonString = JsonConvert.SerializeObject(obj, t, Formatting.Indented,
                                new JsonSerializerSettings
                                {
                                    DefaultValueHandling = DefaultValueHandling.Include,
                                    NullValueHandling = NullValueHandling.Include
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        view.ViewModel.JsonString = e.Message;
                    }
                }
                else
                    view.ViewModel.JsonString = "";

            }
        }
        public bool bDirty { get; }
        public bool bReadOnly { get; set; }
        #endregion
        #region PublicMethods
        public override void AddToTab(System.Windows.Forms.TabPage o)
        {
            host.Dock = DockStyle.Fill;
            host.Child = view;
            o.Text = "Protobuf";
            o.Controls.Add(host);
        }

        public void Clear()
        {
            body = null;
            view.ViewModel.Clear();
        }

        public override int GetOrder()
        {
            return 150;// towards the right end
        }
        #endregion
        #region Private Methods
        private void OnClassNameSelectionChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedClass")
                body = _body;
        }
        #endregion
        #region Private Members
        private readonly ProtobufInspectorView view;
        private readonly ElementHost host = new ElementHost();
        private byte[] _body;
        #endregion
    }
}
