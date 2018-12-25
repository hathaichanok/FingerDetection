using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RewardNumberController : MonoBehaviour
{
    private Text number;

    private float moveAmt = 5f;
    private float moveSpeed = 0.5f;
    
    private Vector3 mymoveDir;

    private bool canMove = false;

    private void Start()
    {
        mymoveDir = -transform.up;
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + mymoveDir, moveAmt * (moveSpeed * Time.deltaTime));
        }
    }

    public void SetText(string text)
    {
        number = GetComponentInChildren<Text>();
        number.text = text;
        Debug.Log(text);
        canMove = true;
    }
}
