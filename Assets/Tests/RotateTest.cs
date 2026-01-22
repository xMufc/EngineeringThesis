using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RotateTest
{
    [Test]
    public void RotateAngleTestSimplePasses()
    {
        float speed = 4f;
        float expected = -72f;
        Rotate rot = new();
        float result = rot.RotateAngle(speed, 0.05f);
        Assert.AreEqual(expected, result);
    }
}
