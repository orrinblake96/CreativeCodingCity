using System;
using Managers;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    
    public float damage = 10f;
    public float range = 100f;
    public float timeBetweenBullets = 0.15f;

    public ParticleSystem muzzleFlash;
    public GameObject bulletImpactEffect;
    
    private float _timer;
    private TimeManager _timeManager;

    private void Start()
    {
        _timeManager = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (Input.GetButton("Fire1") && _timer >= timeBetweenBullets)
        {
            FindObjectOfType<AudioManager>().Play("GunShot");
            muzzleFlash.Play();
            Shoot();
        }
    }

    private void Shoot()
    {
        _timer = 0f;
        
        RaycastHit hit;
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            //Instantiate Bullet Impact effect
            GameObject impactBulletGameObject = Instantiate(bulletImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            
            // If time reducing object is hit then call function
            if(hit.transform.name == "TimeReducer(Clone)") _timeManager.TimerReduced(hit.transform.gameObject);
            
            Destroy(impactBulletGameObject, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MazeFloor"))
        {
            _timeManager.TimerStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MazeFloor"))
        {
            _timeManager.TimerStop();
        }
    }
}
