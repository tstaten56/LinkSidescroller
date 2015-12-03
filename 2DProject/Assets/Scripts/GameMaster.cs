using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int rupees;
    public int highestRupees;

    public Text pointsText;
    public Text inputText;

    void Start()
    {
        if(PlayerPrefs.HasKey("Rupees"))
        {
            if(Application.loadedLevel == 0) //If level is tutorial or Main
            {
                Debug.Log("Level IS tutorial");
                //Remove the rupees count 
                PlayerPrefs.DeleteKey("Rupees");
                rupees = 0;
            }
            else
            {
                Debug.Log("Level isn't tutorial");
                rupees = PlayerPrefs.GetInt("Rupees");
            }
        }

        if(PlayerPrefs.HasKey("HighRupees"))
        {
            highestRupees = PlayerPrefs.GetInt("HighRupees");
        }
    }

    void Update()
    {

        pointsText.text = ("Rupees: " + rupees);
    }
}
