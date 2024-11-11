using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Homework
{
    public sealed class ConverterTests
    {
        [Test]
        public void Instantiate()
        {
            //Act:
            var converter = new Converter(
                inputCapacity: 10,
                outputCapacity: 10,
                instruction: CreateInstruction()
            );

            //Assert:
            Assert.NotNull(converter);
        }

        [Test]
        public void WhenInstantiateWithNullInstructionThenThrow()
        {
            //Assert:
            Assert.Catch<ArgumentNullException>(() =>
            {
                var converter = new Converter(10, 10, null);
            });
        }

        [TestCase(-10, 10)]
        [TestCase(10, -10)]
        public void WhenInstantiateWithInvalidCapacitiesThenThrow(int inputCapacity, int outputCapacity)
        {
            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                var converter = new Converter(inputCapacity, outputCapacity, CreateInstruction());
            });
        }

        [Test]
        public void Put()
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            //Act:
            bool result = converter.Put();

            //Assert:
            Assert.IsTrue(result);
            Assert.AreEqual(1, converter.GetConvertAmount());
        }

        [Test]
        public void WhenPutWhileFullThenFalse()
        {
            //Arrange:
            var converter = new Converter(1, 10, CreateInstruction());

            //Act:
            converter.Put();
            bool result = converter.Put();

            //Assert:
            Assert.IsFalse(result);
            Assert.AreEqual(1, converter.GetConvertAmount());
        }

        [TestCaseSource(nameof(PutMultipleCases))]
        public void PutMultiple(int addAmount, int expectedResourceAmount, int expectedReturnAmount)
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            //Act:
            int returnAmount = converter.Put(addAmount);

            //Assert:
            Assert.AreEqual(converter.GetConvertAmount(), expectedResourceAmount);
            Assert.AreEqual(returnAmount, expectedReturnAmount);
        }

        private static IEnumerable<TestCaseData> PutMultipleCases()
        {
            yield return new(10, 10, 0);
            yield return new(20, 10, 10);
            yield return new(15, 10, 5);
            yield return new(5, 5, 0);
            yield return new(0, 0, 0);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void WhenPutNegativeAmountThenThrow(int addAmount)
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => { converter.Put(addAmount); });
        }

        [Test]
        public void Convert()
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());
            converter.Put(5);

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.IsTrue(result);
            Assert.AreEqual(4, converter.GetConvertAmount());
            Assert.AreEqual(1, converter.GetReadyAmount());
        }

        [Test]
        public void WhenConvertWhileInputEmptyThenFalse()
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.IsFalse(result);
            Assert.Zero(converter.GetConvertAmount());
            Assert.Zero(converter.GetReadyAmount());
        }

        [Test]
        public void WhenConvertWhileFullOutputThenFalse()
        {
            //Arrange:
            var converter = new Converter(10, 1, CreateInstruction());
            converter.Put(5);
            converter.Convert();

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.IsFalse(result);
            Assert.AreEqual(4, converter.GetConvertAmount());
            Assert.AreEqual(1, converter.GetReadyAmount());
        }

        private static ConvertInstruction CreateInstruction()
        {
            IResource wood = new ResourceItem("wood");
            IResource plank = new ResourceItem("plank");

            return new ConvertInstruction(
                inputResource: wood,
                outputResource: plank,
                convertDuration: 1f
            );
        }
    }
}