using NUnit.Framework;
using TMPro;
using UnityEngine;

public class ScoreUITests
{
    [Test]
    public void IncreaseScore_ScoreIncreasesByOne()
    {
        var scoreUIObject = new GameObject("ScoreUI");
        var scoreUI = scoreUIObject.AddComponent<ScoreUI>();
        var textComponent = scoreUIObject.AddComponent<TextMeshProUGUI>();
        scoreUI._field = textComponent;
        scoreUI.IncreaseScore();
        Assert.AreEqual(1, int.Parse(scoreUI._field.text));
    }
}
