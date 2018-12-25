using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankMovement : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Bullet_Emitter;
    public float bulletSpeed = 2000f;
    public int maxAmmo = 10;
    private int currentAmmo;

    public Text currentAmmoText;

    GameObject AmmoPanel;

    public bool GameMode = false;

    private float speed = 10f;

    public AudioClip shootSound;

    void Start()
    {
        AmmoPanel = GameObject.FindGameObjectWithTag("AmmoPanel");
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (GameMode == true)
        {
            AmmoPanel.SetActive(true);
            currentAmmoText.text = currentAmmo.ToString();
        }
        else
        {
            AmmoPanel.SetActive(false);
        }

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
            if (GameMode == false)
            {
                Shoot();
            }
            else
            {
                if (currentAmmo > 0)
                {
                    currentAmmo--;
                    Shoot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GameMode = !GameMode;
            currentAmmo = maxAmmo;
        }
    }

    void Shoot()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(shootSound, 1f);

        GameObject tempBullet = Instantiate(Bullet, Bullet_Emitter.position, Bullet_Emitter.rotation) as GameObject;

        Rigidbody tempRB = tempBullet.GetComponent<Rigidbody>();

        tempRB.AddForce(transform.up * bulletSpeed);

        Destroy(tempBullet, 3.0f);
    }
}
