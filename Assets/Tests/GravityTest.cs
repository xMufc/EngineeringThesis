using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GravityTest
{
    [Test]
    public void ChangeGravityTestSimplePasses()
    {
        float expected = -4;
        Gravity grav = new();
        float result = grav.ChangeGravity(4);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void GravityRatationTestSimplePasses()
    {
        float expected = 180;
        Gravity grav = new();
        float result = grav.RotationAngles(false);
        Assert.AreEqual(expected, result);
    }
}
