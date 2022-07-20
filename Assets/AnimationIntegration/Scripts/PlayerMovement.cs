using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 2;

    private Transform _transform;
    private Animator _animator;
    private const string POS_Z_PARAMETER = "PosZ";
    private const string POS_X_PARAMETER = "PosX";

    private void Awake()
    {
        _transform = transform;
        _animator = GetComponent<PlayerController>().animator;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 verticalDirection = Vector3.forward * verticalAxis;
        Vector3 horizontalDirection = Vector3.right * horizontalAxis;

        _transform.Translate(_movementSpeed * Time.deltaTime * (verticalDirection + horizontalDirection));
        _animator.SetFloat(POS_Z_PARAMETER, verticalAxis);
        _animator.SetFloat(POS_X_PARAMETER, horizontalAxis);
    }
}
