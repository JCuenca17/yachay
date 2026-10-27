using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterSpawn : MonoBehaviour
{
    public Transform letterspawn;
    public GameObject[] letters;
    public float minPosX, maxPosX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("letterFall", 1f, 2f);
    }

    void letterFall()
    {
        if (!GameManager.instance.isGameActive)
        {
            return;
        }

        int randomLetter = Random.Range(0, letters.Length);
        float randomPos = Random.Range(minPosX, maxPosX);
        Vector3 randomVectorPos = new Vector3(randomPos, transform.position.y, transform.position.z);
        GameObject fallingLetter = Instantiate(letters[randomLetter], randomVectorPos, Quaternion.identity);

        // Asignar el letterValue a la letra caída
        LetterIdentifier letterIdentifier = fallingLetter.GetComponent<LetterIdentifier>();
        if (letterIdentifier != null)
        {
            letterIdentifier.letterValue = letters[randomLetter].name;  // Asumiendo que el valor es el nombre del prefab
        }
    }
}
