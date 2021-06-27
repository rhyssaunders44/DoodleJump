using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Collider2D playerCollider;
    public Rigidbody2D PlayerRigid;
    public  static bool goingUp;
    public static float currentY;
    public GameObject Platform;
    [SerializeField] private GameObject deathfloor;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float yPos;

    [SerializeField] private bool dead;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    public static bool paused;


    public void Update()
    {
        TakePosition();
        SetPosition();

        if (goingUp)
        {
            Physics2D.IgnoreLayerCollision(0, 3, ignore:true);
            yPos = currentY - 10;
        }
        
        if(!goingUp)
        {
            Physics2D.IgnoreLayerCollision(0, 3, ignore: false);
            yPos = deathfloor.transform.position.y;
        }

        if (!dead)
        {
            deathfloor.transform.position = new Vector3(playerCollider.transform.position.x, yPos);
            mainCamera.transform.position = new Vector3(playerCollider.transform.position.x, playerCollider.transform.position.y, -10);
        }
    }

    //if not paused move the character
    private void FixedUpdate()
    {
        if (!paused)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Move(Vector2.right, true);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector2.left, false);
            }
        }
    }

    //add force in the desired direction and flip the sprite.
    private void Move(Vector2 moveDirection , bool flip)
    {
        PlayerRigid.AddForce(moveDirection * 10, ForceMode2D.Force);
        SpriteRenderer.flipX = flip;
    }

    //deals with jumping and killing the player
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && !goingUp)
        {
            PlayerRigid.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
            SpawnManager.collision = true;
        }

        if (collision.gameObject.tag == "DED")
        {
            UiManager.dead = true;
        }
    }

    //lets the game know if the player is going up
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
