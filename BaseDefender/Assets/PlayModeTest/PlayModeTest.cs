using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTest
{
    [SetUp]
    public void SetUp()
    {
        Debug.Log("SetUp");
    }

    [TearDown]
    public void TearDown()
    {
        Debug.Log("TearDown");
    }


    [Test]
    public void PlayModeTestSimplePasses()
    {
        //MethodName_WhenTheseConditionsDoesWhat
        // Arrange
        var a = 10;
        var b = 20;

        // Act
        var result = a + b;

        //Assert
        Assert.AreEqual(31, result);
    }


    [Test]
    public void PlayModeTestSimplePasses2()
    {
        Debug.Log("2");
    }
}
