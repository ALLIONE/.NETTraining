using NFluent;
using NUnit.Framework;
using System.Linq;

namespace CSharpDiscovery
{
    using System;

    public class Calculator
    {
        public string Name = "Calculator";

        public double Sum(double[] mesVals)
        {
            return mesVals.Sum();
        }

        public double Sum(string mesVals)
        {
            double resultat = 0;
            string[] recup = mesVals.Split('+');
            foreach (string s in recup)
            {
                resultat = double.Parse(s);
            }
            return resultat;
        }

    }
    [TestFixture]
    public class ClassesTests
    {
        [Test]
        public void CreateACalculatorClassWithADefaultConstructorAndInstanciate()
        {
            Calculator calculator = new Calculator();
            Check.That(calculator).IsNotNull();
        }

        [Test]
        public void AddAnotherConstructorWithAFriendlyNameAndInstanciate()
        {
            Calculator calculator = new Calculator();
            // use a public member for Name for now, i.e public string Name;
            Check.That(calculator.Name).Equals("Calculator");
        }

        [Test]
        public void AddAMethodThatMakeASumOfAnArrayOfDouble()
        {
            var valuesToSum = new[] { 1.3, 1.7 };
            Calculator calculator = new Calculator();
            double sumOfTheArray = calculator.Sum(valuesToSum);
            // add a method Sum to calculator class
            Check.That(sumOfTheArray).Equals(3.0);
        }

        //[Test]
        //public void AddAMethodOverloadThatMakeASumOfTwoDoubleFromStringRepresentation()
        //{
        //    Calculator calc = new Calculator();
        //    var sumOfTwoDoubleFromString = "1,0+2";
        //    //add a method with the same name that uses the previous method
        //    //tips: use string.Split
        //    double onePlusTwo = calc.Sum(sumOfTwoDoubleFromString);
        //    Check.That(onePlusTwo).Equals(3.0);
        //}

        //[Test]
        //public void AddAGetterForNameInsteadOfPublicNameMember()
        //{
        //    Check.That(calculator.Name).Equals("Calculator");
        //}

        //[Test]
        //public void AddASetterForNameAndChangeNameWithIt()
        //{
        //    Check.That(calculator.Name).Equals("Enhanced Calculator");
        //}

        //[Test]
        //public void UseObjectInitilizerWithDefaultConstructor()
        //{
        //    Check.That(calculator.Name).Equals("Calculator");
        //}

        //[Test]
        //public void DefineConstantForPi()
        //{
        //    var sumOfADoubleAndPiConstant = "1,2 + pi";
        //    // define pi constant (as double) and replace pi string with constant value
        //    Check.That(sum).Equals(4.34);
        //}

        //[Test]
        //public void StaticReadonlyMembers()
        //{
        //    var sumOfADoubleAndPiConstant = "1,2 + pi";
        //    // replace pi constant with a static readonly member
        //    Check.That(sum).Equals(4.34);
        //}

        //[Test]
        //public void MakeSumMethodsStaticAsTheyDoNotNeedAnyInstanceSpecific()
        //{
        //    // make sum methods static and call one these to retrieve a sum of double array values
        //    Check.That(sum).Equals(3.0);
        //}

        //[Test]
        //public void AddStaticCalculatorClass()
        //{
        //    // define a static class StaticCalculator that uses Calculator static methods & define static getter for Name
        //    Check.That(staticCalculator.Name).Equals("Static calculator");
        //}
    }
}
