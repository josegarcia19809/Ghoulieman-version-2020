using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;
    private int lifeCounter;
    private Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();
        lifeCounter = startingLives;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "X " + lifeCounter.ToString();
    }

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
    }
}