using NUnit.Framework;
using UnityEngine;

public class PlayerControllerTests
{
    [Test]
    public void Jump_PlayerCanJumpOnlyOnPlatform()
    {
        var playerObject = new GameObject("Player");
        var playerController = playerObject.AddComponent<PlayerController>();
        playerController._jumpForce = 10f;

        var playerRigidbody = playerObject.AddComponent<Rigidbody2D>();
        var platformObject = new GameObject("Platform");
        platformObject.AddComponent<Collider2D>();

        var contactFilter = new ContactFilter2D();
        playerController._platform = contactFilter;
        playerController.Jump();
        Assert.AreEqual(playerRigidbody.velocity.y, 10f);
    }
}
