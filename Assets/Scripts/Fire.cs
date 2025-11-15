using UnityEngine;

namespace DefaultNamespace
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private float fireHealth = 5f;
        [SerializeField] private ParticleSystem fireParticles;

        public void Extinguish(float amount)
        {
            fireHealth -= amount;
            if (fireHealth<=0)
            {
                fireParticles.Stop();
                GetComponent<Collider>().enabled = false;
                this.enabled = false;
                Debug.Log("Fire extinguished!");
            }
        }
    }
}