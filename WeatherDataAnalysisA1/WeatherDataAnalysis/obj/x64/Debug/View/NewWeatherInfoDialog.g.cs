﻿#pragma checksum "C:\GroupAWeatherAnalysis\WeatherDataAnalysisA1\WeatherDataAnalysis\View\NewWeatherInfoDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3246F7FED263E5EDDABDFD2D54845360"
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
    partial class NewWeatherInfoDialog : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // View\NewWeatherInfoDialog.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.c_Submit;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.c_Cancel;
                }
                break;
            case 2: // View\NewWeatherInfoDialog.xaml line 19
                {
                    this.dateInput = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.dateInput).LostFocus += this.lostFocus_InputField;
                }
                break;
            case 3: // View\NewWeatherInfoDialog.xaml line 20
                {
                    this.highTempInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.highTempInput).LostFocus += this.lostFocus_InputField;
                }
                break;
            case 4: // View\NewWeatherInfoDialog.xaml line 21
                {
                    this.lowTempInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.lowTempInput).LostFocus += this.lostFocus_InputField;
                }
                break;
            case 5: // View\NewWeatherInfoDialog.xaml line 22
                {
                    this.dateLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // View\NewWeatherInfoDialog.xaml line 23
                {
                    this.highTemperatureLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // View\NewWeatherInfoDialog.xaml line 24
                {
                    this.lowTemperatureLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // View\NewWeatherInfoDialog.xaml line 25
                {
                    this.overwriteCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 9: // View\NewWeatherInfoDialog.xaml line 26
                {
                    this.nameInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.nameInput).LostFocus += this.lostFocus_InputField;
                }
                break;
            case 10: // View\NewWeatherInfoDialog.xaml line 27
                {
                    this.noCollectionLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

