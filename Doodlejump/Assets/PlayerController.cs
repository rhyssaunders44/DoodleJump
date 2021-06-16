using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Collider2D playerCollider;
    public Rigidbody2D PlayerRigid;
    public  static bool goingUp;
    public float currentY;
    public GameObject Platform;

    public delegate void OnPlayerCollisionEnter(Collision2D collision);
    public event OnPlayerCollisionEnter onPlayerCollisionEnter;

    public void Update()
    {
        TakePosition();
        SetPosition();

        if (goingUp == true)
        {
            Physics2D.IgnoreLayerCollision(0, 3, ignore:true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(0, 3, ignore:false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerRigid.AddForce(Vector2.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerRigid.AddForce(Vector2.left);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && goingUp == false)
        {
            PlayerRigid.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
        }
        onPlayerCollisionEnter.Invoke(collision);
    }

    public bool TakePosition()
    {   
        if (PlayerRigid.velocity.y > 0)
        {
            goingUp = true;
        }
        if (PlayerRigid.velocity.y <= 0)
        {
            goingUp = false;
        }
        
        return goingUp;
    }

    public void SetPosition()
    {
        currentY = PlayerRigid.position.y;
    }

}
