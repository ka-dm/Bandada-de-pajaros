using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //public Animator menuAnim;
    //public GameObject intro;
    //public Animator introAnim;
    public static MainMenuController instance;
    public List<GameObject> sliders = new List<GameObject>();
    public List<TMP_InputField> tmsImput = new List<TMP_InputField>();
    public GameObject configGame;
    public GameObject menu;

    bool buttonPressed;
    bool inCredits;
    float timer;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (GameController.instance.state == 0 && !buttonPressed)
        {

            if (ImputController.instance.enter)
            {
                print("Cambio a estado 1");
                GameController.instance.state = 2;
                //GameController.instance.InstanciateBirds();
                buttonPressed = true;
                menu.SetActive(false);
                configGame.SetActive(true);
                //menuAnim.SetTrigger("out");
                //intro.SetActive(true);
                //introAnim.SetTrigger("action");
                //timer = 0;
            }
            else if (ImputController.instance.escape)
            {
                buttonPressed = true;
                Application.Quit();
            }
        }
        else
        {
            if (ImputController.instance.enter || ImputController.instance.escape)
            {
                //menuAnim.SetTrigger("in");
            }
        }
        ChageSliderValue();

    }

    void StartGame()
    {
        GameController.instance.StartGame();
    }

    void ChageSliderValue()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            //print(tmsImput[2].GetComponent<TextMeshPro>().text);
            tmsImput[i].text = sliders[i].GetComponent<Slider>().value.ToString();
        }
    }
}
