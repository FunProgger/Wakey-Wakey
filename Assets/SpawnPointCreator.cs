using UnityEngine;

public class SpawnPointCreator : MonoBehaviour
{
    public GameObject objectPrefab;
    public int num_spawnPoints = 10;
    public Vector3 spawnArea = new Vector3(15, 15, 15);
    public float spawnHeight = 10f;
    public Vector3 spawnCenter = new Vector3(0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    for (int i = 0; i < num_spawnPoints; i++)
    //    {
    //        spawnObject();
    //    }
    //}
    void spawnObject()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnCenter.x - spawnArea.x / 2, spawnCenter.x + spawnArea.x / 2),
            spawnHeight,
            Random.Range(spawnCenter.z - spawnArea.z / 2, spawnCenter.z + spawnArea.z / 2)
            );
        GameObject spawnedObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
        spawnedObject.GetComponent<Renderer>().enabled = true;
        Debug.Log($"Spawned object {spawnedObject.name} at {spawnPos}");

        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.mass = Random.Range(0.5f, 2.0f);
        }
    }

    public void setupSpawnArea()
    {
        for (int i = 0; i < num_spawnPoints; i++)
        {
            spawnObject();
        }
    }
}