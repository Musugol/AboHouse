﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera FpsCamera;
    public Camera TpsCamera;
    bool fpsCamera = true;
	bool iDown;

	GameObject nearObject;
	Animator anim;

    // 스피드 조정 변수
    private float walkSpeed = 12;
    private float jumpForce = 5;

    private float applySpeed;

    // 상태 변수
    private bool isGround = true;

    // 땅 착지 여부
    private CapsuleCollider capsuleCollider;

    // 움직임 체크 변수
    private Vector3 lastPos;

    // 민감도
    [SerializeField]
    private float lookSensitivity;


    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;


    //필요한 컴포넌트
    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;
    private StatusController theStatusController;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}
	// Use this for initialization
	void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        theStatusController = FindObjectOfType<StatusController>();

        FpsCamera.enabled = fpsCamera;
        TpsCamera.enabled = !fpsCamera;
    }

    void Update()
    {
		IsGround();
        TryJump();
        Move();
        if (!Inventory.inventoryActivated)
        {
            CameraRotation();
            CharacterRotation();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            fpsCamera = !fpsCamera;
            FpsCamera.enabled = fpsCamera;
            TpsCamera.enabled = !fpsCamera;
        }
		anim.SetBool("isWalk", Input.GetKey(KeyCode.W));
        anim.SetBool("isJump", Input.GetKey(KeyCode.Space));
        anim.SetBool("isAttack", Input.GetMouseButtonDown(0));
	}

    // 지면 체크.
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y);
    }


    // 점프 시도
    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }


    // 점프
    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce;
    }

    // 움직임 실행
    private void Move()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    // 좌우 캐릭터 회전
    private void CharacterRotation()
    {

        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }



    // 상하 카메라 회전
    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
}