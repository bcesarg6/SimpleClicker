using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {
    int first;
    int score;
    int somador;
    int overtime;
    int mod_counter;
    int mod_overtime;
    int counter_price;
    int overtime_price;
    string title_string;
    string congrat_string;
    string shop_text_string;
    string mais_string;
    string secs_string;
    string plus_button_string;
    string overtime_button_string;
    string exit_shop_button_string;
    public GameObject debug_text;
    public GameObject title_text;
    public GameObject score_text;
    public GameObject overtime_text;
    public GameObject congrat_text;
    public GameObject score_button;
    public GameObject shop_button;
    public GameObject shop_panel;
    public GameObject plus_button;
    public GameObject overtime_button;
    public GameObject exit_shop_button;

    // Use this for initialization
    void Start () {
        first = PlayerPrefs.GetInt("first", 0);
        score = PlayerPrefs.GetInt("score", 0);
        overtime = PlayerPrefs.GetInt("overtime", 0);
        somador = PlayerPrefs.GetInt("somador", 1);
        mod_counter = PlayerPrefs.GetInt("mod_counter", 1);
        mod_overtime = PlayerPrefs.GetInt("mod_overtime", 1);
        if(first == 0) {
            printText("first");
            attData();
        }
        else { printText("not first"); }
        title_string = "Clicker 2.0"; //Title
        congrat_string = "Parabéns, você tem um upgrade"; 
        shop_text_string = "Shop";
        mais_string = "+";
        secs_string = "/s";
        counter_price = 0;
        overtime_price = 0;
        plus_button_string = mais_string + (somador + 1).ToString();
        overtime_button_string = mais_string + (overtime + 1).ToString() + secs_string;
        exit_shop_button_string = "Exit";
        title_text.GetComponent<Text>().text = title_string;
        score_text.GetComponent<Text>().text = score.ToString();
        overtime_text.GetComponent<Text>().text = overtime.ToString() + secs_string;
        congrat_text.GetComponent<Text>().text = congrat_string;
        score_button.GetComponentInChildren<Text>().text = mais_string + somador;
        shop_button.GetComponentInChildren<Text>().text = shop_text_string;
        plus_button.GetComponentsInChildren<Text>()[0].text = plus_button_string;
        plus_button.GetComponentsInChildren<Text>()[1].text = counter_price.ToString();
        overtime_button.GetComponentsInChildren<Text>()[0].text = overtime_button_string;
        overtime_button.GetComponentsInChildren<Text>()[1].text = overtime_price.ToString();
        exit_shop_button.GetComponentInChildren<Text>().text = exit_shop_button_string;
        congrat_text.SetActive(false);
        shop_button.SetActive(false);
        shop_panel.SetActive(false);
        StartCoroutine(overtimeScore());
	}

    void printText(string text){
        debug_text.GetComponent<Text>().text = text;
    }

    IEnumerator overtimeScore(){
        while (overtime_text){
            score = score + overtime;
            attData();
            score_text.GetComponent<Text>().text = score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    void attData(){
        PlayerPrefs.SetInt("first", 1);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("overtime", overtime);
        PlayerPrefs.SetInt("somador", somador);
        PlayerPrefs.SetInt("mod_counter", mod_counter);
        PlayerPrefs.SetInt("mod_overtime", mod_overtime);
        PlayerPrefs.Save();
    }

    bool verifyUpgrade(){
        attPrice();
        if ((score >= counter_price) || (score >= overtime_price)){
            return true;
        }
        return false;
    }

    void attPrice(){
        counter_price = 10 * somador * mod_counter;
        overtime_price = 10 * (overtime + 1) * mod_overtime;
    }

    void attShop(){
        if (shop_panel.activeSelf){
            plus_button_string = mais_string + (somador + 1).ToString();
            overtime_button_string = mais_string + (overtime + 1).ToString() + secs_string;
            plus_button.GetComponentsInChildren<Text>()[0].text = plus_button_string;
            plus_button.GetComponentsInChildren<Text>()[1].text = counter_price.ToString();
            overtime_button.GetComponentsInChildren<Text>()[0].text = overtime_button_string;
            overtime_button.GetComponentsInChildren<Text>()[1].text = overtime_price.ToString();
        }
    }

    //Is called every time the score_button is pressed
    public void updateScore(){
        score = score + somador;
        score_text.GetComponent<Text>().text = score.ToString();
        if (verifyUpgrade()){
            congrat_text.SetActive(true);
            shop_button.SetActive(true);
        }
    }

    //Is called every time the shop_button is pressed
    public void openShop(){
        shop_panel.SetActive(true);
        attPrice();
        attShop();
    }

    public void plusCounter(){
        if(score >= (10 * somador * mod_counter)){
            score = score - (10 * somador * mod_counter);
            somador = somador + 1;
            mod_counter = mod_counter + 1;
            score_button.GetComponentInChildren<Text>().text = mais_string + somador;
            score_text.GetComponent<Text>().text = score.ToString();

            if (!(verifyUpgrade())){
                congrat_text.SetActive(false);
            }
            attShop();
        }
    }
	
    public void plusOvertime(){
        if((score >= (10 * (overtime + 1) * mod_overtime))){
            score = score - (10 * (overtime + 1) * mod_overtime);
            overtime = overtime + 1;
            mod_overtime = mod_overtime + 1;
            score_text.GetComponent<Text>().text = score.ToString();
            overtime_text.GetComponent<Text>().text = overtime.ToString() + secs_string;

            if (!(verifyUpgrade())){
                congrat_text.SetActive(false);
            }
            attShop();
        }
    }

    public void exitShop(){
        shop_panel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
    }

    void OnApplicationQuit(){
        attData();
        printText("quit");
    }
}
