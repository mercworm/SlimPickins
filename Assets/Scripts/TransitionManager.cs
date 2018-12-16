using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour {

    public static TransitionManager transMan;

    private void Awake()
    {
        if(transMan == null)
        {
            DontDestroyOnLoad(gameObject);
            transMan = this;
            
        }
        else if(transMan != this)
        {
            Destroy(gameObject);
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
