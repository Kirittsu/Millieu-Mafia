using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooter : MonoBehaviour
{
    EnemyBrain_Stupid enemyBrain_Stupid;
    [Header("General")]
    public Transform shootPoint;
    public Transform gunPoint;
    public LayerMask layerMask;

    [Header("Gun")]
    public Vector3 spread = new Vector3(0.06f, 0.06f, 0.06f);
    public TrailRenderer bulletTrail;
    public int ammo = 30;
    private EnemyReference enemyReference;
    private int currentAmmo;

    private void Awake()
    {
        enemyReference = GetComponent<EnemyReference>();
        Reload();
    }

    public void Shoot()
    {
        if (ShouldReload()) return;
        
        Vector3 direction = GetDirection();
        if (Physics.Raycast(shootPoint.position, direction, out RaycastHit hit, float.MaxValue, layerMask))
        {
            Debug.DrawLine(shootPoint.position, shootPoint.position + direction * 10f, Color.red, 1f);

            TrailRenderer trail = Instantiate(bulletTrail, gunPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));

            DamagaPlayer player = hit.collider.GetComponent<DamagaPlayer>();
            if (player != null)
            {
                player.TakeDamage(1); // Adjust the damage value as needed
            }

            currentAmmo -= 1;
        }
    }

    public bool ShouldReload()
    {
        return currentAmmo <= 0;
    }

    public void Reload()
    {
        Debug.Log("Reloaded");
        currentAmmo = ammo;
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0f;
        Vector3 startPosition = trail.transform.position;

        while (time < 1f)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        direction += new Vector3(
            Random.Range(-spread.x, spread.x),
            Random.Range(-spread.y, spread.y),
            Random.Range(-spread.z, spread.z)
            );

        direction.Normalize();
        return direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
