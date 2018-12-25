using UnityEngine;

public class Balloon : MonoBehaviour
{
    public static int SIZE = 4;

    public GameObject balloon;

    public int balloonNumber = 10;
    public bool randomBalloon;

    public int numCol;
    public int numRow;

    private float MinX = -22f;
    private float MaxX = 22f;
    private float MinMaxY = 13.3f;
    private float MinZ = 3f;
    private float MaxZ = 26f;

    // Use this for initialization
    void Start()
    {
        LoadBalloon();
    }

    void LoadBalloon()
    {
        if (randomBalloon == false)
        {
            Spawn();
        }
        else
        {
            RandomSpawn();
        }
    }

    void RandomSpawn()
    {
        Vector3 spawnPos;

        for (int i = 1; i <= balloonNumber; i++)
        {
            spawnPos = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinMaxY, MinMaxY), Random.Range(MinZ, MaxZ));
            GameObject clone = (GameObject)Instantiate(balloon, spawnPos, Quaternion.identity);
            clone.name = "Balloon";
        }
    }

    void Spawn()
    {
        Vector3 spawnPos;
        float spaceBetweenBalloon = 5f;
        float makeToCenter = spaceBetweenBalloon * 3;

        for (int row = 1; row <= numRow; row++)
        {
            for (int col = 1; col <= numCol; col++)
            {
                spawnPos = new Vector3((col * spaceBetweenBalloon) - makeToCenter, 13.3f, (row * spaceBetweenBalloon) + (makeToCenter / 2));
                GameObject clone = (GameObject)Instantiate(balloon, spawnPos, Quaternion.identity);
                clone.name = "Balloon";
            }
        }
    }
}
