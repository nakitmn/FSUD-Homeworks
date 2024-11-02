using System.Collections;
using Space_Ship;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _countdown = 1f;

        private SpaceShip _ship;
        private SpaceShip _target;
        private Coroutine _attackCoroutine;

        public void Construct(SpaceShip ship, SpaceShip target)
        {
            _ship = ship;
            _target = target;
        }

        public void Enable()
        {
            if (_attackCoroutine != null) return;
            _attackCoroutine = StartCoroutine(Attack());
        }

        public void Disable()
        {
            if (_attackCoroutine == null) return;
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }

        private IEnumerator Attack()
        {
            WaitForSeconds delay = new WaitForSeconds(_countdown);

            while (_target.IsDead == false)
            {
                yield return delay;
                Fire();
            }

            _attackCoroutine = null;
        }

        private void Fire()
        {
            Vector2 startPosition = _firePoint.position;
            Vector2 vector = (Vector2) _target.transform.position - startPosition;
            Vector2 direction = vector.normalized;
            _ship.Fire(direction);
        }
    }
}