using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, 0);
    }
}
