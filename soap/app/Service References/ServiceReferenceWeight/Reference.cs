﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace app.ServiceReferenceWeight {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET/", ConfigurationName="ServiceReferenceWeight.ConvertWeightsSoap")]
    public interface ConvertWeightsSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.webserviceX.NET/ConvertWeight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.IAsyncResult BeginConvertWeight(double Weight, app.ServiceReferenceWeight.WeightUnit FromUnit, app.ServiceReferenceWeight.WeightUnit ToUnit, System.AsyncCallback callback, object asyncState);
        
        double EndConvertWeight(System.IAsyncResult result);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webserviceX.NET/")]
    public enum WeightUnit {
        
        /// <remarks/>
        Grains,
        
        /// <remarks/>
        Scruples,
        
        /// <remarks/>
        Carats,
        
        /// <remarks/>
        Grams,
        
        /// <remarks/>
        Pennyweight,
        
        /// <remarks/>
        DramAvoir,
        
        /// <remarks/>
        DramApoth,
        
        /// <remarks/>
        OuncesAvoir,
        
        /// <remarks/>
        OuncesTroyApoth,
        
        /// <remarks/>
        Poundals,
        
        /// <remarks/>
        PoundsTroy,
        
        /// <remarks/>
        PoundsAvoir,
        
        /// <remarks/>
        Kilograms,
        
        /// <remarks/>
        Stones,
        
        /// <remarks/>
        QuarterUS,
        
        /// <remarks/>
        Slugs,
        
        /// <remarks/>
        weight100UScwt,
        
        /// <remarks/>
        ShortTons,
        
        /// <remarks/>
        MetricTonsTonne,
        
        /// <remarks/>
        LongTons,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConvertWeightsSoapChannel : app.ServiceReferenceWeight.ConvertWeightsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConvertWeightCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ConvertWeightCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConvertWeightsSoapClient : System.ServiceModel.ClientBase<app.ServiceReferenceWeight.ConvertWeightsSoap>, app.ServiceReferenceWeight.ConvertWeightsSoap {
        
        private BeginOperationDelegate onBeginConvertWeightDelegate;
        
        private EndOperationDelegate onEndConvertWeightDelegate;
        
        private System.Threading.SendOrPostCallback onConvertWeightCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ConvertWeightsSoapClient() {
        }
        
        public ConvertWeightsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConvertWeightsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertWeightsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertWeightsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<ConvertWeightCompletedEventArgs> ConvertWeightCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult app.ServiceReferenceWeight.ConvertWeightsSoap.BeginConvertWeight(double Weight, app.ServiceReferenceWeight.WeightUnit FromUnit, app.ServiceReferenceWeight.WeightUnit ToUnit, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginConvertWeight(Weight, FromUnit, ToUnit, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        double app.ServiceReferenceWeight.ConvertWeightsSoap.EndConvertWeight(System.IAsyncResult result) {
            return base.Channel.EndConvertWeight(result);
        }
        
        private System.IAsyncResult OnBeginConvertWeight(object[] inValues, System.AsyncCallback callback, object asyncState) {
            double Weight = ((double)(inValues[0]));
            app.ServiceReferenceWeight.WeightUnit FromUnit = ((app.ServiceReferenceWeight.WeightUnit)(inValues[1]));
            app.ServiceReferenceWeight.WeightUnit ToUnit = ((app.ServiceReferenceWeight.WeightUnit)(inValues[2]));
            return ((app.ServiceReferenceWeight.ConvertWeightsSoap)(this)).BeginConvertWeight(Weight, FromUnit, ToUnit, callback, asyncState);
        }
        
        private object[] OnEndConvertWeight(System.IAsyncResult result) {
            double retVal = ((app.ServiceReferenceWeight.ConvertWeightsSoap)(this)).EndConvertWeight(result);
            return new object[] {
                    retVal};
        }
        
        private void OnConvertWeightCompleted(object state) {
            if ((this.ConvertWeightCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ConvertWeightCompleted(this, new ConvertWeightCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ConvertWeightAsync(double Weight, app.ServiceReferenceWeight.WeightUnit FromUnit, app.ServiceReferenceWeight.WeightUnit ToUnit) {
            this.ConvertWeightAsync(Weight, FromUnit, ToUnit, null);
        }
        
        public void ConvertWeightAsync(double Weight, app.ServiceReferenceWeight.WeightUnit FromUnit, app.ServiceReferenceWeight.WeightUnit ToUnit, object userState) {
            if ((this.onBeginConvertWeightDelegate == null)) {
                this.onBeginConvertWeightDelegate = new BeginOperationDelegate(this.OnBeginConvertWeight);
            }
            if ((this.onEndConvertWeightDelegate == null)) {
                this.onEndConvertWeightDelegate = new EndOperationDelegate(this.OnEndConvertWeight);
            }
            if ((this.onConvertWeightCompletedDelegate == null)) {
                this.onConvertWeightCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnConvertWeightCompleted);
            }
            base.InvokeAsync(this.onBeginConvertWeightDelegate, new object[] {
                        Weight,
                        FromUnit,
                        ToUnit}, this.onEndConvertWeightDelegate, this.onConvertWeightCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override app.ServiceReferenceWeight.ConvertWeightsSoap CreateChannel() {
            return new ConvertWeightsSoapClientChannel(this);
        }
        
        private class ConvertWeightsSoapClientChannel : ChannelBase<app.ServiceReferenceWeight.ConvertWeightsSoap>, app.ServiceReferenceWeight.ConvertWeightsSoap {
            
            public ConvertWeightsSoapClientChannel(System.ServiceModel.ClientBase<app.ServiceReferenceWeight.ConvertWeightsSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginConvertWeight(double Weight, app.ServiceReferenceWeight.WeightUnit FromUnit, app.ServiceReferenceWeight.WeightUnit ToUnit, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[3];
                _args[0] = Weight;
                _args[1] = FromUnit;
                _args[2] = ToUnit;
                System.IAsyncResult _result = base.BeginInvoke("ConvertWeight", _args, callback, asyncState);
                return _result;
            }
            
            public double EndConvertWeight(System.IAsyncResult result) {
                object[] _args = new object[0];
                double _result = ((double)(base.EndInvoke("ConvertWeight", _args, result)));
                return _result;
            }
        }
    }
}
