using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SOPlayer playerData { get; private set; }

    private Rigidbody2D rb;

    Vector2 movement;
    float _speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _speed = playerData.Speed;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * _speed * Time.fixedDeltaTime);
    }

}
