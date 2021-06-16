using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerController;
    public GameObject Platform;

    int platformNumber;
    public float newPlatform;
    float randomX;
    float randomY;

    public void Start()
    {
        newPlatform = Player.transform.position.y - 10;
    }

    private void OnEnable()
    {
        playerController = Player.GetComponent<PlayerController>();
        playerController.onPlayerCollisionEnter += example;
    }

    private void OnDisable()
    {
        playerController.onPlayerCollisionEnter -= example;
    }

    public float GenerateX()
    {
        randomX = Random.Range(-6.5f, 6.5f) + Player.transform.position.x;
        return randomX;
    }

    public float GenerateY()
    {
        randomY = Random.Range(2, 6) + Player.transform.position.y;
        return randomY;
    }

    public void SpawnPlatform(int spawnPlatform)
    {
        Instantiate(Platform, new Vector2(GenerateX(), GenerateY()), Quaternion.identity); 
    }

    public void example(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && newPlatform != Player.transform.position.y)
        {
            platformNumber = Random.Range(1, 3);
            SpawnPlatform(platformNumber);
            newPlatform = Player.transform.position.y;
        }
    }

}
