using System.Collections;
using System.Collections.Generic;
using Homework;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ConverterPlayModeTests
{
    [UnityTest]
    public IEnumerator StartConversion()
    {
        //Arrange:
        var convertInstruction = new ConvertInstruction<string>(
            new KeyValuePair<string, int>("wood", 1),
            new KeyValuePair<string, int>("plank", 2),
            0.5f
        );
        var converter = new Converter<string>(10, 10, convertInstruction);
        converter.Put(4);

        //Act:
        converter.StartConversion();
        var startConversionTime = Time.time;
        yield return new WaitWhile(() => converter.IsConverting);
        var passedTime = Mathf.Round(Time.time - startConversionTime);

        //Assert:
        Assert.IsFalse(converter.IsConverting);
        Assert.AreEqual(0, converter.InputAmount);
        Assert.AreEqual(8, converter.OutputAmount);
        Assert.AreEqual(2f, passedTime);
    }

    [UnityTest]
    public IEnumerator StartConversionWithOutputOverload()
    {
        //Arrange:
        var convertInstruction = new ConvertInstruction<string>(
            new KeyValuePair<string, int>("wood", 1),
            new KeyValuePair<string, int>("plank", 4),
            0.5f
        );
        var converter = new Converter<string>(10, 10, convertInstruction);
        converter.Put(4);

        //Act:
        converter.StartConversion();
        var startConversionTime = Time.time;
        yield return new WaitWhile(() => converter.IsConverting);
        var passedTime = Mathf.Round(Time.time - startConversionTime);

        //Assert:
        Assert.IsFalse(converter.IsConverting);
        Assert.AreEqual(2, converter.InputAmount);
        Assert.AreEqual(8, converter.OutputAmount);
        Assert.AreEqual(1f, passedTime);
    }

    [UnityTest]
    public IEnumerator StopConversion()
    {
        //Arrange:
        var convertInstruction = new ConvertInstruction<string>(
            new KeyValuePair<string, int>("wood", 1),
            new KeyValuePair<string, int>("plank", 1),
            1f
        );
        var converter = new Converter<string>(10, 10, convertInstruction);
        converter.Put(10);
        converter.StartConversion();

        yield return new WaitForSeconds(2.1f);

        Assert.AreEqual(7, converter.InputAmount);
        
        //Act:
        converter.StopConversion();

        //Assert:
        Assert.IsFalse(converter.IsConverting);
        Assert.AreEqual(8, converter.InputAmount);
        Assert.AreEqual(2, converter.OutputAmount);
        
        yield return new WaitForSeconds(1.1f);
        
        Assert.IsFalse(converter.IsConverting);
        Assert.AreEqual(8, converter.InputAmount);
        Assert.AreEqual(2, converter.OutputAmount);
    }
    
    [UnityTest]
    public IEnumerator PutBeforeStopConversion()
    {
        //Arrange:
        var convertInstruction = new ConvertInstruction<string>(
            new KeyValuePair<string, int>("wood", 3),
            new KeyValuePair<string, int>("plank", 1),
            1f
        );
        var converter = new Converter<string>(10, 10, convertInstruction);
        converter.Put(10);
        converter.StartConversion();

        yield return new WaitForSeconds(2.1f);

        Assert.AreEqual(1, converter.InputAmount);
        
        converter.Put(3);
        
        //Act:
        converter.StopConversion();

        //Assert:
        Assert.AreEqual(7, converter.InputAmount);
    }
    
    [UnityTest]
    public IEnumerator PutFullBeforeStopConversion()
    {
        //Arrange:
        var convertInstruction = new ConvertInstruction<string>(
            new KeyValuePair<string, int>("wood", 3),
            new KeyValuePair<string, int>("plank", 1),
            1f
        );
        var converter = new Converter<string>(10, 10, convertInstruction);
        converter.Put(10);
        converter.StartConversion();

        yield return new WaitForSeconds(2.1f);

        Assert.AreEqual(1, converter.InputAmount);
        
        converter.Put(9);
        
        //Act:
        converter.StopConversion();

        //Assert:
        Assert.AreEqual(10, converter.InputAmount);
    }
}