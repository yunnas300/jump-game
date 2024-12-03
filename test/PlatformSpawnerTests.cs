using NUnit.Framework;
using UnityEngine;

public class PlatformSpawnerTests
{
    [Test]
    public void Spawn_PlatformPositionIsCorrect()
    {
        var spawnerObject = new GameObject("PlatformSpawner");
        var spawner = spawnerObject.AddComponent<PlatformSpawner>();
        spawner._platformPrefab = new GameObject("Platform");
        var spawnPoint = new GameObject("SpawnPoint").transform;
        spawner._spawnPoints = new Transform[] { spawnPoint };
        spawner.Spawn();
        var spawnedPlatform = GameObject.Find("Platform");
        Assert.IsNotNull(spawnedPlatform);
        Assert.AreEqual(spawnPoint.position, spawnedPlatform.transform.position);
    }
}
