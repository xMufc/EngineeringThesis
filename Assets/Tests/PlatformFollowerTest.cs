using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlatformFollowerTest
{
    [Test]
    public void DistanceToPointTestSimplePasses()
    {
        float expected = 2f;
        Vector2 destination = new(1f, 2f);
        Vector2 actual = new(3f, 2f);
        PlatformFollower plat = new();
        float result = plat.DistanceToPoint(destination, actual);
        Assert.AreEqual(expected, result);
    }
}
