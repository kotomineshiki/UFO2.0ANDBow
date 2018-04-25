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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var temp=Instantiate(arrow);
            temp.transform.position = bow.transform.position;
            temp.transform.LookAt(ray.GetPoint(20));
            Debug.Log(ray.direction);
            temp.GetComponent<Rigidbody>().AddForce(ray.direction*4, ForceMode.Impulse);
        }
	}
}
