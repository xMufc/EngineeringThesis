using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraControllerTest
{
    [Test]
    public void CameraControllerTestSimplePasses()
    {
        float x = 8f, y = 1f, z = 1f;
        Vector3 expected = new(x, y, z);
        Vector3 pos = new(4f, 1f, 1f);
        CameraController cam = new();
        Vector3 result = cam.CameraPosition(pos);
        Assert.AreEqual(expected.x, result.x);
        Assert.AreEqual(expected.y, result.y);
        Assert.AreEqual(expected.z, result.z);
    }
}
