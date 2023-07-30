using UnityEngine;

namespace Despair.Assets.Architecture._Scripts
{
    public class EnemyModel : MonoBehaviour
    {
        #region Field
        [Header("Enemy Data")]
        [SerializeField] private int _maxEnemyHealth;
        [SerializeField] private int _enemyHealth;
        #endregion

        private void Start()
        {
            _enemyHealth = _maxEnemyHealth;
        }

        public void IncreaseHealth(int heal)
        {
            if (_enemyHealth + heal <= _maxEnemyHealth)
            {
                _enemyHealth += heal;
            }
            else if (_enemyHealth + heal > _maxEnemyHealth)
            {
                _enemyHealth = _maxEnemyHealth;
            }
        }

        public void DecreaseHealth(int damage)
        {
            if(_enemyHealth == 0)
            {
                EnemyDied();
            }
            _enemyHealth -= damage;
        }

        public void EnemyDied()
        {

        }
    }
}
