using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float playerMoveSpeed = 8f;
    [SerializeField]
    float maxX;

    float moveX;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameActive)
        {
            return;
        }
        movePlayer();
    }

    void movePlayer()
    {
        moveX = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
        transform.position += new Vector3(moveX, 0, 0);
        float maxPos = Mathf.Clamp(transform.position.x, -maxX, maxX);
        transform.position = new Vector3(maxPos, transform.position.y, transform.position.z);
    }
}
