using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

    public int xRes;
    public int yRes;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(xRes, yRes, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
