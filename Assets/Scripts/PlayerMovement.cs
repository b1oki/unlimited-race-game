using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int lastHorizontaMovelDirectionIsLeft = 0;
    private int lastVerticalMovelDirectionIsUp = 0;

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
    }

    public void MoveLeft()
    {

    }

    public void MoveRight()
    {

    }
}
