using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    public Transform target;
    public float dist = 1;
    public float height = 1;
    public float dampTrace = 10;

    private Transform Tr;

    void Start()
    {
        Tr = GetComponent<Transform>();
    }

	
	// Update is called once per frame
	void LateUpdate ()
    {
        Tr.position = Vector3.Lerp(Tr.position, (target.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);

        Tr.LookAt(target.position);
    
	}
}
