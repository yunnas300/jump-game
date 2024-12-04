using NUnit.Framework;
using Moq;
using UnityEngine;

public class PlayerControllerTests
{
    private PlayerController _playerController;
    private Mock<Rigidbody2D> _mockRigidbody;

    [SetUp]
    public void SetUp()
    {
        GameObject playerObject = new GameObject();
        _mockRigidbody = new Mock<Rigidbody2D>();
        _playerController = playerObject.AddComponent<PlayerController>();

        _playerController.GetType()
            .GetField("_rigidbody", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(_playerController, _mockRigidbody.Object);
    }

    [Test]
    public void Jump_ShouldAddForce_WhenOnPlatform()
    {
        _mockRigidbody.Setup(rb => rb.IsTouching(It.IsAny<ContactFilter2D>())).Returns(true);

        _playerController.Jump();

        _mockRigidbody.Verify(rb => rb.AddForce(It.IsAny<Vector2>(), ForceMode2D.Impulse), Times.Once);
    }

    [Test]
    public void Jump_ShouldNotAddForce_WhenNotOnPlatform()
    {
        _mockRigidbody.Setup(rb => rb.IsTouching(It.IsAny<ContactFilter2D>())).Returns(false);

        _playerController.Jump();
        _mockRigidbody.Verify(rb => rb.AddForce(It.IsAny<Vector2>(), ForceMode2D.Impulse), Times.Never);
    }
}
