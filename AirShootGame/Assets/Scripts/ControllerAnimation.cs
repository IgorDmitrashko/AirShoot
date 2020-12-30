using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAnimation : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private Animator _playerAnimator;
    private Animator _enemyAnimator;

    private void Awake() {
        _playerAnimator = _player.GetComponent<Animator>();
        _enemyAnimator = _enemy.GetComponent<Animator>();
    }
    void Start() {
        _player.Shot += PlayerHitAnimation;
        _enemy.Rejoice += EnemyRejoiceAnimation;
    }

    private void PlayerHitAnimation() {
        StartCoroutine(SetBollAnimator(_playerAnimator, "isHit"));
    }
     // намеренно сделал 2 метода, в будущем могут отличаться анимации 
    private void EnemyRejoiceAnimation() {
        StartCoroutine(SetBollAnimator(_enemyAnimator, "isRejoice"));
    }

    private IEnumerator SetBollAnimator(Animator animator, string key) {
        animator.SetBool(key, true);
        yield return new WaitForSeconds(2);
        animator.SetBool(key, false);
        StopCoroutine("SetBollAnimator");
    }
}
