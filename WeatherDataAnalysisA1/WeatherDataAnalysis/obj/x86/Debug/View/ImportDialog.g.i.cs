#pragma checksum "F:\Google Drive Sync\school\201808\program-construction\weatherdataanalysis\WeatherDataAnalysisA1\WeatherDataAnalysis\View\ImportDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "09A95CB3C1BD9A87DE6F465F7CBC5764"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherDataAnalysis.View
{
    partial class ImportDialog : global::Windows.UI.Xaml.Controls.ContentDialog
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.17.0")]
        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;

            global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///View/ImportDialog.xaml");
            global::Windows.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }

        partial void UnloadObject(global::Windows.UI.Xaml.DependencyObject unloadableObject);

        private global::Windows.UI.Xaml.Controls.TextBlock importTypeLabel;
        private global::Windows.UI.Xaml.Controls.RadioButton overwriteButton;
        private global::Windows.UI.Xaml.Controls.RadioButton mergeButton;
        private global::Windows.UI.Xaml.Controls.TextBox collectionNameInput;
        private global::Windows.UI.Xaml.Controls.TextBlock collectionNameLabel;
    }
}

