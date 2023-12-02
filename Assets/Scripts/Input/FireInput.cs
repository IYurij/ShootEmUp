using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour
    {
        public void Fire(CharacterFireController characterFireController)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterFireController._fireRequired = true;
            }
        }
    }
}