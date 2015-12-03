using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int rupees;

    public Text pointsText;
    public Text inputText;

    void Update()
    {

        pointsText.text = ("Rupees: " + rupees);
    }
}
