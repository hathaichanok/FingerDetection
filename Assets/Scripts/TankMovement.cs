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

    public static Vector3 markerPos;

    public Text currentAmmoText;

    public Text markerPosText;
    public Text tankPosText;

    GameObject AmmoPanel;
    public GameObject marker;

    public bool GameMode = false;

    private float speed = 10f;
    private float x_pos = 0f;
    private float z_pos = 5f;
    private float y_pos = -13f;

    public AudioClip shootSound;

    void Start()
    {
        AmmoPanel = GameObject.FindGameObjectWithTag("AmmoPanel");
        currentAmmo = maxAmmo;

        markerPos = new Vector3(0, 0, 0);
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
            AmmoPanel.SetActive(true);
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

        ////////////////////////////////////////////////
        markerPos = marker.transform.position;
        if((markerPos.x - 100) > 24.3)
        {
            x_pos = (float)24.3;
            //transform.position = new Vector3((float)24.3, transform.position.y, (float)(markerPos.z));
        }
        else if((markerPos.x - 100) < -24.3)
        {
            x_pos = (float)-24.3;
            //transform.position = new Vector3((float)-24.3, transform.position.y, (float)(markerPos.z));
        }
        else
        {
            x_pos = (markerPos.x - 100);
            //transform.position = new Vector3(markerPos.x - 100, transform.position.y, (float)(markerPos.z));
        }

        if(markerPos.z > 28)
        {
            z_pos = 28f;
        }
        else if(markerPos.z < 5)
        {
            z_pos = 5f;
        }
        else
        {
            z_pos = markerPos.z;
        }

        if(markerPos.y - 13 < -13)
        {
            y_pos = (float)-13;
        }
        else
        {
            y_pos = (float)markerPos.y - 13;
        }

        transform.position = new Vector3(x_pos, y_pos, z_pos);
        markerPosText.text = markerPos.ToString();
        tankPosText.text = transform.position.ToString();
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
