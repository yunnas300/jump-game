using NUnit.Framework;
using UnityEngine;

public class PlatformTests
{
    [Test]
    public void StopMovement_PlatformStopsSuccessfully()
    {
        var platformObject = new GameObject("Platform");
        var platform = platformObject.AddComponent<Platform>();
        platform._moveSpeed = 5f;
        platform.gameObject.AddComponent<Rigidbody2D>();
        platform.StopMovement();
        Vector3 initialPosition = platform.transform.position;
        platform.transform.position += Vector3.right * 1 * Time.deltaTime;
        Assert.AreEqual(initialPosition, platform.transform.position);
    }
}
