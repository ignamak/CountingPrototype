using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{

    public GameObject ballPrefab;
    BoxCollider box;

    int ballCounter = 20;
    public Text ballsText; 

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();

        StartCoroutine(SpawnBalls());

        ballsText.text = "Remaining balls: " + ballCounter;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }
        
    }

    IEnumerator SpawnBalls() 
    {
        while (ballCounter != 0)
        {
            //float randomX = Random.Range(box.bounds.min.x, box.bounds.max.x);
            float randomY = Random.Range(box.bounds.min.y, box.bounds.max.y);
            float randomZ = Random.Range(box.bounds.min.z, box.bounds.max.z);

            Vector3 randomPos = new Vector3(box.bounds.center.x, randomY, randomZ);

            GameObject.Instantiate(ballPrefab, randomPos, Quaternion.identity);

            ballCounter--;
            ballsText.text = "Remaining balls: " + ballCounter;


            yield return new WaitForSeconds(2);
        }

        ballsText.text = "Hit backspace to restart ";

    }

}
