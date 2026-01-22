using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SkullJumpTest
{
    [Test]
    public void GroundTestSimplePasses()
    {
        Vector3 origin = new(-10f, -5f, 0f);
        Vector3 size = new(0.62f, 0.88f, 0f);
        int ground = 64;
        SkullJump skull = new();
        bool result = skull.IsGrounded(origin, size, ground);
        Assert.IsFalse(result);
    }
}
