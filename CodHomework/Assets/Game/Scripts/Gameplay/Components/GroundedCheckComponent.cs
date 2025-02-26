using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GroundedCheckComponent
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly List<Collider2D> _contactColliders = new();

        public GroundedCheckComponent(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public bool IsGrounded()
        {
            var contactsCount = _rigidbody.GetContacts(_contactColliders);
            for (var i = 0; i < contactsCount; i++)
            {
                var collider = _contactColliders[i];
                
                var groundComponent = collider.GetComponent<Ground>();
                if (groundComponent != null)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}