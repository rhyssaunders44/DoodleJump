using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        //destroys the platform if its too far from the player
        if (transform.position.y <= PlayerController.currentY - 10)
        {
            Destroy(this.gameObject);
        }
    }
}
