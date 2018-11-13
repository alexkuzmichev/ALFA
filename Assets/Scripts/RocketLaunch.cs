using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOMove(new Vector3(2, 2, 2), 2)
   .SetEase(Ease.OutQuint)
   .SetLoops(4);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
