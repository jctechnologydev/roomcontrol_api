﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TemperatureConverter
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TemperatureConverter.TemperatureConverterWSSoap")]
    public interface TemperatureConverterWSSoap
    {
        
        // CODEGEN: Generating message contract since the wrapper name (Converter_x0020_Celcius-kelvin) of message Converter_x0020_Celcius-kelvin does not match the default value (CelsiusToKelvin)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Celcius-kelvin", ReplyAction="*")]
        TemperatureConverter.ConverterCelciuskelvin1 CelsiusToKelvin(TemperatureConverter.ConverterCelciuskelvin request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Celcius-kelvin", ReplyAction="*")]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterCelciuskelvin1> CelsiusToKelvinAsync(TemperatureConverter.ConverterCelciuskelvin request);
        
        // CODEGEN: Generating message contract since the wrapper name (Converter_x0020_Celcius-Fahrenheit) of message Converter_x0020_Celcius-Fahrenheit does not match the default value (CelsiusToFahrenheit)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Celcius-Fahrenheit", ReplyAction="*")]
        TemperatureConverter.ConverterCelciusFahrenheit1 CelsiusToFahrenheit(TemperatureConverter.ConverterCelciusFahrenheit request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Celcius-Fahrenheit", ReplyAction="*")]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterCelciusFahrenheit1> CelsiusToFahrenheitAsync(TemperatureConverter.ConverterCelciusFahrenheit request);
        
        // CODEGEN: Generating message contract since the wrapper name (Converter_x0020_Kelvin-Fahrenheit) of message Converter_x0020_Kelvin-Fahrenheit does not match the default value (KelvinToFahrenheit)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Kelvin-Fahrenheit", ReplyAction="*")]
        TemperatureConverter.ConverterKelvinFahrenheit1 KelvinToFahrenheit(TemperatureConverter.ConverterKelvinFahrenheit request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Kelvin-Fahrenheit", ReplyAction="*")]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterKelvinFahrenheit1> KelvinToFahrenheitAsync(TemperatureConverter.ConverterKelvinFahrenheit request);
        
        // CODEGEN: Generating message contract since the wrapper name (Converter_x0020_Kelvin-Celcius) of message Converter_x0020_Kelvin-Celcius does not match the default value (KelvinToCelsius)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Kelvin-Celcius", ReplyAction="*")]
        TemperatureConverter.ConverterKelvinCelcius1 KelvinToCelsius(TemperatureConverter.ConverterKelvinCelcius request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Kelvin-Celcius", ReplyAction="*")]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterKelvinCelcius1> KelvinToCelsiusAsync(TemperatureConverter.ConverterKelvinCelcius request);
        
        // CODEGEN: Generating message contract since the wrapper name (Converter_x0020_Fahrenheit-Kelvin) of message Converter_x0020_Fahrenheit-Kelvin does not match the default value (FahrenheitToKelvin)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Fahrenheit-Kelvin", ReplyAction="*")]
        TemperatureConverter.ConverterFahrenheitKelvin1 FahrenheitToKelvin(TemperatureConverter.ConverterFahrenheitKelvin request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Fahrenheit-Kelvin", ReplyAction="*")]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterFahrenheitKelvin1> FahrenheitToKelvinAsync(TemperatureConverter.ConverterFahrenheitKelvin request);
        
        // CODEGEN: Generating message contract since the wrapper name (Converter_x0020_Fahrenheit-Celcius) of message Converter_x0020_Fahrenheit-Celcius does not match the default value (FahrenheitToCelcius)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Fahrenheit-Celcius", ReplyAction="*")]
        TemperatureConverter.ConverterFahrenheitCelcius1 FahrenheitToCelcius(TemperatureConverter.ConverterFahrenheitCelcius request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Converter Fahrenheit-Celcius", ReplyAction="*")]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterFahrenheitCelcius1> FahrenheitToCelciusAsync(TemperatureConverter.ConverterFahrenheitCelcius request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Celcius-kelvin", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterCelciuskelvin
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public float celcius;
        
        public ConverterCelciuskelvin()
        {
        }
        
        public ConverterCelciuskelvin(float celcius)
        {
            this.celcius = celcius;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Celcius-kelvinResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterCelciuskelvin1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Converter_x0020_Celcius-kelvinResult", Namespace="http://tempuri.org/", Order=0)]
        public float ConverterCelciuskelvinResult;
        
        public ConverterCelciuskelvin1()
        {
        }
        
        public ConverterCelciuskelvin1(float ConverterCelciuskelvinResult)
        {
            this.ConverterCelciuskelvinResult = ConverterCelciuskelvinResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Celcius-Fahrenheit", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterCelciusFahrenheit
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public float celcius;
        
        public ConverterCelciusFahrenheit()
        {
        }
        
        public ConverterCelciusFahrenheit(float celcius)
        {
            this.celcius = celcius;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Celcius-FahrenheitResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterCelciusFahrenheit1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Converter_x0020_Celcius-FahrenheitResult", Namespace="http://tempuri.org/", Order=0)]
        public float ConverterCelciusFahrenheitResult;
        
        public ConverterCelciusFahrenheit1()
        {
        }
        
        public ConverterCelciusFahrenheit1(float ConverterCelciusFahrenheitResult)
        {
            this.ConverterCelciusFahrenheitResult = ConverterCelciusFahrenheitResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Kelvin-Fahrenheit", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterKelvinFahrenheit
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public float kelvin;
        
        public ConverterKelvinFahrenheit()
        {
        }
        
        public ConverterKelvinFahrenheit(float kelvin)
        {
            this.kelvin = kelvin;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Kelvin-FahrenheitResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterKelvinFahrenheit1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Converter_x0020_Kelvin-FahrenheitResult", Namespace="http://tempuri.org/", Order=0)]
        public float ConverterKelvinFahrenheitResult;
        
        public ConverterKelvinFahrenheit1()
        {
        }
        
        public ConverterKelvinFahrenheit1(float ConverterKelvinFahrenheitResult)
        {
            this.ConverterKelvinFahrenheitResult = ConverterKelvinFahrenheitResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Kelvin-Celcius", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterKelvinCelcius
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public float kelvin;
        
        public ConverterKelvinCelcius()
        {
        }
        
        public ConverterKelvinCelcius(float kelvin)
        {
            this.kelvin = kelvin;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Kelvin-CelciusResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterKelvinCelcius1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Converter_x0020_Kelvin-CelciusResult", Namespace="http://tempuri.org/", Order=0)]
        public float ConverterKelvinCelciusResult;
        
        public ConverterKelvinCelcius1()
        {
        }
        
        public ConverterKelvinCelcius1(float ConverterKelvinCelciusResult)
        {
            this.ConverterKelvinCelciusResult = ConverterKelvinCelciusResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Fahrenheit-Kelvin", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterFahrenheitKelvin
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public float fahrenheit;
        
        public ConverterFahrenheitKelvin()
        {
        }
        
        public ConverterFahrenheitKelvin(float fahrenheit)
        {
            this.fahrenheit = fahrenheit;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Fahrenheit-KelvinResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterFahrenheitKelvin1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Converter_x0020_Fahrenheit-KelvinResult", Namespace="http://tempuri.org/", Order=0)]
        public float ConverterFahrenheitKelvinResult;
        
        public ConverterFahrenheitKelvin1()
        {
        }
        
        public ConverterFahrenheitKelvin1(float ConverterFahrenheitKelvinResult)
        {
            this.ConverterFahrenheitKelvinResult = ConverterFahrenheitKelvinResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Fahrenheit-Celcius", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterFahrenheitCelcius
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public float fahrenheit;
        
        public ConverterFahrenheitCelcius()
        {
        }
        
        public ConverterFahrenheitCelcius(float fahrenheit)
        {
            this.fahrenheit = fahrenheit;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Converter Fahrenheit-CelciusResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConverterFahrenheitCelcius1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Converter_x0020_Fahrenheit-CelciusResult", Namespace="http://tempuri.org/", Order=0)]
        public float ConverterFahrenheitCelciusResult;
        
        public ConverterFahrenheitCelcius1()
        {
        }
        
        public ConverterFahrenheitCelcius1(float ConverterFahrenheitCelciusResult)
        {
            this.ConverterFahrenheitCelciusResult = ConverterFahrenheitCelciusResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface TemperatureConverterWSSoapChannel : TemperatureConverter.TemperatureConverterWSSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class TemperatureConverterWSSoapClient : System.ServiceModel.ClientBase<TemperatureConverter.TemperatureConverterWSSoap>, TemperatureConverter.TemperatureConverterWSSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TemperatureConverterWSSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(TemperatureConverterWSSoapClient.GetBindingForEndpoint(endpointConfiguration), TemperatureConverterWSSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TemperatureConverterWSSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TemperatureConverterWSSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TemperatureConverterWSSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TemperatureConverterWSSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TemperatureConverterWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TemperatureConverter.ConverterCelciuskelvin1 TemperatureConverter.TemperatureConverterWSSoap.CelsiusToKelvin(TemperatureConverter.ConverterCelciuskelvin request)
        {
            return base.Channel.CelsiusToKelvin(request);
        }
        
        public float CelsiusToKelvin(float celcius)
        {
            TemperatureConverter.ConverterCelciuskelvin inValue = new TemperatureConverter.ConverterCelciuskelvin();
            inValue.celcius = celcius;
            TemperatureConverter.ConverterCelciuskelvin1 retVal = ((TemperatureConverter.TemperatureConverterWSSoap)(this)).CelsiusToKelvin(inValue);
            return retVal.ConverterCelciuskelvinResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterCelciuskelvin1> TemperatureConverter.TemperatureConverterWSSoap.CelsiusToKelvinAsync(TemperatureConverter.ConverterCelciuskelvin request)
        {
            return base.Channel.CelsiusToKelvinAsync(request);
        }
        
        public System.Threading.Tasks.Task<TemperatureConverter.ConverterCelciuskelvin1> CelsiusToKelvinAsync(float celcius)
        {
            TemperatureConverter.ConverterCelciuskelvin inValue = new TemperatureConverter.ConverterCelciuskelvin();
            inValue.celcius = celcius;
            return ((TemperatureConverter.TemperatureConverterWSSoap)(this)).CelsiusToKelvinAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TemperatureConverter.ConverterCelciusFahrenheit1 TemperatureConverter.TemperatureConverterWSSoap.CelsiusToFahrenheit(TemperatureConverter.ConverterCelciusFahrenheit request)
        {
            return base.Channel.CelsiusToFahrenheit(request);
        }
        
        public float CelsiusToFahrenheit(float celcius)
        {
            TemperatureConverter.ConverterCelciusFahrenheit inValue = new TemperatureConverter.ConverterCelciusFahrenheit();
            inValue.celcius = celcius;
            TemperatureConverter.ConverterCelciusFahrenheit1 retVal = ((TemperatureConverter.TemperatureConverterWSSoap)(this)).CelsiusToFahrenheit(inValue);
            return retVal.ConverterCelciusFahrenheitResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterCelciusFahrenheit1> TemperatureConverter.TemperatureConverterWSSoap.CelsiusToFahrenheitAsync(TemperatureConverter.ConverterCelciusFahrenheit request)
        {
            return base.Channel.CelsiusToFahrenheitAsync(request);
        }
        
        public System.Threading.Tasks.Task<TemperatureConverter.ConverterCelciusFahrenheit1> CelsiusToFahrenheitAsync(float celcius)
        {
            TemperatureConverter.ConverterCelciusFahrenheit inValue = new TemperatureConverter.ConverterCelciusFahrenheit();
            inValue.celcius = celcius;
            return ((TemperatureConverter.TemperatureConverterWSSoap)(this)).CelsiusToFahrenheitAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TemperatureConverter.ConverterKelvinFahrenheit1 TemperatureConverter.TemperatureConverterWSSoap.KelvinToFahrenheit(TemperatureConverter.ConverterKelvinFahrenheit request)
        {
            return base.Channel.KelvinToFahrenheit(request);
        }
        
        public float KelvinToFahrenheit(float kelvin)
        {
            TemperatureConverter.ConverterKelvinFahrenheit inValue = new TemperatureConverter.ConverterKelvinFahrenheit();
            inValue.kelvin = kelvin;
            TemperatureConverter.ConverterKelvinFahrenheit1 retVal = ((TemperatureConverter.TemperatureConverterWSSoap)(this)).KelvinToFahrenheit(inValue);
            return retVal.ConverterKelvinFahrenheitResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterKelvinFahrenheit1> TemperatureConverter.TemperatureConverterWSSoap.KelvinToFahrenheitAsync(TemperatureConverter.ConverterKelvinFahrenheit request)
        {
            return base.Channel.KelvinToFahrenheitAsync(request);
        }
        
        public System.Threading.Tasks.Task<TemperatureConverter.ConverterKelvinFahrenheit1> KelvinToFahrenheitAsync(float kelvin)
        {
            TemperatureConverter.ConverterKelvinFahrenheit inValue = new TemperatureConverter.ConverterKelvinFahrenheit();
            inValue.kelvin = kelvin;
            return ((TemperatureConverter.TemperatureConverterWSSoap)(this)).KelvinToFahrenheitAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TemperatureConverter.ConverterKelvinCelcius1 TemperatureConverter.TemperatureConverterWSSoap.KelvinToCelsius(TemperatureConverter.ConverterKelvinCelcius request)
        {
            return base.Channel.KelvinToCelsius(request);
        }
        
        public float KelvinToCelsius(float kelvin)
        {
            TemperatureConverter.ConverterKelvinCelcius inValue = new TemperatureConverter.ConverterKelvinCelcius();
            inValue.kelvin = kelvin;
            TemperatureConverter.ConverterKelvinCelcius1 retVal = ((TemperatureConverter.TemperatureConverterWSSoap)(this)).KelvinToCelsius(inValue);
            return retVal.ConverterKelvinCelciusResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterKelvinCelcius1> TemperatureConverter.TemperatureConverterWSSoap.KelvinToCelsiusAsync(TemperatureConverter.ConverterKelvinCelcius request)
        {
            return base.Channel.KelvinToCelsiusAsync(request);
        }
        
        public System.Threading.Tasks.Task<TemperatureConverter.ConverterKelvinCelcius1> KelvinToCelsiusAsync(float kelvin)
        {
            TemperatureConverter.ConverterKelvinCelcius inValue = new TemperatureConverter.ConverterKelvinCelcius();
            inValue.kelvin = kelvin;
            return ((TemperatureConverter.TemperatureConverterWSSoap)(this)).KelvinToCelsiusAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TemperatureConverter.ConverterFahrenheitKelvin1 TemperatureConverter.TemperatureConverterWSSoap.FahrenheitToKelvin(TemperatureConverter.ConverterFahrenheitKelvin request)
        {
            return base.Channel.FahrenheitToKelvin(request);
        }
        
        public float FahrenheitToKelvin(float fahrenheit)
        {
            TemperatureConverter.ConverterFahrenheitKelvin inValue = new TemperatureConverter.ConverterFahrenheitKelvin();
            inValue.fahrenheit = fahrenheit;
            TemperatureConverter.ConverterFahrenheitKelvin1 retVal = ((TemperatureConverter.TemperatureConverterWSSoap)(this)).FahrenheitToKelvin(inValue);
            return retVal.ConverterFahrenheitKelvinResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterFahrenheitKelvin1> TemperatureConverter.TemperatureConverterWSSoap.FahrenheitToKelvinAsync(TemperatureConverter.ConverterFahrenheitKelvin request)
        {
            return base.Channel.FahrenheitToKelvinAsync(request);
        }
        
        public System.Threading.Tasks.Task<TemperatureConverter.ConverterFahrenheitKelvin1> FahrenheitToKelvinAsync(float fahrenheit)
        {
            TemperatureConverter.ConverterFahrenheitKelvin inValue = new TemperatureConverter.ConverterFahrenheitKelvin();
            inValue.fahrenheit = fahrenheit;
            return ((TemperatureConverter.TemperatureConverterWSSoap)(this)).FahrenheitToKelvinAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TemperatureConverter.ConverterFahrenheitCelcius1 TemperatureConverter.TemperatureConverterWSSoap.FahrenheitToCelcius(TemperatureConverter.ConverterFahrenheitCelcius request)
        {
            return base.Channel.FahrenheitToCelcius(request);
        }
        
        public float FahrenheitToCelcius(float fahrenheit)
        {
            TemperatureConverter.ConverterFahrenheitCelcius inValue = new TemperatureConverter.ConverterFahrenheitCelcius();
            inValue.fahrenheit = fahrenheit;
            TemperatureConverter.ConverterFahrenheitCelcius1 retVal = ((TemperatureConverter.TemperatureConverterWSSoap)(this)).FahrenheitToCelcius(inValue);
            return retVal.ConverterFahrenheitCelciusResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TemperatureConverter.ConverterFahrenheitCelcius1> TemperatureConverter.TemperatureConverterWSSoap.FahrenheitToCelciusAsync(TemperatureConverter.ConverterFahrenheitCelcius request)
        {
            return base.Channel.FahrenheitToCelciusAsync(request);
        }
        
        public System.Threading.Tasks.Task<TemperatureConverter.ConverterFahrenheitCelcius1> FahrenheitToCelciusAsync(float fahrenheit)
        {
            TemperatureConverter.ConverterFahrenheitCelcius inValue = new TemperatureConverter.ConverterFahrenheitCelcius();
            inValue.fahrenheit = fahrenheit;
            return ((TemperatureConverter.TemperatureConverterWSSoap)(this)).FahrenheitToCelciusAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TemperatureConverterWSSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.TemperatureConverterWSSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TemperatureConverterWSSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://webapplicationtemperatureconverter.azurewebsites.net/Services/TemperatureConverterWS.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.TemperatureConverterWSSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://webapplicationtemperatureconverter.azurewebsites.net/Services/TemperatureConverterWS.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            TemperatureConverterWSSoap,
            
            TemperatureConverterWSSoap12,
        }
    }
}
