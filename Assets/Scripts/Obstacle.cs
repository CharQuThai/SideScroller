using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float speed = 25f;
    private float xBoundary = -20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        if (transform.position.x < xBoundary)
        {
            Destroy(this.gameObject);
        }


    }
}
