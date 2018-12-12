using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Bullet_Emitter;
    private float bulletSpeed = 1000f;

    private float speed = 10f;

    public AudioClip shootSound;

    void Update () {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            //Debug.Log("Forward");
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.Self);
            //Debug.Log("Backward");
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
            //Debug.Log("Left");
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
            //Debug.Log("Right");
        }

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(shootSound,1f);

        GameObject tempBullet = Instantiate(Bullet, Bullet_Emitter.position, Bullet_Emitter.rotation) as GameObject;

        Rigidbody tempRB = tempBullet.GetComponent<Rigidbody>();

        tempRB.AddForce(transform.up * bulletSpeed);

        Destroy(tempBullet, 3.0f);
    }
}
