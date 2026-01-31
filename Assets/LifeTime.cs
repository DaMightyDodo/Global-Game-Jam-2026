using UnityEngine;
using System;
public class LifeTime : MonoBehaviour
{
    //MUST READ:
    /*
     * NOT A BIG PROJECT AND TO SAVE TIME, WE ARE NOT USING OBJECT POOLING YET.
     */
    [SerializeField] private float lifeTime = 0.2f;
    public Action OnTouchingEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this will destroy the game object after a while
        //CURRENTLY NOT WORKING
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Please specify more about tags and layer
        OnTouchingEnemy?.Invoke();
        Destroy(gameObject);
    }
}
