using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    [SerializeField]
    private PlayerData _playerData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameStateManager.Instance.ChangeState(GameStateManager.GameStates.DEATH);
        }

        if (other.CompareTag("Finish"))
        {
            GameStateManager.Instance.ChangeState(GameStateManager.GameStates.END);
        }

        if (other.CompareTag("SpeedBoostCharge"))
        {
            _playerData.CanSpeedBoost = true;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("DestroyCharge"))
        {
            _playerData.CanDestroy = true;
            other.gameObject.SetActive(false);
        }
    }
 }
