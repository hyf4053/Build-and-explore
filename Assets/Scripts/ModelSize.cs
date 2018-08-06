using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSize : MonoBehaviour {

	public Mesh modelMesh;
	// Use this for initialization
	void Start () {
		Vector3 center = modelMesh.bounds.center;
		Vector3 i = modelMesh.bounds.extents;
		//Debug.Log(i);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
