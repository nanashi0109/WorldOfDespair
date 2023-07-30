using System.Collections;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerAttack
    {
        private bool _isAttacking = false;
        private float _attackRange;

        private const int ENEMY_LAYER_INDEX  = 6;

        private PlayerModel _playerModel;

        public PlayerAttack(PlayerModel playerModel) 
        {
            _playerModel = playerModel;
        }

        public IEnumerator Attack(int damage, float attackCooldown, float attackRange,Transform attackPoint, LayerMask _enemyLayer)
        {
            if (!_isAttacking)
            {
                _playerModel.GetAnimator.SetTrigger("AttackTrigger");

                _isAttacking = true;

                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, _enemyLayer);

                foreach(Collider2D enemy in hitColliders)
                {
                    Debug.Log("Enemy hit: " + enemy.name);
                    enemy.GetComponent<EnemyModel>().DecreaseHealth(damage);
                }

                yield return new WaitForSeconds(attackCooldown);
                _isAttacking = false;
            }
        }
    }
}
