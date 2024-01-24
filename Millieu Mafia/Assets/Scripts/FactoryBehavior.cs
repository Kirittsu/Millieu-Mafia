using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBehavior : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public GameObject SolarPanelPrefab;
    public GameObject effect;
    public AudioClip explosion;
    private GameObject scaledSolarPanel;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        
        if (currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    private void DestroyBuilding()
    {
        // Implement destruction effects (e.g., play explosion animation and sound)
        Instantiate(effect, transform.position + new Vector3(0,5,0), transform.rotation);
        AudioSource.PlayClipAtPoint(explosion, transform.position + new Vector3(0, 5, 0), 20f);
        // Instantiate replacement building prefab
        if (SolarPanelPrefab != null)    
        scaledSolarPanel = Instantiate(SolarPanelPrefab,transform.position, transform.rotation) as GameObject;
        scaledSolarPanel.transform.localScale = new Vector3(10, 5, 10);
        

        // Destroy the current building
        Destroy(gameObject);
    }



}
