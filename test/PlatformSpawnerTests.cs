using NUnit.Framework;
using Moq;
using UnityEngine;

public class PlatformSpawnerTests
{
    private PlatformSpawner _platformSpawner;
    private Mock<GameObject> _mockPlatformPrefab;
    private Transform[] _mockSpawnPoints;

    [SetUp]
    public void SetUp()
    {
        GameObject spawnerObject = new GameObject();
        _platformSpawner = spawnerObject.AddComponent<PlatformSpawner>();

        _mockPlatformPrefab = new Mock<GameObject>();
        _mockSpawnPoints = new Transform[1];
        _mockSpawnPoints[0] = new GameObject().transform;

        _platformSpawner.GetType()
            .GetField("_platformPrefab", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(_platformSpawner, _mockPlatformPrefab.Object);
        _platformSpawner.GetType()
            .GetField("_spawnPoints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(_platformSpawner, _mockSpawnPoints);
    }

    [Test]
    public void Spawn_ShouldInstantiatePlatformAtSpawnPoint()
    {
        Transform spawnPoint = _mockSpawnPoints[0];
        spawnPoint.position = new Vector3(0, 1, 0);

        _platformSpawner.Spawn();

        Assert.AreEqual(new Vector3(0, 1, 0), spawnPoint.position, "Platform should be instantiated at correct position.");
    }
}
