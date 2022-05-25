using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            kataTemperature temperature1 = new kataTemperature(20f, Scale.Fahrenheit);
            kataTemperature temperature2 = new kataTemperature(5f, Scale.Celcius);

            kataTemperature temperatureResult = temperature1.DivideBy(temperature2);
            string finalTemperature = temperatureResult.typeScale.ToString();

            Console.WriteLine(temperatureResult.temperature + finalTemperature);
        }
    }

    class kataTemperature 
    {
        public float temperature;
        public Scale typeScale;
        public kataTemperature(float temperature, Scale scale){
            typeScale = scale;
            this.temperature = temperature;
        }

        public kataTemperature toKelvin(){
            if (this.typeScale == Scale.Celcius)
            {
                this.temperature += 273.15f;
                this.typeScale = Scale.Kelvin;
                return this;
            }
            else {
                this.temperature = ((this.temperature - 32) * (5/9)) + 273.15f;
                this.typeScale = Scale.Kelvin;
                return this;
            }
        }

        public kataTemperature toFahrenheit(){
            if(this.typeScale == Scale.Celcius){
                this.temperature = (this.temperature * 1.8f) + 32;
                this.typeScale = Scale.Fahrenheit;
                return this;
            }
            else {
                this.temperature = (this.temperature - 273.15f) + 32;
                this.typeScale = Scale.Fahrenheit;
                return this;
            }
        }

        public kataTemperature toCelcius() {
            if (this.typeScale == Scale.Kelvin){
                this.temperature -= 273.15f;
                this.typeScale = Scale.Celcius;
                return this;
            }
            else {
                this.temperature = (this.temperature - 32) * (5/9);
                this.typeScale = Scale.Celcius;
                return this;
            }
        }

        public kataTemperature toCompare(kataTemperature number){
            if (this.typeScale == Scale.Kelvin){
                number = number.toKelvin();
                return number;
            }
            else if(this.typeScale == Scale.Celcius){
                number = number.toCelcius();
                return number;
            }
            else{
                number = number.toFahrenheit();
                return number;
            }
        }

        public kataTemperature Add(kataTemperature number) {
            if (this.typeScale == number.typeScale){
                float result = this.temperature + number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
            else {
                kataTemperature temperature = this.toCompare(number);
                float result = this.temperature + number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
        }

        public kataTemperature Substract(kataTemperature number){
            if (this.typeScale == number.typeScale){
                float result = this.temperature - number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
            else {
                kataTemperature temperature = this.toCompare(number);
                float result = this.temperature - number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
        }

        public kataTemperature MultiplyBy(kataTemperature number){
            if (this.typeScale == number.typeScale){
                float result = this.temperature * number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
            else {
                kataTemperature temperature = this.toCompare(number);
                float result = this.temperature * number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
        }

        public kataTemperature DivideBy(kataTemperature number){
            if (this.typeScale == number.typeScale){
                float result = this.temperature / number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
            else {
                kataTemperature temperature = this.toCompare(number);
                float result = this.temperature / number.temperature;
                kataTemperature temperatureResult = new kataTemperature(result, this.typeScale);
                return temperatureResult;
            }
        }
    }
}

enum Scale {
    Kelvin,
    Fahrenheit,
    Celcius
};