using UnityEngine;

public class EnemyAI_Cougher : EnemyAI
{
    public GameObject germ;
    public override void AttackAction()
    {
        // Implement the specific attack action for the Cougher enemy
        Rigidbody rb = Instantiate(germ, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

        Debug.Log("Cougher Enemy Attacks with a cough!");
    }
}
