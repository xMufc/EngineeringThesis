using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BlackHoleForceTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BlackHoleForceTestSimplePasses()
    {
        float expected = 15;
        BlackHole bl = new();
        float result = bl.Force(10, 3, 2);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void BlackHoleForceNormalizedTestSimplePasses()
    {
        int x = 707, y = 707;
        Vector2 expected = new(x, y);
        Vector2 pos = new(1, 1);
        BlackHole bl = new();
        Vector2 result = bl.ForceNormalized(pos, 1000);
        Assert.AreEqual(expected.x, (int)result.x);
        Assert.AreEqual(expected.y, (int)result.y);
    }
    [Test]
    public void BlackHoleDirectionTestSimplePasses()
    {
        int x = 5, y = -2;
        Vector2 expected = new(x, y);
        Vector2 blackHole = new(10, 5);
        Vector2 player = new(5, 7);
        BlackHole bl = new();
        Vector2 result = bl.Direction(blackHole, player);
        Assert.AreEqual(expected.x, (int)result.x);
        Assert.AreEqual(expected.y, (int)result.y);
    }


}
