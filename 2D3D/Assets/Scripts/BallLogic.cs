﻿using UnityEngine;
using System.Collections;

public class BallLogic : MonoBehaviour {

    Rigidbody _rb;
    Collider _collider;
    SpriteRenderer _spr;

	// Use this for initialization
	void Start () {
        _rb = transform.parent.GetComponent<Rigidbody>();
        _spr = GetComponent<SpriteRenderer>();
        _collider = transform.parent.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float spinVelocity = _rb.angularVelocity.z;

        //Debug.Log(spinVelocity);
        float curZ = transform.rotation.z;
        curZ += (Time.fixedDeltaTime * spinVelocity * 4f);
        //transform.rotation.SetFromToRotation(transform.rotation.eulerAngles, new Vector3(0, 0, curZ));
        transform.Rotate(Vector3.forward * spinVelocity);
        //Debug.Log(transform.rotation.z);
	}

    public void Lock(bool doLock)
    {
        Debug.Log("Ball:Lock(" + doLock + ")");
        _rb.isKinematic = doLock;
        _collider.enabled = !doLock;
        this.enabled = !doLock;
        _spr.sortingOrder = doLock ? 2 : 0;
    }
    
    public void Throw(Vector3 _direction)
    {
        Debug.Log(_direction);
        Vector3 throwjectory = (new Vector3(0f,0.4f,0f) + _direction).normalized;
        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;
        _rb.AddForce(throwjectory * 5f, ForceMode.Impulse);
        //_rb.AddForce(,ForceMode.Force);
    }
    
}
