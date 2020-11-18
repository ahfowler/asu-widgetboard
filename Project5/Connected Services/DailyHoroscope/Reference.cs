﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project5.DailyHoroscope {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DailyHoroscope.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getHoroscopeReading", ReplyAction="http://tempuri.org/IService/getHoroscopeReadingResponse")]
        string getHoroscopeReading(string sign);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getHoroscopeReading", ReplyAction="http://tempuri.org/IService/getHoroscopeReadingResponse")]
        System.Threading.Tasks.Task<string> getHoroscopeReadingAsync(string sign);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getHoroscopeImage", ReplyAction="http://tempuri.org/IService/getHoroscopeImageResponse")]
        string getHoroscopeImage(string sign);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getHoroscopeImage", ReplyAction="http://tempuri.org/IService/getHoroscopeImageResponse")]
        System.Threading.Tasks.Task<string> getHoroscopeImageAsync(string sign);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Project5.DailyHoroscope.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Project5.DailyHoroscope.IService>, Project5.DailyHoroscope.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getHoroscopeReading(string sign) {
            return base.Channel.getHoroscopeReading(sign);
        }
        
        public System.Threading.Tasks.Task<string> getHoroscopeReadingAsync(string sign) {
            return base.Channel.getHoroscopeReadingAsync(sign);
        }
        
        public string getHoroscopeImage(string sign) {
            return base.Channel.getHoroscopeImage(sign);
        }
        
        public System.Threading.Tasks.Task<string> getHoroscopeImageAsync(string sign) {
            return base.Channel.getHoroscopeImageAsync(sign);
        }
    }
}
