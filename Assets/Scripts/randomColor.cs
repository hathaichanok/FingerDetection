using UnityEngine;
using System.Collections;

public class randomColor : MonoBehaviour {
    
	void Start () {
       GetComponent<Renderer>().material.color = Color.red;
    }
}
