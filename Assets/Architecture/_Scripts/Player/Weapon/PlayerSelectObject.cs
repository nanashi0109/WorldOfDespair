using UnityEngine;

namespace Despair
{
    public class PlayerSelectObject : MonoBehaviour
    {
        [SerializeField] private Transform WeaponSlot;

        private bool _isWeapon;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
            ThrowWeapon();
            }
        }

        private bool WeaponEquipped()
        {
            if (WeaponSlot.childCount == 0)
                _isWeapon = false;
            else
                _isWeapon = true;

            return _isWeapon;
        }

        public void EquipWeapon(GameObject weapon)
        {
            if (!WeaponEquipped())
            {
                weapon.transform.SetParent(WeaponSlot, true);
                weapon.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                weapon.transform.localPosition = Vector3.zero;
                weapon.transform.rotation = Quaternion.identity;
                weapon.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        public void ThrowWeapon()
        {
            if (WeaponEquipped())
            {
                WeaponSlot.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                WeaponSlot.GetChild(0).transform.SetParent(null);
            }
        }
    }
}
