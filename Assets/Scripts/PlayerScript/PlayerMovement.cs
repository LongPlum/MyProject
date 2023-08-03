using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float gravity = 6f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float XOffset = 1f;
    [SerializeField] private float rollDuration = 2f;
    [SerializeField] private BoxCollider boundsCollider;
    [SerializeField] private SphereCollider playerCollider;

    private float gravityAcc;
    private float Yoffset;
    //private float inertia;
    private Sequence slideTween;
    private bool isJump;
    private KeyboardInput keyboardInput;
    private InputAction moveHorizontalAction;
    private InputAction moveVerticalAction;

    private float HalfRollDuration => rollDuration / 2;


    private void Awake()
    {
        keyboardInput = new();
        moveHorizontalAction = keyboardInput.Keyboard.MoveHorizontal;
        moveVerticalAction = keyboardInput.Keyboard.MoveVertical;
    }

    private void OnEnable()
    {
        moveHorizontalAction.Enable();
        moveVerticalAction.Enable();
    }

    private void OnDisable()
    {
        moveHorizontalAction.Disable();
        moveVerticalAction.Disable();
    }

    private void Start()
    {
        Yoffset = playerCollider.radius;
        slideTween = DOTween.Sequence()
              .Append(transform.DOScaleY(transform.localScale.y / 2, HalfRollDuration))
              .Append(transform.DOScaleY(transform.localScale.y, HalfRollDuration))
              .Insert(0, DOTween.To(a => playerCollider.radius = a, playerCollider.radius, playerCollider.radius / 2, HalfRollDuration))
              .Insert(HalfRollDuration, DOTween.To(a => playerCollider.radius = a, playerCollider.radius / 2, playerCollider.radius, HalfRollDuration))
              .Insert(0, DOTween.To(a => Yoffset = a, Yoffset, Yoffset / 2, HalfRollDuration))
              .Insert(HalfRollDuration, DOTween.To(a => Yoffset = a, Yoffset / 2, Yoffset, HalfRollDuration));

    }

    private void Update()
    {

        gravityAcc -= gravity * Time.deltaTime;

        //inertia += moveHorizontal * inertiaSpeed * Time.deltaTime;
        //inertia = Mathf.Clamp(inertia, -inertiaSpeed, inertiaSpeed);

        var dir = new Vector3(moveHorizontalAction.ReadValue<float>() * moveSpeed * Time.deltaTime, gravityAcc * Time.deltaTime, 0);
        var pos = transform.position;
        var posNext = dir + pos;
        
        bool isGrounded = Mathf.Abs(pos.y - Yoffset) < 0.001f;
        bool isUnderGrounded = pos.y - Yoffset < 0;
        bool isLeftBorder = posNext.x <= boundsCollider.bounds.min.x + XOffset;
        bool isRightBorder = posNext.x >= boundsCollider.bounds.max.x - XOffset;

        if (isRightBorder || isLeftBorder)
        {
            if (isLeftBorder)
            {
                pos = transform.position;
                pos.x = boundsCollider.bounds.min.x + XOffset;
                transform.position = pos;
            }
            else if (isRightBorder)
            {
                pos = transform.position;
                pos.x = boundsCollider.bounds.max.x - XOffset;
                transform.position = pos;
            }

            dir.x = 0;
        }


        if (isGrounded && !isJump)
        {
            dir.y = 0;
            gravityAcc = Mathf.Max(0, gravityAcc);
        }



        if (dir != Vector3.zero) 
        { 
            transform.Translate(dir);
            isJump = false;
        }

        if (isGrounded && !slideTween.IsPlaying())
        {
            if (moveVerticalAction.ReadValue<float>() < 0)
                slideTween.Restart();
            else if (moveVerticalAction.ReadValue<float>() > 0 && !isJump)
            {
                gravityAcc = jumpForce;
                isJump = true;
            }
        }

        if (isUnderGrounded)
        {
            pos = transform.position;
            pos.y = Yoffset;
            transform.position = pos;
        }


    }

}
