﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NDDigital.DiarioAcademia.Infraestrutura.WebServices.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.correios.com.br/calculador/CalcPrecoPrazo.asmx")]
        public string NDDigital_DiarioAcademia_Infraestrutura_WebServices_br_com_correios_ws_CalcPrecoPrazoWS {
            get {
                return ((string)(this["NDDigital_DiarioAcademia_Infraestrutura_WebServices_br_com_correios_ws_CalcPrecoP" +
                    "razoWS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.byjg.com.br/site/webservice.php/ws/cep")]
        public string NDDigital_DiarioAcademia_Infraestrutura_WebServices_br_com_byjg_www_CEPService {
            get {
                return ((string)(this["NDDigital_DiarioAcademia_Infraestrutura_WebServices_br_com_byjg_www_CEPService"]));
            }
        }
    }
}
