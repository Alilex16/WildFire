using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMain : MonoBehaviour {

    public GameObject longestRunTime;
    
	void Update ()
    {
        var timer = longestRunTime.GetComponent<Text>().ToString();



    }
}
