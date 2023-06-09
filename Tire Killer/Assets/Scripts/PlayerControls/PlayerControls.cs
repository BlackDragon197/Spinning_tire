using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private PlayerInputHandler _playerInputs;
    private CharacterController _characterController;

    private float _currentSpeed = 0;
    private float _currentRotation = 0;
    private float _currentAngle = 0;
    private float _velocity;
    private float _gravity = -9.81f;
    private Vector3 _gravityVector;

    [SerializeField]
    private PlayerData _playerData;
    private void Awake()
    {
        _playerInputs = GetComponent<PlayerInputHandler>();
        _characterController = GetComponent<CharacterController>();

        _velocity = _gravity * Time.deltaTime;
        _gravityVector = new Vector3(0, _velocity, 0);
    }

    private void Start()
    {
        _currentSpeed = _playerData.PermanentSpeed;
    }

    private void Update()
    {
        Gravity();

        if (_playerInputs.MoveInput.x > 0 && _currentAngle > -_playerData.WheelAngle)
        {
            _currentAngle += -_playerInputs.MoveInput.x * _playerData.RotationUnit;
        }
        else if (_playerInputs.MoveInput.x < 0 && _currentAngle < _playerData.WheelAngle)
        {
            _currentAngle += -_playerInputs.MoveInput.x * _playerData.RotationUnit;
        }

        if (_playerInputs.MoveInput.y > 0)
        {
            _currentSpeed += _playerInputs.MoveInput.y * 0.01f;
        }
        else if (_playerInputs.MoveInput.y < 0 && _currentSpeed > _playerData.PermanentSpeed)
        {
            _currentSpeed += _playerInputs.MoveInput.y * 0.01f;
        }

        Vector3 moveDirection = new Vector3(_currentSpeed, 0, _currentAngle * 0.1f);
          _characterController.Move(moveDirection * _playerData.Speed * Time.deltaTime);
   
        _currentRotation += _characterController.velocity.x + _characterController.velocity.y;
        transform.localRotation = Quaternion.Euler(0, -_currentAngle, -_currentRotation);
    }

    private void Gravity()
    {
        _characterController.Move(_gravityVector);
    }
}
