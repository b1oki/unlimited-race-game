using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum Direction {Stay, Up, Down, Left, Right};
    private Direction tempDirection;
    private Vector3 tempPosition;
    private Transform tempTransform;
    private float speed = 15.0f;

    private void Start()
    {
        tempDirection = Direction.Stay;
        tempPosition = transform.position;
        tempTransform = transform;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        if (horizontalMove > 0) MoveRight();
        if (horizontalMove < 0) MoveLeft();
    }

    private void MoveLeft()
    {
        // Vector3 newPosition = new Vector3(-6.4f, transform.position.y, transform.position.z);
        Vector3 newPosition = new Vector3(-4.2f, transform.position.y, transform.position.z);
        MoveToPosition(newPosition);
    }

    private void MoveRight()
    {
        // Vector3 newPosition = new Vector3(0.0f, transform.position.y, transform.position.z);
        Vector3 newPosition = new Vector3(-2.0f, transform.position.y, transform.position.z);
        MoveToPosition(newPosition);
    }

    private void MoveToPosition(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
    }
}
