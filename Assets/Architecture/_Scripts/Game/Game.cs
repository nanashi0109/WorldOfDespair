using Despair.Assets.Architecture._Scripts.Player;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private CameraFollow _cameraFollow;

        private void Awake()
        {
            _playerModel.Init();
            _cameraFollow.Init();
        }
    }
}
