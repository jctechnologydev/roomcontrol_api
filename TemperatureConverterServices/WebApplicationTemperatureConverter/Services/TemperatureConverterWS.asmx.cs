/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 01/2023 14:00:20 PM</date>
*	<description>Web Service - Conversor de temperaturas</description>
**/

using System.Web.Services;

namespace WebApplicationTemperatureConverter.Services
{

    /// <summary>
    /// Summary description for TemperatureConverterWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/",
                Description = "Smart Rooms - converter temperature XML web service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TemperatureConverterWS : System.Web.Services.WebService
    {
        #region Celcius
        [WebMethod(MessageName = "Converter Celcius-kelvin",
            Description = "Converter Celcius-kelvin")]
        public float CelsiusToKelvin(float celcius)
        {
            return celcius + 273.15F;
        }

        [WebMethod(MessageName = "Converter Celcius-Fahrenheit",
           Description = "Calcular Soma de dois números inteiros")]
        public float CelsiusToFahrenheit(float celcius)
        {
            return celcius * 1.8f + 32f;
        }

            
        #endregion

        #region Kelvin
        [WebMethod(MessageName = "Converter Kelvin-Fahrenheit",
          Description = "Converter Kelvin-Fahrenheit")]
        public float KelvinToFahrenheit(float kelvin)
        {
            return kelvin * 1.8f - 459.67f; ;
        }

        [WebMethod(MessageName = "Converter Kelvin-Celcius",
         Description = "Converter Kelvin-Celcius")]
        public float KelvinToCelsius(float kelvin)
        {
            return kelvin - 273.15F;
        }
        #endregion

        #region Faranheit
        [WebMethod(MessageName = "Converter Fahrenheit-Kelvin",
          Description = "Converter Fahrenheit-Kelvin")]
        public float FahrenheitToKelvin(float fahrenheit)
        {
            return (fahrenheit - 32f) / 1.8f;
        }

        [WebMethod(MessageName = "Converter Fahrenheit-Celcius",
         Description = "Converter Fahrenheit-Celcius")]
        public float FahrenheitToCelcius(float fahrenheit)
        {
            return (fahrenheit - 32f) / 1.8f;
        }
        #endregion

    }
}