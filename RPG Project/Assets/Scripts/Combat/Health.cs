using UnityEngine;

namespace RPG.Combat {

    public class Health : MonoBehaviour {

       [SerializeField] float healthPoints = 100f;

       bool isDead = false;

       public void TakeDamage(float damage){

           healthPoints = Mathf.Max(healthPoints - damage, 0);
           if(healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // Don't do anythig following if isDead is true; 
            if(isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}