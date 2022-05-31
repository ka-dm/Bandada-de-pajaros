using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject birdPrefab;
    public int state; // 0 = press start, 1 = intro, 2 = game, 3 = end
    private bool birdsInstanciated;
    public Image pickedColor;
    public GameObject flockAgenteSprite;

    void Start()
    {
        instance = this;
    }


    public void StartGame()
    {
        state = 2;
    }

    private void Update()
    {
        //if (state == 2) InstanciateBirds();
        
    }

    public void InstanciateBirds()
    {
        int startingCount = (int) MainMenuController.instance.sliders[0].GetComponent<Slider>().value;
        int driveFactor = (int)MainMenuController.instance.sliders[1].GetComponent<Slider>().value;
        int maxSpeed = (int)MainMenuController.instance.sliders[2].GetComponent<Slider>().value;
        float neigborRadius = MainMenuController.instance.sliders[3].GetComponent<Slider>().value;
        float avoidRadiusMultiplier = MainMenuController.instance.sliders[4].GetComponent<Slider>().value;
        

        birdPrefab.GetComponentInChildren<Flock>().startingCount = startingCount;
        birdPrefab.GetComponentInChildren<Flock>().driveFactor = driveFactor;
        birdPrefab.GetComponentInChildren<Flock>().maxSpeed = maxSpeed;
        birdPrefab.GetComponentInChildren<Flock>().neighborRadius = neigborRadius;
        birdPrefab.GetComponentInChildren<Flock>().avoidanceRadiusMultiplier = avoidRadiusMultiplier;
        flockAgenteSprite.GetComponentInChildren<SpriteRenderer>().color = pickedColor.color;

       Instantiate(birdPrefab);
    }

}
