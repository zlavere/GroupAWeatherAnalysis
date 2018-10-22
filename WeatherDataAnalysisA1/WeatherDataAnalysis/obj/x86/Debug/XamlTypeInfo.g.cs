﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WeatherDataAnalysis
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMetaDataProvider __appProvider;
        private global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMetaDataProvider _AppProvider
        {
            get
            {
                if (__appProvider == null)
                {
                    __appProvider = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMetaDataProvider();
                }
                return __appProvider;
            }
        }

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            return _AppProvider.GetXamlType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            return _AppProvider.GetXamlType(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return _AppProvider.GetXmlnsDefinitions();
        }
    }
}

namespace WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo
{
    /// <summary>
    /// Main class for providing metadata for the app or library
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed class XamlMetaDataProvider : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider _provider = null;

        private global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    _provider = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider();
                }
                return _provider;
            }
        }

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            return Provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            return Provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            lock (_xamlTypeCacheByType) 
            { 
                if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
                {
                    return xamlType;
                }
                int typeIndex = LookupTypeIndexByType(type);
                if(typeIndex != -1)
                {
                    xamlType = CreateXamlType(typeIndex);
                }
                if (xamlType != null)
                {
                    _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                    _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
                }
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            lock (_xamlTypeCacheByType)
            {
                if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
                {
                    return xamlType;
                }
                int typeIndex = LookupTypeIndexByName(typeName);
                if(typeIndex != -1)
                {
                    xamlType = CreateXamlType(typeIndex);
                }
                if (xamlType != null)
                {
                    _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                    _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
                }
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            lock (_xamlMembers)
            {
                if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
                {
                    return xamlMember;
                }
                xamlMember = CreateXamlMember(longMemberName);
                if (xamlMember != null)
                {
                    _xamlMembers.Add(longMemberName, xamlMember);
                }
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[15];
            _typeNameTable[0] = "WeatherDataAnalysis.MainPage";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "WeatherDataAnalysis.View.ImportDialog";
            _typeNameTable[4] = "Windows.UI.Xaml.Controls.ContentDialog";
            _typeNameTable[5] = "Windows.UI.Xaml.Controls.ContentControl";
            _typeNameTable[6] = "String";
            _typeNameTable[7] = "WeatherDataAnalysis.Model.Enums.ImportType";
            _typeNameTable[8] = "System.Enum";
            _typeNameTable[9] = "System.ValueType";
            _typeNameTable[10] = "Object";
            _typeNameTable[11] = "WeatherDataAnalysis.View.MergeMatchDialog";
            _typeNameTable[12] = "WeatherDataAnalysis.View.NewWeatherInfoDialog";
            _typeNameTable[13] = "Int32";
            _typeNameTable[14] = "System.DateTime";

            _typeTable = new global::System.Type[15];
            _typeTable[0] = typeof(global::WeatherDataAnalysis.MainPage);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::WeatherDataAnalysis.View.ImportDialog);
            _typeTable[4] = typeof(global::Windows.UI.Xaml.Controls.ContentDialog);
            _typeTable[5] = typeof(global::Windows.UI.Xaml.Controls.ContentControl);
            _typeTable[6] = typeof(global::System.String);
            _typeTable[7] = typeof(global::WeatherDataAnalysis.Model.Enums.ImportType);
            _typeTable[8] = typeof(global::System.Enum);
            _typeTable[9] = typeof(global::System.ValueType);
            _typeTable[10] = typeof(global::System.Object);
            _typeTable[11] = typeof(global::WeatherDataAnalysis.View.MergeMatchDialog);
            _typeTable[12] = typeof(global::WeatherDataAnalysis.View.NewWeatherInfoDialog);
            _typeTable[13] = typeof(global::System.Int32);
            _typeTable[14] = typeof(global::System.DateTime);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_MainPage() { return new global::WeatherDataAnalysis.MainPage(); }
        private object Activate_3_ImportDialog() { return new global::WeatherDataAnalysis.View.ImportDialog(); }
        private object Activate_11_MergeMatchDialog() { return new global::WeatherDataAnalysis.View.MergeMatchDialog(); }
        private object Activate_12_NewWeatherInfoDialog() { return new global::WeatherDataAnalysis.View.NewWeatherInfoDialog(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  WeatherDataAnalysis.MainPage
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  WeatherDataAnalysis.View.ImportDialog
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentDialog"));
                userType.Activator = Activate_3_ImportDialog;
                userType.AddMemberName("CollectionName");
                userType.AddMemberName("ImportType");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  Windows.UI.Xaml.Controls.ContentDialog
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  Windows.UI.Xaml.Controls.ContentControl
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  String
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 7:   //  WeatherDataAnalysis.Model.Enums.ImportType
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.Enum"));
                userType.AddEnumValue("Merge", global::WeatherDataAnalysis.Model.Enums.ImportType.Merge);
                userType.AddEnumValue("Overwrite", global::WeatherDataAnalysis.Model.Enums.ImportType.Overwrite);
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  System.Enum
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                xamlType = userType;
                break;

            case 9:   //  System.ValueType
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case 10:   //  Object
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  WeatherDataAnalysis.View.MergeMatchDialog
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentDialog"));
                userType.Activator = Activate_11_MergeMatchDialog;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 12:   //  WeatherDataAnalysis.View.NewWeatherInfoDialog
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentDialog"));
                userType.Activator = Activate_12_NewWeatherInfoDialog;
                userType.AddMemberName("HighTemp");
                userType.AddMemberName("LowTemp");
                userType.AddMemberName("Date");
                userType.AddMemberName("CollectionName");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  Int32
                xamlType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 14:   //  System.DateTime
                userType = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_ImportDialog_CollectionName(object instance)
        {
            var that = (global::WeatherDataAnalysis.View.ImportDialog)instance;
            return that.CollectionName;
        }
        private object get_1_ImportDialog_ImportType(object instance)
        {
            var that = (global::WeatherDataAnalysis.View.ImportDialog)instance;
            return that.ImportType;
        }
        private object get_2_NewWeatherInfoDialog_HighTemp(object instance)
        {
            var that = (global::WeatherDataAnalysis.View.NewWeatherInfoDialog)instance;
            return that.HighTemp;
        }
        private object get_3_NewWeatherInfoDialog_LowTemp(object instance)
        {
            var that = (global::WeatherDataAnalysis.View.NewWeatherInfoDialog)instance;
            return that.LowTemp;
        }
        private object get_4_NewWeatherInfoDialog_Date(object instance)
        {
            var that = (global::WeatherDataAnalysis.View.NewWeatherInfoDialog)instance;
            return that.Date;
        }
        private object get_5_NewWeatherInfoDialog_CollectionName(object instance)
        {
            var that = (global::WeatherDataAnalysis.View.NewWeatherInfoDialog)instance;
            return that.CollectionName;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember xamlMember = null;
            global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "WeatherDataAnalysis.View.ImportDialog.CollectionName":
                userType = (global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType)GetXamlTypeByName("WeatherDataAnalysis.View.ImportDialog");
                xamlMember = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember(this, "CollectionName", "String");
                xamlMember.Getter = get_0_ImportDialog_CollectionName;
                xamlMember.SetIsReadOnly();
                break;
            case "WeatherDataAnalysis.View.ImportDialog.ImportType":
                userType = (global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType)GetXamlTypeByName("WeatherDataAnalysis.View.ImportDialog");
                xamlMember = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember(this, "ImportType", "WeatherDataAnalysis.Model.Enums.ImportType");
                xamlMember.Getter = get_1_ImportDialog_ImportType;
                xamlMember.SetIsReadOnly();
                break;
            case "WeatherDataAnalysis.View.NewWeatherInfoDialog.HighTemp":
                userType = (global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType)GetXamlTypeByName("WeatherDataAnalysis.View.NewWeatherInfoDialog");
                xamlMember = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember(this, "HighTemp", "Int32");
                xamlMember.Getter = get_2_NewWeatherInfoDialog_HighTemp;
                xamlMember.SetIsReadOnly();
                break;
            case "WeatherDataAnalysis.View.NewWeatherInfoDialog.LowTemp":
                userType = (global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType)GetXamlTypeByName("WeatherDataAnalysis.View.NewWeatherInfoDialog");
                xamlMember = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember(this, "LowTemp", "Int32");
                xamlMember.Getter = get_3_NewWeatherInfoDialog_LowTemp;
                xamlMember.SetIsReadOnly();
                break;
            case "WeatherDataAnalysis.View.NewWeatherInfoDialog.Date":
                userType = (global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType)GetXamlTypeByName("WeatherDataAnalysis.View.NewWeatherInfoDialog");
                xamlMember = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember(this, "Date", "System.DateTime");
                xamlMember.Getter = get_4_NewWeatherInfoDialog_Date;
                xamlMember.SetIsReadOnly();
                break;
            case "WeatherDataAnalysis.View.NewWeatherInfoDialog.CollectionName":
                userType = (global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlUserType)GetXamlTypeByName("WeatherDataAnalysis.View.NewWeatherInfoDialog");
                xamlMember = new global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlMember(this, "CollectionName", "String");
                xamlMember.Getter = get_5_NewWeatherInfoDialog_CollectionName;
                xamlMember.SetIsReadOnly();
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);
    internal delegate object CreateFromStringMethod(string args);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlSystemBaseType
    {
        global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            global::System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (CreateFromStringMethod != null)
            {
                return this.CreateFromStringMethod(input);
            }
            else if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }
        public CreateFromStringMethod CreateFromStringMethod {get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::WeatherDataAnalysis.WeatherDataAnalysis_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

