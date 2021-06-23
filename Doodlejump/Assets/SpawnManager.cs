using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Platform;
    public float newPlatformPos;
    public static bool collision;
    float randomX;
    float randomY;

    private void Start()
    {
        newPlatformPos = Player.transform.position.y - 10;
    }

    private void Update()
    {
        if (collision)
        {
            Collide();
        }
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

    public void SpawnPlatform()
    {
        Instantiate(Platform, new Vector2(GenerateX(), GenerateY()), Quaternion.identity);
    }

    public void Collide()
    {
        if (Mathf.Abs(newPlatformPos - Player.transform.position.y) > 2)
        {
            UiManager.Score++;
            SpawnPlatform();
            newPlatformPos = Player.transform.position.y;

        }
        collision = false;
    }

}
