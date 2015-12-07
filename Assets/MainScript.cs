using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {
    int score;
    int somador;
    int overtime;
    int modificador_counter;
    int modificador_overtime;
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
        score = 0; //Initial score
        overtime = 0;
        somador = 1; //Initial multiplaier
        modificador_counter = 1;
        modificador_overtime = 1;
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
        StartCoroutine(overtime_score());
	}

    IEnumerator overtime_score(){
        while (overtime_text){
            score = score + overtime;
            score_text.GetComponent<Text>().text = score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    bool verify_upgrade(){
        att_price();
        if ((score >= counter_price) || (score >= overtime_price)){
            return true;
        }
        return false;
    }

    void att_price(){
        counter_price = 10 * somador * modificador_counter;
        overtime_price = 10 * (overtime + 1) * modificador_overtime;
    }

    void att_shop(){
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
    public void update_score(){
        score = score + somador;
        score_text.GetComponent<Text>().text = score.ToString();
        if (verify_upgrade()){
            congrat_text.SetActive(true);
            shop_button.SetActive(true);
        }
    }

    //Is called every time the shop_button is pressed
    public void open_shop(){
        shop_panel.SetActive(true);
        att_price();
        att_shop();
    }

    public void plus_counter(){
        if(score >= (10 * somador * modificador_counter)){
            score = score - (10 * somador * modificador_counter);
            somador = somador + 1;
            modificador_counter = modificador_counter + 1;
            score_button.GetComponentInChildren<Text>().text = mais_string + somador;
            score_text.GetComponent<Text>().text = score.ToString();

            if (!(verify_upgrade())){
                congrat_text.SetActive(false);
            }
            att_shop();
        }
    }
	
    public void plus_overtime(){
        if((score >= (10 * (overtime + 1) * modificador_overtime))){
            score = score - (10 * (overtime + 1) * modificador_overtime);
            overtime = overtime + 1;
            modificador_overtime = modificador_overtime + 1;
            score_text.GetComponent<Text>().text = score.ToString();
            overtime_text.GetComponent<Text>().text = overtime.ToString() + secs_string;

            if (!(verify_upgrade())){
                congrat_text.SetActive(false);
            }
            att_shop();
        }
    }

    public void exit_shop(){
        shop_panel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
    }
}
