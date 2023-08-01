using UnityEngine;

namespace Despair
{
    public abstract class SelectedItem : MonoBehaviour
    {
        public abstract void PickUpInHand(GameObject go);
        public abstract void PickUpInInventory(GameObject go);
    }
}
