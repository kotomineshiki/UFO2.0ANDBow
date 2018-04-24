using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject arrow;
    public GameObject bow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            var temp=Instantiate(arrow);
            temp.transform.position = bow.transform.position;
            temp.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0.1f), ForceMode.Impulse);
        }
	}
}
