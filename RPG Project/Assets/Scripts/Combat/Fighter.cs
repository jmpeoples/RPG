using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat{
    public class Fighter : MonoBehaviour, IAction
    {

        Transform target;
        [SerializeField] float weaponRange = 2f;
        private void Update()
        {
            if (target == null) return; 

            if (target != null && !GetIsInRange())
            {
                GetComponent<Move>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Move>().Cancel();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
           GetComponent<ActionScheduler>().StartAction(this);
           target = combatTarget.transform;
        }

        public void Cancel(){
            target = null;
        }
    }
}
