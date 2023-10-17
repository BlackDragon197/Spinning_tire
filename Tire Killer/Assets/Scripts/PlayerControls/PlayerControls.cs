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

    private bool _canBeUsed = true;

    [SerializeField]
    private PlayerData _playerData;
    private void Awake()
    {
        _playerInputs = GetComponent<PlayerInputHandler>();
        _characterController = GetComponent<CharacterController>();

        _velocity = _gravity * Time.fixedDeltaTime;
        _gravityVector = new Vector3(0, _velocity, 0);
    }

    private void Start()
    {
        _currentSpeed = _playerData.PermanentSpeed;
        AdManager.Instance.LoadRewardedAd();
        AdManager.Instance.LoadInterstitialAd();
    }

    private void Update()
    {
        Gravity();
        if (GameStateManager.Instance.state == GameStateManager.GameStates.INGAME)
        {
            if (_playerInputs.MoveYInput.x > 0 && _currentAngle > -_playerData.WheelAngle)
            {
                _currentAngle += -_playerInputs.MoveYInput.x * _playerData.RotationUnit;
            }
            else if (_playerInputs.MoveYInput.x < 0 && _currentAngle < _playerData.WheelAngle)
            {
                _currentAngle += -_playerInputs.MoveYInput.x * _playerData.RotationUnit;
            }
        }

        if (_playerInputs.MoveXInput.y > 0)
        {
            _currentSpeed += _playerInputs.MoveXInput.y * 0.01f;
        }
        else if (_playerInputs.MoveXInput.y < 0 && _currentSpeed > _playerData.PermanentSpeed)
        {
            _currentSpeed += _playerInputs.MoveXInput.y * 0.01f;
        }

        if (_playerInputs.SpeedBoostActivate && _canBeUsed && _playerData.CanSpeedBoost)
        {
            BoostSpeed();
            _playerData.CanSpeedBoost = false;
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

    public void BoostSpeed()
    {
        _currentSpeed += _playerData.BoostSpeed;
        _canBeUsed = false;
        StartCoroutine(BoostTimeout(new WaitForSeconds(1f)));
    }

    private IEnumerator BoostTimeout(WaitForSeconds seconds)
    {
        yield return seconds;
        _canBeUsed = true;
        _currentSpeed -= _playerData.BoostSpeed;
    }
}
