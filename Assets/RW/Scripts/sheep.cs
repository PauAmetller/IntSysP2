using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    private bool dropped;

    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody;

    private SheepSpawner sheepSpawner;
    //private SpeedModifier speedModifier;

    public float heartOffset; // 1
    public GameObject heartPrefab; // 2

    // Start is called before the first frame update
    void Start()
    {
        
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //speedModifier.updateSheepSpeed();
        //runSpeed = speedModifier.sheepSpeed;
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject); 
            HitByHay(); 
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }


    private void HitByHay()
    {
        hitByHay = true; // 1
        runSpeed = 0; // 2
        Destroy(gameObject, gotHayDestroyDelay); // 3
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false; 
        myCollider.isTrigger = false; 
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
        SoundManager.Instance.PlaySheepDroppedClip();
        Destroy(gameObject, dropDestroyDelay); // 3
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

}
