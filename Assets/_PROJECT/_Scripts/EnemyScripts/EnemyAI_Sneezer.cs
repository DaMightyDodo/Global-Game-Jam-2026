using UnityEngine;

public class EnemyAI_Sneezer : EnemyAI
{
    public GameObject germ;

    public int GermsPerSneeze = 3;
    public float SneezeSpread = 20f;
    public override void AttackAction()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        for (int i = 0; i < GermsPerSneeze; i++)
        {
            float angleStep = SneezeSpread / (GermsPerSneeze - 1);
            float angle = -SneezeSpread / 2 + angleStep * i;

            Quaternion spreadRotation = Quaternion.Euler(angle, 0, 0) * transform.rotation;
            Rigidbody rb = Instantiate(germ, transform.position, spreadRotation).GetComponent<Rigidbody>();
            rb.AddForce(spreadRotation * Vector3.forward * 32f, ForceMode.Impulse);
        }
        Debug.Log("Sneezer Sneezes!");
    }
}
