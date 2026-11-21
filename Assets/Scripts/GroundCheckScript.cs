using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    public MovementScript player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == player.groundLayer)
        {
            player.isGrounded = true;
            player.ResetGravity();
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == player.groundLayer)
        {
            player.isGrounded = true;
            player.jumpingPower = 7;
            player.ResetGravity();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        player.isGrounded = false;
    }
}
