﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceCall.ServiceReferenceDS {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDS.WebService5DSSoap")]
    public interface WebService5DSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Title", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Get_Title(string ap_sqlno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Title", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_TitleAsync(string ap_sqlno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService5DSSoapChannel : WebServiceCall.ServiceReferenceDS.WebService5DSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService5DSSoapClient : System.ServiceModel.ClientBase<WebServiceCall.ServiceReferenceDS.WebService5DSSoap>, WebServiceCall.ServiceReferenceDS.WebService5DSSoap {
        
        public WebService5DSSoapClient() {
        }
        
        public WebService5DSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService5DSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService5DSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService5DSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Get_Title(string ap_sqlno) {
            return base.Channel.Get_Title(ap_sqlno);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_TitleAsync(string ap_sqlno) {
            return base.Channel.Get_TitleAsync(ap_sqlno);
        }
    }
}