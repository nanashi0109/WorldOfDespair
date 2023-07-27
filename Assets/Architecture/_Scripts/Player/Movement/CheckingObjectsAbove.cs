using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class CheckingObjectsAbove : MonoBehaviour
    {
        public bool IsStandUp { get; private set; } = true;


        private void OnTriggerStay2D(Collider2D collision)
        {
            IsStandUp = false;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            IsStandUp = true;
        }
    }
}
