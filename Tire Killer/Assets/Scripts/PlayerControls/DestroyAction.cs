using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    private List<GameObject> _obstacles = new List<GameObject>();

    private void OnEnable()
    {
        PlayerInputHandler.OnDestroyObstacles += DestroyObstacles;
    }

    private void OnDisable()
    {
        PlayerInputHandler.OnDestroyObstacles -= DestroyObstacles;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _obstacles.Add(other.gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _obstacles.Remove(other.gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

    private void DestroyObstacles()
    {
        foreach(GameObject obstacle in _obstacles)
        {
            obstacle.SetActive(false);
        }
    }
   
}
