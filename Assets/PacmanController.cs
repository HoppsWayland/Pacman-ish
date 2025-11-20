using UnityEngine;
using UnityEngine.InputSystem;

public class PacmanController : MonoBehaviour
{
    public float speed;
    internal InputAction moveAction;
    internal Rigidbody2D rb;
    internal Vector2 direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("move");
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, 0);
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
            // 1. Calculate the angle in radians using Atan2
            float angleRad = Mathf.Atan2(direction.y, direction.x);

            // 2. Convert radians to degrees
            float angleDeg = angleRad * Mathf.Rad2Deg;

            // 3. Apply the rotation to the GameObject's transform.
            // Note: We use -90 because in a standard Unity 2D sprite setup,
            // the sprite's "forward" (0 rotation) is often pointing right, 
            // and we want it to point up when moving along the positive y-axis 
            // or right along the positive x-axis. Pac-Man usually starts facing right.
            transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        }
        
    }
}