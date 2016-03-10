using System;
using NFluent;
using NUnit.Framework;

namespace CSharpDiscovery
{
    using NFluent.Extensions;

    [TestFixture]
    public class TypesTests
    {
        [Test]
        public void NFluentAndNUnitAreWorking()
        {
            Check.That(true).IsTrue();
        }

        [Test]
        public void AnIntIsNotEqualToSameIntStringRepresentation()
        {
            string integerAsAString = "0";
            int integer = 0;
            Check.That(integerAsAString).Not.Equals(integer);
        }

        [Test]
        public void AnIntIsNotEqualToSameIntAsFloat()
        {
            int integerAsAFloat = 0;
            float integer = 0;
            Check.That(integerAsAFloat).Not.Equals(integer);
        }

        [Test]
        public void AnIntIsNotEqualToSameIntAsDouble()
        {
            int integerAsADouble = 0;
            double integer = 0;
            Check.That(integerAsADouble).Not.Equals(integer);
        }

        [Test]
        public void AnIntIsNotEqualToSameIntAsDecimal()
        {
            int integerAsADecimal = 0;
            decimal integer = 0;
            Check.That(integerAsADecimal).Not.Equals(integer);
        }

        [Test]
        public void AnIntIsNotEqualToSameIntAsLong()
        {
            int integerAsLong = 0;
            long integer = 0;
            Check.That(integerAsLong).Not.Equals(integer);
        }

        [Test]
        public void AnIntIsEqualToSameIntAsInt32()
        {
            int integerAsInt32 = 0;
            int integer = 0;
            Check.That(integerAsInt32).Equals(integer);
        }

        [Test]
        public void AFloatCanBeCastedToInteger()
        {
            float single = 1.0F;
            int expectedInteger = 1;
            int singleCastedToInteger =(int) single;
            Check.That(singleCastedToInteger).Equals(expectedInteger);
        }

        [Test]
        public void AnIntCanBeImplicitlyCastedToFloat()
        {
            int integer = 1;
            float expectedSingle = 1.0F;
            float singleImplicitlyCastToInteger = integer;
            Check.That(singleImplicitlyCastToInteger).Equals(expectedSingle);
        }

        [Test]
        public void AStringCanBeParsedToInteger()
        {
            string integerString = "30";
            int expectedInteger = 30;
            int integerParsed = int.Parse(integerString);
            Check.That(integerParsed).Equals(expectedInteger);
        }

        public void ParseFloatStringAsInteger()
        {
            string monFloat = "30.0";
            int wtf = int.Parse(monFloat);
        }
        [Test]
        public void AFloatStringRepresentationCannotBeParsedToInteger()
        {
            // Create a method named ParseFloatStringAsInteger that takes no argument,
            //return void and parse a float string representation "30.0"
            Check.That(ParseFloatStringAsInteger).Throws<FormatException>();
        }

        [Test]
        public void TryToParseAStringToInteger()
        {
            string floatString = "30.0";
            int expectedInteger = 0;
            int integerParsed = expectedInteger;
            bool tryParseFailed = int.TryParse(floatString, out integerParsed);

            // Use int.TryParse, /!\ it uses an "out" argument
            Check.That(integerParsed).Equals(default(int));
            Check.That(tryParseFailed).IsFalse();
        }

        [Test]
        public void UseVarForLessVerbosityButKeepStrongTyping()
        {
            string integerAsAString = "0";
            var integer = 0;
            Check.That(integerAsAString).Not.Equals(integer);
        }

        [Test]
        public void NullableIntWithNullValueDoesNotHaveValue()
        {
            // use "int?" to declare a nullable int initialized with null, then try also with Nullable<int>
            int? nullableInteger = null;
            Check.That(nullableInteger.HasValue).IsFalse();
        }

        public void GetNullableIntValue()
        {
            int? nullableint = null;
            int lolol = nullableint.Value;
        }
        [Test]
        public void GettingValueOfANullableIntwithNullValueThrowsAnInvalidOperationException()
        {
            // Create a method named GetNullableIntValue that takes no argument,
            //return void and access a nullable int vailue (nullableInteger.Value)
            Check.That(GetNullableIntValue).Throws<InvalidOperationException>();
        }

        [Test]
        public void NullableIntWithNullValueDoesNotHaveValue2()
        {
            // use "int?" to declare a nullable int initialized with 30
            int? nullableInteger = 30;
            Check.That(nullableInteger.Value).Equals(30);
        }
    }
}
