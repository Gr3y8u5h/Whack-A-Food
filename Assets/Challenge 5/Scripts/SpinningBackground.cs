using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBackground : MonoBehaviour
{
    
    GameManagerX gameManagerX;
    public float difficultyLevel;

    public float maxSize;
    public float growFactor;
    public float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        StartCoroutine(Scale());

    }

    // Update is called once per frame
    void Update()
    {
        difficultyLevel = gameManagerX.backgroundDifficulty;
        RotateBackground();
        
    }

    void RotateBackground()
    {
        if (difficultyLevel == 1)
        {
            Debug.Log("Is Easy");
            transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);
            waitTime = 0.5f;
            growFactor = 0.5f;
        }
        if (difficultyLevel == 2)
        {
            Debug.Log("Is Med");
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
            waitTime = 0.25f;
            growFactor = 1.5f;
        }
        if (difficultyLevel == 3)
        {
            Debug.Log("Is Hard");
            transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
            waitTime = .05f;
            growFactor = 3.0f;
        }
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(2, 2, 0) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1.5 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(2, 2, 0) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
