using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _ammoText;
    [SerializeField]
    private TMP_Text _healthBar;
    public void updateAmmo(int count, int max)
    {
        _ammoText.text = "Ammo: " + count + "/" + max;
    }

    public void updateHealth(int count, int max)
    {
        if (count > 0) _healthBar.text = "Health: " + count + "/" + max;
        else _healthBar.text = "You died!";
    }
}
