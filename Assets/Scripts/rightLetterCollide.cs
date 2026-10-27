using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightLetterCollide : MonoBehaviour
{
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en el objeto.");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!GameManager.instance.isGameActive)
        {
            return;
        }
        // Asegúrate de que la letra caída tenga un componente LetterIdentifier
        LetterIdentifier fallingLetter = col.gameObject.GetComponent<LetterIdentifier>();

        if (fallingLetter != null)
        {
            // Obtener el valor de la letra de referencia (de la letra actual en referencia)
            string referenceLetterValue = referenceLetterSpawn.currentReferencePrefab.GetComponent<LetterIdentifier>().letterValue;

            // Comparar los valores de letterValue de la referencia y la letra que cae
            if (fallingLetter.letterValue == referenceLetterValue)
            {
                // Si coinciden, sumar puntos
                GameManager.instance.scoreIsUp();
                PlaySound(correctSound);
            }
            else
            {
                // Si no coinciden, restar vida
                GameManager.instance.lifeDecrease();
                PlaySound(wrongSound);
            }

            // Destruir la letra que cayó después de la comparación
            Destroy(col.gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
