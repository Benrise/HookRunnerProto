using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendelum : MonoBehaviour
{
    [SerializeField]
    private float _SwingingSpeed = 1.5f;
    [SerializeField]
    private float _limitAngle = 75f;
    [SerializeField]
    private bool _randomStart = false;
    private float _random = 0;
    

    private void Awake(){
        if (_randomStart) _random = Random.Range(0f, 1f);
    }

    private void Update(){
        float angle = _limitAngle * Mathf.Sin(Time.time + _random + _SwingingSpeed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
