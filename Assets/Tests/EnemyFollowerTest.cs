using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyFollowerTest
{
    [Test]
    public void RotateAngleTestSimplePasses()
    {
        float speed = 10f;
        float expected = 0.5f;
        EnemyFollower enemy = new();
        float result = enemy.SpeedInTime(speed, 0.05f);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void DistanceToPointTestSimplePasses()
    {
        float expected = 4f;
        Vector2 destination = new(1f, 2f);
        Vector2 actual = new(5f, 2f);
        EnemyFollower enem = new();
        float result = enem.DistanceToPoint(destination, actual);
        Assert.AreEqual(expected, result);
    }
}
