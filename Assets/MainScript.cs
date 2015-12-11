using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {

    public int score;          //Main score variable
    public int overtime_score; //Socore add each second
    public Text score_text;    //Text component of the score_text object
    public Text overtime_text; //Text component of the overtime_text object

    //Fired when the MainScript object is created
    void Start () {
        attData();
        attScore();
        attOvertime();
	}

    //Gets the player data
    void attData() {
        int first = PlayerPrefs.GetInt("first", 1);
        if(first == 1) {                            //If the key first does not exists it creates the necessary keys
            PlayerPrefs.SetInt("first", 0);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("overtime_score", 0);
            PlayerPrefs.Save();
        }
        score = PlayerPrefs.GetInt("score");
        overtime_score = PlayerPrefs.GetInt("overtime_score");
    }

    //Saves all the data
    void saveData() {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("overtime_score", overtime_score);
        PlayerPrefs.Save();
    }

    //Updates the score_text
    public void attScore() {
        score_text.text = score.ToString();
        saveData();
    }
    
    //Updates the overtime_text
    public void attOvertime() {
        overtime_text.text = "+ " + overtime_score.ToString() + "/sec";
        saveData();
    }
}
