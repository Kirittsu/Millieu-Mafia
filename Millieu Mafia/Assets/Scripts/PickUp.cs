using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    int pickedUp = 0;
    public AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 0.5f);
            pickedUp++;
            Debug.Log($"Picked up {pickedUp} gun(s)");
            Destroy(other.gameObject);
        }
        if (pickedUp == 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
