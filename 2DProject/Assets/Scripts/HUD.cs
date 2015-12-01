using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartUI;

    private LinkControllerScript player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LinkControllerScript>();
    }

    void Update ()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}
