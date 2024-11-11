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
            Assert.AreEqual(1, converter.ConvertAmount);
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
            Assert.AreEqual(1, converter.ConvertAmount);
        }

        [TestCaseSource(nameof(PutMultipleCases))]
        public void PutMultiple(int addAmount, int expectedResourceAmount, int expectedReturnAmount)
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            //Act:
            int returnAmount = converter.Put(addAmount);

            //Assert:
            Assert.AreEqual(converter.ConvertAmount, expectedResourceAmount);
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

        [TestCaseSource(nameof(ConvertCases))]
        public void Convert(ConvertInstruction convertInstruction, int putAmount, bool expectedResult,
            int expectedInputAmount,
            int expectedOutputAmount)
        {
            //Arrange:
            var converter = new Converter(10, 10, convertInstruction);
            converter.Put(putAmount);

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.AreEqual(result, expectedResult);
            Assert.AreEqual(converter.ConvertAmount, expectedInputAmount);
            Assert.AreEqual(converter.ReadyAmount, expectedOutputAmount);
        }

        private static IEnumerable<TestCaseData> ConvertCases()
        {
            IResource wood = new ResourceItem("wood");
            IResource plank = new ResourceItem("plank");

            yield return new(
                new ConvertInstruction(
                    new KeyValuePair<IResource, int>(wood, 3),
                    new KeyValuePair<IResource, int>(plank, 6),
                    1f
                ),
                5, true, 2, 6
            );
            
            yield return new(
                new ConvertInstruction(
                    new KeyValuePair<IResource, int>(wood, 1),
                    new KeyValuePair<IResource, int>(plank, 1),
                    1f
                ), 
                5, true, 4, 1
            );
            
            yield return new(
                new ConvertInstruction(
                    new KeyValuePair<IResource, int>(wood, 2),
                    new KeyValuePair<IResource, int>(plank, 2),
                    1f
                ), 
                5, true, 3, 2
            );
            
            yield return new(
                new ConvertInstruction(
                    new KeyValuePair<IResource, int>(wood, 6),
                    new KeyValuePair<IResource, int>(plank, 1),
                    1f
                ), 
                5, false, 5, 0
            );
            
            yield return new(
                new ConvertInstruction(
                    new KeyValuePair<IResource, int>(wood, 1),
                    new KeyValuePair<IResource, int>(plank, 11),
                    1f
                ), 
                5, false, 5, 0
            );
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
            Assert.Zero(converter.ConvertAmount);
            Assert.Zero(converter.ReadyAmount);
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
            Assert.AreEqual(4, converter.ConvertAmount);
            Assert.AreEqual(1, converter.ReadyAmount);
        }

        [Test]
        public void Take()
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());
            converter.Put(5);
            converter.Convert();

            //Act:
            bool result = converter.Take();

            //Assert:
            Assert.IsTrue(result);
            Assert.AreEqual(4, converter.ConvertAmount);
            Assert.Zero(converter.ReadyAmount);
        }

        [Test]
        public void WhenTakeWhileOutputEmptyThenFalse()
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());
            converter.Put(5);

            //Act:
            bool result = converter.Take();

            //Assert:
            Assert.IsFalse(result);
            Assert.AreEqual(5, converter.ConvertAmount);
            Assert.Zero(converter.ReadyAmount);
        }

        [TestCaseSource(nameof(TakeMultipleCases))]
        public void TakeMultiple(int takeAmount, bool expectedResult, int expectedOutputAmount)
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            converter.Put(5);

            for (var i = 0; i < 3; i++)
            {
                converter.Convert();
            }

            //Act:
            bool result = converter.Take(takeAmount);

            //Assert:
            Assert.AreEqual(result, expectedResult);
            Assert.AreEqual(converter.ReadyAmount, expectedOutputAmount);
        }

        private static IEnumerable<TestCaseData> TakeMultipleCases()
        {
            yield return new(3, true, 0);
            yield return new(1, true, 2);
            yield return new(4, false, 3);
            yield return new(0, true, 3);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void WhenTakeMultipleWithNegativeAmountThenThrow(int takeAmount)
        {
            //Arrange:
            var converter = new Converter(10, 10, CreateInstruction());

            converter.Put(5);

            for (var i = 0; i < 3; i++)
            {
                converter.Convert();
            }

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => { converter.Take(takeAmount); });
        }

        private static ConvertInstruction CreateInstruction()
        {
            IResource wood = new ResourceItem("wood");
            IResource plank = new ResourceItem("plank");

            return new ConvertInstruction(
                new KeyValuePair<IResource, int>(wood, 1),
                new KeyValuePair<IResource, int>(plank, 1),
                1f
            );
        }
    }
}