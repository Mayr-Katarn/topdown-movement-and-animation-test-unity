using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Transform _transform;
    private SphereCollider _sphereCollider;
    private const int RESPAWN_TIME = 5;
    public bool isAlive = true;

    private void Awake()
    {
        _transform = transform;
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.SetEnemyToFinish(this);
            EventManager.SendShowUiMessage(UiMessageType.FinishEnemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.SetEnemyToFinish(null);
            EventManager.SendShowUiMessage(UiMessageType.None);
        }
    }

    public void DisableCollider()
    {
        _sphereCollider.enabled = false;
    }

    public void GetFinished()
    {
        _animator.enabled = false;
        StartCoroutine(RespawnEnemy());
    }

    private IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(RESPAWN_TIME);
        ResetState();
    }

    private void ResetState()
    {
        isAlive = true;
        _animator.enabled = true;
        _sphereCollider.enabled = true;
        _transform.position = new Vector3(Random.Range(0, 10f), 0, Random.Range(0, 10f));
    }
}
