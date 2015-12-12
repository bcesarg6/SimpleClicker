//The main script of the clicker, has the main functions and variables

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {

    public int score;                //Main score variable
    public int plus;                 //Score add each click
    public int overtime;             //Score add each second
    public int plus_mod;             //Plus button cost modifier
    public int overtime_mod;         //Overtime score cost modifier
    public int plus_price;           //Plus button price
    public int overtime_price;       //Overtime button price
    public Text plus_text;           //Button "plus" text
    public Text score_text;          //Text component of the score_text object
    public Text overtime_text;       //Text component of the overtime_text object
    public Text plus_button_text;    //Text from the shop plus button
    public Text overtime_button_text;//Text from the overtime button
    public Text plus_price_text;     //Plus price text
    public Text overtime_price_text; //Overtime price text
    public GameObject congrat_text;  //The congrat_text object
    public GameObject shop_button;   //The shop button
    System.DateTime last_time;       //Last time user played the game
    System.DateTime current_time;    //Atual time

    //Private Functions

    //Fired when the MainScript object is created
    void Start () {
        current_time = System.DateTime.Now;
        attData();
        calcSecs();
        attPrices();
        attScore();
        attPlus();
        attOvertime();
        StartCoroutine(overtimeScore());  //Starts a routine that happens aside other things
	}

    //The overtime routine
    IEnumerator overtimeScore() {
        while (overtime_text) {
            int lastScore = score;
            score = score + overtime;
            if (lastScore != score) {
                attScore();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    //Calculates how many seconds passed from last time user played the game
    void calcSecs() {
        System.TimeSpan diff = current_time - last_time;
        score = score + overtime * (int)diff.TotalSeconds;
    }

    //Gets the player data
    void attData() {
        int first = PlayerPrefs.GetInt("first", 1);
        if(first == 1) {                            //If the key first does not exists it creates the necessary keys
            PlayerPrefs.SetInt("first", 0);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("plus", 1);
            PlayerPrefs.SetInt("overtime", 0);
            PlayerPrefs.SetInt("plus_mod", 1);
            PlayerPrefs.SetInt("overtime_mod", 1);
            PlayerPrefs.SetString("last_time", current_time.ToString());
            PlayerPrefs.Save();
        }
        score = PlayerPrefs.GetInt("score", 0);
        overtime = PlayerPrefs.GetInt("overtime", 0);
        plus = PlayerPrefs.GetInt("plus", 1);
        plus_mod = PlayerPrefs.GetInt("plus_mod", 1);
        overtime_mod = PlayerPrefs.GetInt("overtime_mod", 1);
        last_time = System.DateTime.Parse(PlayerPrefs.GetString("last_time", current_time.ToString()));
    }

    //Saves all the data
    void saveAllData() {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("plus", plus);
        PlayerPrefs.SetInt("overtime", overtime);
        PlayerPrefs.SetInt("plus_mod", plus_mod);
        PlayerPrefs.SetInt("overtime_mod", overtime_mod);
        PlayerPrefs.Save();
    }

    //Verifies if there is an upgrade avaible
    bool verifyUpgrade() {
        if (( score >= plus_price ) || ( score >= overtime_price )) {
            congrat_text.SetActive(true);
            return true;
        }
        congrat_text.SetActive(false);
        return false;
    }

    //Public functions

    //Saves an especific data
    public void saveData(string name, object data) {
        if (data.GetType() == typeof(int)) {
            PlayerPrefs.SetInt(name, (int)data);
        }
        else {
            PlayerPrefs.SetString(name, (string)data);
        }
        PlayerPrefs.Save();
    }

    //Calculates the prices
    public void attPrices() {
        plus_price = 10 * plus * plus_mod;
        overtime_price = 10 * (overtime+1) * overtime_mod;
    }

    //Updates the score button text
    public void attPlus() {
        plus_text.text = "+" + plus.ToString();
    }

    //Updates the score_text
    public void attScore() {
        score_text.text = score.ToString();
        current_time = System.DateTime.Now;
        saveData("score", score);
        saveData("last_time", current_time.ToString());

        if (verifyUpgrade()) {            
            shop_button.SetActive(true);
        }
    }

    //Updates the overtime_text
    public void attOvertime() {
        overtime_text.text = "+ " + overtime.ToString() + "/sec";
        saveData("overtime", overtime);
    }

    //Updates the shop texts
    public void attShop() {
        plus_button_text.text = "+ " + (plus + 1).ToString();
        plus_price_text.text = plus_price.ToString();

        overtime_button_text.text = (overtime + 1).ToString() + "/sec";
        overtime_price_text.text = overtime_price.ToString();  
    }
}
