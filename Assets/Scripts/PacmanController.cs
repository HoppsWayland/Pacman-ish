using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PacmanController : MonoBehaviour
{
    public float speed;
    internal InputAction moveAction;
    internal Rigidbody2D rb;
    internal Vector2 direction;
    private bool hasPowerPellet = false;
    private SpriteRenderer renderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("move");
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, 0);
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        if (move.magnitude > 0)
            direction = move;
        rb.linearVelocity = (direction*speed);
        direction.Normalize();
        if (direction.magnitude > 0)
        {
            float angleRad = Mathf.Atan2(direction.y, direction.x);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        }

        if (hasPowerPellet)
        {
            renderer.color = Color.orange;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerPellet")
        {
            Destroy(other.gameObject);
            hasPowerPellet = true;
            Invoke("noPowerPellet", 8f);
        }else if (other.tag == "Ghost")
        {
            if (hasPowerPellet)
            {
                Destroy(other.gameObject);
            }
            else
            {
                transform.position = new Vector2(-.4f, -3.4f);
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    private void noPowerPellet()
    {
        hasPowerPellet = false;
        renderer.color = Color.white;
    }
}