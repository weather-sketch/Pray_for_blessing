using System.Collections;
using UnityEngine;

public class backgroundLightsSpawner : MonoBehaviour
{
    public GameObject lanternPrefab; 
    public float spawnInterval = 3f; 
    public float minHeight = 10f; 
    public float maxHeight = 100f; 
    public float minWind = -2f; 
    public float maxWind = 2f;
    public Vector2 spawnRangeX; 
    public Vector2 spawnRangeZ; 

    private void Start()
    {
        StartCoroutine(SpawnLanterns());
    }

    private IEnumerator SpawnLanterns()
    {
        while (true)
        {
            SpawnLantern();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnLantern()
    {

        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomZ = Random.Range(spawnRangeZ.x, spawnRangeZ.y);
        float randomHeight = Random.Range(minHeight, maxHeight);

  
        GameObject newLantern = Instantiate(lanternPrefab, new Vector3(randomX, randomHeight, randomZ), Quaternion.identity);


        float windX = Random.Range(minWind, maxWind);
        float windZ = Random.Range(minWind, maxWind);
        Vector3 windForce = new Vector3(windX, 0, windZ);


        Rigidbody rb = newLantern.AddComponent<Rigidbody>();
        rb.isKinematic = true; 


        StartCoroutine(LanternRise(rb, windForce));
    }

    private IEnumerator LanternRise(Rigidbody lanternRb, Vector3 windForce)
    {
        while (lanternRb.transform.position.y < maxHeight)
        {

            lanternRb.transform.position += Vector3.up * Time.deltaTime;

            lanternRb.transform.position += windForce * Time.deltaTime;
            yield return null;
        }


        Destroy(lanternRb.gameObject);
    }
}