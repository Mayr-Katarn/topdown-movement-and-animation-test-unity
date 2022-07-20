using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _distanceToFollowTarget;
    [SerializeField] private float _angleToFollowTarget = 75;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _transform.eulerAngles = Vector3.right * _angleToFollowTarget;
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        float x = _followTarget.position.x;
        float y = _transform.position.y;
        float z = _followTarget.position.z + _distanceToFollowTarget;

        _transform.position = new Vector3(x, y, z);
    }
}
