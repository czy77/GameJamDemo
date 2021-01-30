using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 100f;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _collider2D;
    private Vector3 rotateVec;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Speed * Time.fixedDeltaTime  * rotateVec;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("DeadLine"))
        {
            Destroy(this.gameObject);
        }
    }

    public void SetRotate(Vector3 vec)
    {
        this.rotateVec = vec;
    }

}
