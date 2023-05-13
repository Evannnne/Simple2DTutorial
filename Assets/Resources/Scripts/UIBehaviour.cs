using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public Image[] hearts;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
            hearts[i].color = i < PlayerController.Instance.health ? Color.white : Color.black;
    }
}
