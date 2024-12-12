using System;
using System.Collections.Generic;
using Modules.Converter.Scripts;
using NUnit.Framework;

namespace Modules.Converter.EditorTests
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
        public void InstantiateWithInitialCount()
        {
            //Act:
            var converter = new Converter<string>(
                10,
                10,
                CreateInstruction(),
                2,
                3
            );

            //Assert:
            Assert.NotNull(converter);
            Assert.AreEqual(2, converter.InputAmount);
            Assert.AreEqual(3, converter.OutputAmount);
        }

        [Test]
        public void WhenInstantiateWithNegativeInitialCountThenThrow()
        {
            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                new Converter<string>(
                    10,
                    10,
                    CreateInstruction(),
                    -2,
                    3
                );
            });

            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                new Converter<string>(
                    10,
                    10,
                    CreateInstruction(),
                    2,
                    -3
                );
            });
        }


        [Test]
        public void WhenInstantiateWithInitialCountMoreThanCapacityThenTrim()
        {
            //Act:
            var converter = new Converter<string>(
                10,
                10,
                CreateInstruction(),
                11,
                23
            );

            //Assert:
            Assert.NotNull(converter);
            Assert.AreEqual(10, converter.InputAmount);
            Assert.AreEqual(10, converter.OutputAmount);
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

        [TestCaseSource(nameof(CanConvertCases))]
        public bool CanConvert(Converter<string> converter, int putAmount)
        {
            //Arrange:
            converter.Put(putAmount);

            //Act:
            return converter.CanConvert();
        }

        private static IEnumerable<TestCaseData> CanConvertCases()
        {
            yield return new TestCaseData(
                new Converter<string>(10, 10, new(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 6),
                    1f
                )),
                5
            ).Returns(true);

            yield return new TestCaseData(
                new Converter<string>(10, 10, new(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 11),
                    1f
                )),
                5
            ).Returns(false);

            yield return new TestCaseData(
                new Converter<string>(10, 10, new(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 6),
                    1f
                )),
                2
            ).Returns(false);

            yield return new TestCaseData(
                new Converter<string>(10, 10, new(
                    new KeyValuePair<string, int>("wood", 3),
                    new KeyValuePair<string, int>("plank", 10),
                    1f
                )),
                3
            ).Returns(true);
        }

        [Test]
        public void Take()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction(), outputAmount: 1);

            //Act:
            bool result = converter.Take();

            //Assert:
            Assert.IsTrue(result);
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
            var converter = new Converter<string>(10, 10, CreateInstruction(), 2, 3);

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
        
        [TestCase(4,6)]
        [TestCase(1,9)]
        [TestCase(5,5)]
        public void TakeWhileConverting(int takeAmount,int expectedOutputAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, new(
                new KeyValuePair<string, int>("wood", 1),
                new KeyValuePair<string, int>("plank", 1),
                1f
            ),10);
            converter.StartConversion();

            converter.Update(5.1f);

            //Act:
            converter.Take(takeAmount);
            converter.Update(5.1f);

            //Assert:
            Assert.IsFalse(converter.IsConverting);
            Assert.AreEqual(expectedOutputAmount, converter.OutputAmount);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void WhenTakeMultipleWithNegativeAmountThenThrow(int takeAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, CreateInstruction(), 2, 3);

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => { converter.Take(takeAmount); });
        }

        [Test]
        public void StartConversion()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, new(
                new KeyValuePair<string, int>("wood", 1),
                new KeyValuePair<string, int>("plank", 2),
                0.5f
            ));
            converter.Put(4);

            //Act:
            converter.StartConversion();
            converter.Update(2f);

            //Assert:
            Assert.IsFalse(converter.IsConverting);
            Assert.AreEqual(0, converter.InputAmount);
            Assert.AreEqual(8, converter.OutputAmount);
        }

        [Test]
        public void StartConversionWithOutputOverload()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, new(
                new KeyValuePair<string, int>("wood", 1),
                new KeyValuePair<string, int>("plank", 4),
                1f
            ), 4);

            //Act:
            converter.StartConversion();
            converter.Update(4f);

            //Assert:
            Assert.IsFalse(converter.IsConverting);
            Assert.AreEqual(2, converter.InputAmount);
            Assert.AreEqual(8, converter.OutputAmount);
        }

        [Test]
        public void StopConversion()
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, new(
                new KeyValuePair<string, int>("wood", 1),
                new KeyValuePair<string, int>("plank", 1),
                1f
            ));
            converter.Put(10);
            converter.StartConversion();

            converter.Update(2.5f);

            Assert.AreEqual(7, converter.InputAmount);

            //Act:
            converter.StopConversion();

            //Assert:
            Assert.IsFalse(converter.IsConverting);
            Assert.AreEqual(8, converter.InputAmount);
            Assert.AreEqual(2, converter.OutputAmount);

            converter.Update(1f);

            Assert.IsFalse(converter.IsConverting);
            Assert.AreEqual(8, converter.InputAmount);
            Assert.AreEqual(2, converter.OutputAmount);
        }

        [TestCase(2,6)]
        [TestCase(9,10)]
        [TestCase(100,10)]
        public void PutWhileConverting(int putAmount,int expectedInputAmount)
        {
            //Arrange:
            var converter = new Converter<string>(10, 10, new(
                new KeyValuePair<string, int>("wood", 3),
                new KeyValuePair<string, int>("plank", 1),
                1f
            ), 10);
            converter.StartConversion();

            converter.Update(2.2f);

            Assert.AreEqual(1, converter.InputAmount);

            //Act:
            converter.Put(putAmount);
            converter.StopConversion();

            //Assert:
            Assert.AreEqual(expectedInputAmount, converter.InputAmount);
        }

        private static Converter<string>.Instruction CreateInstruction()
        {
            return new(
                new KeyValuePair<string, int>("wood", 1),
                new KeyValuePair<string, int>("plank", 1),
                1f
            );
        }
    }
}