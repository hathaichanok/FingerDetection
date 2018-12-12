using UnityEngine;

public class Balloon : MonoBehaviour {

    public GameObject balloon;
    public int balloonNumber = 10;
    public bool randomBalloon;

    // Use this for initialization
    void Start()
    {
        if (randomBalloon == false)
        {
            RandomSpawn();
        }
        else
        {

        }
    }

    void RandomSpawn()
    {
        Vector3 spawnPos;
        
        for (int i = 1; i <= balloonNumber; i++)
        {
            spawnPos = new Vector3(Random.Range(-24, 24), Random.Range(13.3f, 13.3f), Random.Range(3, 27));
            GameObject clone = (GameObject)Instantiate(balloon, spawnPos, Quaternion.identity);
            clone.name = "Balloon";
        }
    }
}
