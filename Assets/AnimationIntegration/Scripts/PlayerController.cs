using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private GameObject _rangeWeapon;
    [SerializeField] private GameObject _meleeWeapon;

    private Transform _transform;
    private PlayerMovement _playerMovement;
    private PlayerAiming _playerAiming;
    private Enemy _enemyToFinish;
    private const float DISTANCE_TO_EMENY_FINISHING = 1.7f;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAiming = GetComponent<PlayerAiming>();
        _transform = transform;
    }

    private void OnEnable()
    {
        EventManager.OnFinishAnimationHitEnemy.AddListener(OnFinishEnemyHit);
        EventManager.OnFinishAnimationEnd.AddListener(OnFinishEnemyEnd);
    }

    private void Update()
    {
        FinishEnemyStart();
    }

    public void SetEnemyToFinish(Enemy enemy)
    {
        _enemyToFinish = enemy;
    }

    private void FinishEnemyStart()
    {
        if (_enemyToFinish != null && _enemyToFinish.isAlive && Input.GetButtonUp("FinishEnemy"))
        {
            _enemyToFinish.DisableCollider();
            _enemyToFinish.isAlive = false;
            _playerMovement.enabled = false;
            _playerAiming.enabled = false;
            SwichToMeleeWeapon();
            TurnToEnemy();
            animator.SetBool("IsFinising", true);
            animator.SetLayerWeight(1, 0);
            EventManager.SendShowUiMessage(UiMessageType.None);
        }
    }

    public void OnFinishEnemyHit()
    {
        _enemyToFinish.GetFinished();
    }

    public void OnFinishEnemyEnd()
    {
        _playerMovement.enabled = true;
        _playerAiming.enabled = true;
        animator.SetBool("IsFinising", false);
        animator.SetLayerWeight(1, 100);
        _transform.forward = Vector3.forward;
        SwichToRangeWeapon();
    }

    private void TurnToEnemy()
    {
        Vector3 direction = _enemyToFinish.transform.position - _transform.position;
        direction.Normalize();
        _transform.forward = direction;
        _transform.position = _enemyToFinish.transform.position + -direction * DISTANCE_TO_EMENY_FINISHING;
    }

    private void SwichToMeleeWeapon()
    {
        _rangeWeapon.SetActive(false);
        _meleeWeapon.SetActive(true);
    }

    private void SwichToRangeWeapon()
    {
        _rangeWeapon.SetActive(true);
        _meleeWeapon.SetActive(false);
    }
}
