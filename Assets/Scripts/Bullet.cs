﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public AudioClip balloonPopSound;

    public AudioClip bulletHitSound;

    public GameObject bulletHitBalloonEffect;

    public GameObject bulletHitWallEffect;

    public GameObject RewardNumberprefab;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.gameObject.tag == "Balloon")
        {
            AudioSource.PlayClipAtPoint(balloonPopSound, transform.position);

            InitializeRewardNumber();

            GameObject effectIns = (GameObject)Instantiate(bulletHitBalloonEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);

            Debug.Log(collision.transform.name + "Hit");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(bulletHitSound, transform.position, 0.1f);
            GameObject effectIns = (GameObject)Instantiate(bulletHitWallEffect, transform.position, transform.rotation);
            Destroy(effectIns, 1f);

            Debug.Log(collision.transform.name + "Hit");
            Destroy(gameObject);
        }
    }

    void InitializeRewardNumber()
    {
        GameObject temp = (GameObject)Instantiate(RewardNumberprefab, transform.position, Quaternion.identity);
        temp.SetActive(true);
        temp.GetComponent<RewardNumberController>().SetText(Random.Range(0, 10).ToString());
        Destroy(temp.gameObject, 4f);
    }
}
