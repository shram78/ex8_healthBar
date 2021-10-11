using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded;
    private const string _isRunning = "isRunning";
    private const string _isJumping = "isJumping";
    private const string _horizontal = "Horizontal";
    private Vector3 _directionMove;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(_isRunning, false);

        if (Input.GetButton(_horizontal))
            Move();

        if (_isGrounded && Input.GetKey(KeyCode.Space))
            Jump();

        if (_isGrounded == false)
            _animator.SetBool(_isJumping, true);
        
        else
            _animator.SetBool(_isJumping, false);
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _groundLayer);
    }

    private void Move()
    {
        _animator.SetBool(_isRunning, true);

        _directionMove = transform.right * Input.GetAxis(_horizontal);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _directionMove, _speed * Time.deltaTime);

        _spriteRenderer.flipX = _directionMove.x < 0;
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
        _jumpSound.Play();
    }
}