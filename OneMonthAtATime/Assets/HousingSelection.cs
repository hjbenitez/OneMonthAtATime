using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HousingSelection : MonoBehaviour
{
    static int houseSelection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lowEndHouse()
    {
        houseSelection = 1;
        SceneManager.LoadScene("Game");
    }

    public void mediumEndHouse()
    {
        houseSelection = 2;
        SceneManager.LoadScene("Game");
    }

    public void highEndHouse()
    {
        houseSelection = 3;
        SceneManager.LoadScene("Game");
    }

    public int getSelection()
    {
        return houseSelection;
    }
}
