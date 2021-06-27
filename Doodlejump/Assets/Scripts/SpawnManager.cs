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

    //starting platform always counts
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

    //x value of the generated platform
    public float GenerateX()
    {
        randomX = Random.Range(-6.5f, 6.5f) + Player.transform.position.x;
        return randomX;
    }

    //y value of the generate platform
    public float GenerateY()
    {
        randomY = Random.Range(2, 6) + Player.transform.position.y;
        return randomY;
    }

    //spawns the platform
    public void SpawnPlatform()
    {
        Instantiate(Platform, new Vector2(GenerateX(), GenerateY()), Quaternion.identity);
    }

    //adds score when the player collides with a platform.
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
