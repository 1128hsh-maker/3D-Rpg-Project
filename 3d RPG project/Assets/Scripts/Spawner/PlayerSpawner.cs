using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform resetPoint;
    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Player.instance.transform.position = resetPoint.transform.position;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            EnemySpawner.Instance.SpawnEnemy();
            if (rb)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
    }
}
