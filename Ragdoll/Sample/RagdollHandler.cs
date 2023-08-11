using UnityEngine;

namespace MagicOwl.Ragdoll.Sample
{
    public class RagdollHandler : MonoBehaviour
    {
        [SerializeField] private RagdollComponent Ragdoll;

        public void EnableRagdoll()
        {
            Ragdoll.SetRagdollActive(true);
        }

        public void DisableRagdoll()
        {
            Ragdoll.SetRagdollActive(false);
        }
    }
}