using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 20f;
    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }
}
