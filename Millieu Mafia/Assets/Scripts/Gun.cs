using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _canon;
    [SerializeField]
    private GameObject _shootEffectPrefab;
    [SerializeField]
    private GameObject _shootSound;
    [SerializeField]
    private GameObject _victorySound;
    [SerializeField]
    private float _bulletSpeed = 2f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _canon.transform.position, transform.rotation);
        GameObject effect = Instantiate(_shootEffectPrefab, _canon.transform.position, transform.rotation);
        GameObject sound = Instantiate(_shootSound, _canon.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
        Destroy(sound, 1);
        Destroy(effect, 1);
        Destroy(bullet, 2);
    }

}