﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileSharing.AdvertisingService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Advertising", Namespace="http://schemas.datacontract.org/2004/07/AdvertisingWCF.Models")]
    [System.SerializableAttribute()]
    public partial class Advertising : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeImageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Image {
            get {
                return this.ImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageField, value) != true)) {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TypeImage {
            get {
                return this.TypeImageField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeImageField, value) != true)) {
                    this.TypeImageField = value;
                    this.RaisePropertyChanged("TypeImage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdvertisingService.ISpamService")]
    public interface ISpamService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpamService/GetAdvertising", ReplyAction="http://tempuri.org/ISpamService/GetAdvertisingResponse")]
        FileSharing.AdvertisingService.Advertising GetAdvertising();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpamService/GetAdvertising", ReplyAction="http://tempuri.org/ISpamService/GetAdvertisingResponse")]
        System.Threading.Tasks.Task<FileSharing.AdvertisingService.Advertising> GetAdvertisingAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISpamServiceChannel : FileSharing.AdvertisingService.ISpamService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SpamServiceClient : System.ServiceModel.ClientBase<FileSharing.AdvertisingService.ISpamService>, FileSharing.AdvertisingService.ISpamService {
        
        public SpamServiceClient() {
        }
        
        public SpamServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SpamServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SpamServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SpamServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FileSharing.AdvertisingService.Advertising GetAdvertising() {
            return base.Channel.GetAdvertising();
        }
        
        public System.Threading.Tasks.Task<FileSharing.AdvertisingService.Advertising> GetAdvertisingAsync() {
            return base.Channel.GetAdvertisingAsync();
        }
    }
}
