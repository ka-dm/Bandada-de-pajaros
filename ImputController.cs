using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Detects clicks from the mouse and prints a message
// depending on the click detected.

public class ImputController : MonoBehaviour
{
    public static ImputController instance;
    public GameObject obstaclePrefab;
    [SerializeField] private Flock flock;
    public bool enter;
    public bool escape;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        Menu();
        if (GameController.instance.state == 2) Game();
    }

    void Menu()
    {
        if (Input.GetKeyDown("return") || Input.GetKeyDown("space"))
        {
            enter = true;
        }
        if (Input.GetKeyDown("escape"))
        {
            escape = true;
        }

        if (escape)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Game()
    {
        if (Input.GetMouseButtonDown(3))
        {
            Debug.Log("Pressed primary button.");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1;
            flock.AddAgentToList(mousePosition);
        }


        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed secondary button.");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1;
            Instantiate(obstaclePrefab).transform.position = mousePosition;
            Debug.Log("Obstace created.");
        }
    }
}