using System.Collections;
using System.Collections.Generic;
using Homework;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ConverterPlayModeTests
{
    [UnityTest]
    public IEnumerator ConvertRoutine()
    {
        //Arrange:
        IResource wood = new ResourceItem("wood");
        IResource plank = new ResourceItem("plank");

        var convertInstruction = new ConvertInstruction(
            new KeyValuePair<IResource, int>(wood, 1),
            new KeyValuePair<IResource, int>(plank, 1),
            1f
        );
        var converter = new Converter(10, 10, convertInstruction);
        converter.Put(5);

        //Act:
        converter.StartConversion();
        var startConversionTime = Time.realtimeSinceStartup;
        yield return new WaitWhile(() => converter.IsConverting);
        var passedTime = Time.realtimeSinceStartup - startConversionTime;

        //Assert:
        Assert.AreEqual(0, converter.ConvertAmount);
        Assert.AreEqual(5, converter.ReadyAmount);
        Assert.AreEqual(5, passedTime);
    }
}