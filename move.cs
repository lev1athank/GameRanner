using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 movePlayer = Vector3.zero;
    Rigidbody rb;
    [SerializeField] float Speed = 1;
    [SerializeField] float SwipeSpeed = 0.25f;

    public Color renderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = Color.red;
    }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (movePlayer.x - 1.5f >= -1.5f)
                movePlayer.x -= 1.5f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (movePlayer.x + 1.5f <= 1.5f)
                movePlayer.x += 1.5f;
        }

        


    }

    private void FixedUpdate()
    {
        float a = Vector3.Lerp(transform.position, movePlayer, SwipeSpeed).x;
        transform.position = new Vector3(a, 0, Speed * 0.05f + transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.GetComponent<Renderer>().material.color == renderer)
        {
            Destroy(other.gameObject);
        }
    }

}
