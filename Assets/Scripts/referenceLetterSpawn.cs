using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class referenceLetterSpawn : MonoBehaviour
{
    public List<GameObject> letterPrefabs;
    public Transform spawnPoint;
    public static GameObject currentReferencePrefab;

    public float changeInterval = 20f;
    private float timer;

    void Start()
    {
        if (letterPrefabs.Count > 0 && spawnPoint != null)
        {
            SpawnLetter(Random.Range(0, letterPrefabs.Count));
        }
    }

    void Update()
    {
        if (letterPrefabs.Count > 1)
        {
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {
                timer = 0f;
                ChangeLetter();
            }
        }
    }

    void SpawnLetter(int index)
    {
        if (currentReferencePrefab != null)
        {
            Destroy(currentReferencePrefab);
        }

        currentReferencePrefab = Instantiate(letterPrefabs[index], spawnPoint.position, spawnPoint.rotation);
    }

    void ChangeLetter()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, letterPrefabs.Count);
        } while (currentReferencePrefab != null && letterPrefabs[randomIndex] == currentReferencePrefab);

        SpawnLetter(randomIndex);
    }
}
