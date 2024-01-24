using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    // UIManager
    private UIManager _uiManager;

    // Shoot
    public GameObject projectile;
    public float power = 100;

    // Audio
    public float ClipLength = 1f;
    public AudioClip ShootSound;
    public AudioClip ReloadSound;

    private AudioSource audioSource;


    // Gun stats
    public int damage = 1;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    // Bools
    bool shooting, readyToShoot, reloading;

    // Reference
    public Camera fpsCam;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    // Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Awake()
    {
        // Zoek het GameObject met de tag 'shoot'
        GameObject shootSoundObject = GameObject.FindGameObjectWithTag("shoot");

        // Controleer of het GameObject met de tag 'shoot' is gevonden
        if (shootSoundObject != null)
        {
            // Haal de AudioSource component op van het gevonden GameObject
            audioSource = shootSoundObject.GetComponent<AudioSource>();
        }

        // Rest van je Awake() code
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }


    private void Update()
    {
       if (!PauseMenu.isPaused)
       {
            MyInput();
       }
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        // Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        // Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));

        // Spawn projectile
        GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

        bulletsLeft--;
        _uiManager.updateAmmo(bulletsLeft, magazineSize);
        bulletsShot--;

        if (Input.GetKey(KeyCode.Mouse0))
        { 
            // Speel het schietgeluid af
            if (audioSource != null)
            {
                audioSource.clip = ShootSound;
                audioSource.Play();
            }
        }


        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }


    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);

        // Speel het herlaadgeluid af
        if (audioSource != null)
        {
            audioSource.PlayOneShot(ReloadSound);
        }
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        _uiManager.updateAmmo(bulletsLeft, magazineSize);
        reloading = false;
    }
}
