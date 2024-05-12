using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject cubeGameoject;
    public Transform spawnPoint;

    public void Spawncube()
    {
        Instantiate(cubeGameoject, spawnPoint.position, spawnPoint.rotation, spawnPoint);
    }
}
