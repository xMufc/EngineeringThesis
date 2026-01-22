using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
    [Test]
    public void WallSlideSpeedTestSimplePasses()
    {
        float expected = -200;
        float value = -1000, min = -200;
        PlayerMovement play = new();
        float result = play.WallSlideSpeed(value, min, float.MaxValue);
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void IsGroundedNormalGravityTestSimplePasses()
    {
        Vector3 origin = new(-10f, -5f, 0f);
        Vector3 size = new(0.62f, 0.88f, 0f);
        float gravity = 3f;
        int ground = 64;
        PlayerMovement play = new();
        bool result = play.IsGrounded(origin, size, gravity, ground);
        Assert.IsFalse(result);
        gravity = -3;
        result = play.IsGrounded(origin, size, gravity, ground);
        Assert.IsFalse(result);
    }
    [Test]
    public void IsGroundedChangeGravityTestSimplePasses()
    {
        Vector3 origin = new(-10f, -5f, 0f);
        Vector3 size = new(0.62f, 0.88f, 0f);
        float gravity = -3;
        int ground = 64;
        PlayerMovement play = new();
        bool result = play.IsGrounded(origin, size, gravity, ground);
        Assert.IsFalse(result);
    }
}
