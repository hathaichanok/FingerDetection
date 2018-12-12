using UnityEngine;
using System.Collections;

public class randomColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
       GetComponent<Renderer>().material.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
