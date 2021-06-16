using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public GameObject Player;

    public void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.y <= Player.transform.position.y - 10)
        {
            Destroy(this.gameObject);
        }
    }
}
