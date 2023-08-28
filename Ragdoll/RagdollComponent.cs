using System.Collections.Generic;
using System.Linq;
using MagicOwl.Utils;
using UnityEngine;

namespace MagicOwl.Ragdoll
{
    public sealed class RagdollComponent : MonoBehaviour
    {
        [SerializeField] private List<Rigidbody> RagdollRigidbodies;
        [SerializeField] private List<Collider> RagdollColliders;

        public void SetRagdollActive(bool active)
        {
            if (RagdollColliders.IsNullOrEmpty())
            {
                FillRagdollComponents();
                RemoveParentFromRagdoll();
            }
            
            var count = RagdollColliders.Count;
            for (int i = 0; i < count; i++)
            {
                RagdollRigidbodies[i].isKinematic = !active;
                RagdollColliders[i].enabled = active;
            }
        }

        private void FillRagdollComponents()
        {
            RagdollRigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
            RagdollColliders = GetComponentsInChildren<Collider>().ToList();
            RemoveParentFromRagdoll();
        }

        private void RemoveParentFromRagdoll()
        {
            RagdollRigidbodies.Remove(GetComponent<Rigidbody>());
            RagdollColliders.RemoveAll(c => c.transform == transform);
        }
    }
}