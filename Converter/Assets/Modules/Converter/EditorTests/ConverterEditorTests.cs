using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Homework
{
    public sealed class ConverterEditorTests
    {
        [Test]
        public void Instantiate()
        {
            //Act:
            var converter = new Converter<string>(
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
                var converter = new Converter<string>(10, 10, null);
            });
        }

        [TestCase(-10, 10)]
        [TestCase(10, -10)]
        public void WhenInstantiateWithInvalidCapacitiesThenThrow(int inputCapacity, int outputCapacity)
        {
            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                var converter = new Converter<string>(inputCapacity, outputCapacity, CreateInstruction());
            });
        }

        [Test]
        public void Put()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction());

            //Act:
            bool result = converter.Put();

            //Assert:
            Assert.IsTrue(result);
            Assert.AreEqual(1, converter.InputAmount);
        }

        [Test]
        public void WhenPutWhileFullThenFalse()
        {
            //Arrange:
            var converter = new Converter<string>(1, 10, CreateInstruction());

            //Act:
            converter.Put();
            bool result = converter.Put();

            //Assert:
            Assert.IsFalse(result);
            Assert.AreEqual(1, converter.InputAmount);
        }

        [TestCaseSource(nameof(PutMultipleCases))]
        public void PutMultiple(int addAmount, int expectedResourceAmount, int expectedReturnAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction());

            //Act:
            int returnAmount = converter.Put(addAmount);

            //Assert:
            Assert.AreEqual(converter.InputAmount, expectedResourceAmount);
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
            var converter = new Converter<string>(10, 10, CreateInstruction());

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => { converter.Put(addAmount); });
        }

        [TestCaseSource(nameof(ConvertCases))]
        public void Convert(ConvertInstruction<string> convertInstruction, int putAmount, bool expectedResult,
            int expectedInputAmount,
            int expectedOutputAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, convertInstruction);
            converter.Put(putAmount);

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.AreEqual(result, expectedResult);
            Assert.AreEqual(converter.InputAmount, expectedInputAmount);
            Assert.AreEqual(converter.OutputAmount, expectedOutputAmount);
        }

        private static IEnumerable<TestCaseData> ConvertCases()
        {
            yield return new(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 6),
                    1f
                ),
                5, true, 2, 6
            );

            yield return new(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 1),
                    new KeyValuePair<string, int>("plank", 1),
                    1f
                ),
                5, true, 4, 1
            );

            yield return new(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 2),
                    new KeyValuePair<string, int>("plank", 2),
                    1f
                ),
                5, true, 3, 2
            );

            yield return new(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 6),
                    new KeyValuePair<string, int>("plank", 1),
                    1f
                ),
                5, false, 5, 0
            );

            yield return new(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 1),
                    new KeyValuePair<string, int>("plank", 11),
                    1f
                ),
                5, false, 5, 0
            );
        }

        [Test]
        public void WhenConvertWhileInputEmptyThenFalse()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction());

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.IsFalse(result);
            Assert.Zero(converter.InputAmount);
            Assert.Zero(converter.OutputAmount);
        }

        [Test]
        public void WhenConvertWhileFullOutputThenFalse()
        {
            //Arrange:
            var converter = new Converter<string>(10, 1, CreateInstruction());
            converter.Put(5);
            converter.Convert();

            //Act:
            bool result = converter.Convert();

            //Assert:
            Assert.IsFalse(result);
            Assert.AreEqual(4, converter.InputAmount);
            Assert.AreEqual(1, converter.OutputAmount);
        }

        [TestCaseSource(nameof(CanConvertCases))]
        public bool CanConvert(ConvertInstruction<string> convertInstruction, int putAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, convertInstruction);
            converter.Put(putAmount);

            //Act:
            return converter.CanConvert();
        }

        private static IEnumerable<TestCaseData> CanConvertCases()
        {
            yield return new TestCaseData(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 6),
                    1f
                ),
                5
            ).Returns(true);

            yield return new TestCaseData(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 11),
                    1f
                ),
                5
            ).Returns(false);

            yield return new TestCaseData(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 6),
                    1f
                ),
                2
            ).Returns(false);

            yield return new TestCaseData(
                new ConvertInstruction<string>(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 10),
                    1f
                ),
                3
            ).Returns(true);
        }

        [Test]
        public void Take()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction());
            converter.Put(5);
            converter.Convert();

            //Act:
            bool result = converter.Take();

            //Assert:
            Assert.IsTrue(result);
            Assert.AreEqual(4, converter.InputAmount);
            Assert.Zero(converter.OutputAmount);
        }

        [Test]
        public void WhenTakeWhileOutputEmptyThenFalse()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction());
            converter.Put(5);

            //Act:
            bool result = converter.Take();

            //Assert:
            Assert.IsFalse(result);
            Assert.AreEqual(5, converter.InputAmount);
            Assert.Zero(converter.OutputAmount);
        }

        [TestCaseSource(nameof(TakeMultipleCases))]
        public void TakeMultiple(int takeAmount, bool expectedResult, int expectedOutputAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction());

            converter.Put(5);

            for (var i = 0; i < 3; i++)
            {
                converter.Convert();
            }

            //Act:
            bool result = converter.Take(takeAmount);

            //Assert:
            Assert.AreEqual(result, expectedResult);
            Assert.AreEqual(converter.OutputAmount, expectedOutputAmount);
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
            var converter = new Converter<string>(10, 10, CreateInstruction());

            converter.Put(5);

            for (var i = 0; i < 3; i++)
            {
                converter.Convert();
            }

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => { converter.Take(takeAmount); });
        }

        private static ConvertInstruction<string> CreateInstruction()
        {
            return new ConvertInstruction<string>(
                new KeyValuePair<string, int>("wood", 1),
                new KeyValuePair<string, int>("plank", 1),
                1f
            );
        }
    }
}