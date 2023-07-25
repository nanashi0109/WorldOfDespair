using Despair.Assets.Architecture._Scripts.Player;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerModel _playerModel;

        private void Awake()
        {
            _playerModel.Init();
        }
    }
}
