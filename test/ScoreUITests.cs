using NUnit.Framework;
using Moq;
using TMPro;

public class ScoreUITests
{
    private ScoreUI _scoreUI;
    private Mock<TextMeshProUGUI> _mockField;

    [SetUp]
    public void SetUp()
    {
        GameObject uiObject = new GameObject();
        _scoreUI = uiObject.AddComponent<ScoreUI>();

        _mockField = new Mock<TextMeshProUGUI>();
        _scoreUI.GetType()
            .GetField("_field", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(_scoreUI, _mockField.Object);
    }

    [Test]
    public void IncreaseScore_ShouldIncrementScoreAndUpdateUI()
    {
        // Act
        _scoreUI.IncreaseScore();

        // Assert
        _mockField.VerifySet(field => field.text = "1", Times.Once);
    }
}