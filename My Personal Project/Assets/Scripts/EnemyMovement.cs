using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private GameManager gameManagerScript;

    private Vector3 enemyPosition;
    private Vector3 nextPosition;
    private Vector3 lookDirection;

    private float rangeRandomX;
    private float rangeRandomZ;

    [SerializeField] private float speed = 5f;
    [SerializeField] private int courseChange = 5;

    private bool positionChanged;

    private float mapRangeX = 250.0f;
    private float mapRangeZ = 250.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyPosition = transform.position;
        nextPosition = new Vector3(RandomRangeX(), 3.5f, RandomRangeZ());
        positionChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 3.5f, transform.position.z);
        
        lookDirection = (nextPosition - enemyPosition).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed);
            
        
    }

    IEnumerator ChangePath()
    {
        yield return new WaitForSeconds(courseChange);
        positionChanged = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManagerScript.gameWin = false;
            gameManagerScript.gameActive = false;
            gameManagerScript.GameOver();
        }
    }

    
    private float RandomRangeX()
    {
        rangeRandomX = transform.position.x + Random.Range(-25, 25);

        if (rangeRandomX > 250.0f)
        {
            rangeRandomX = 250.0f;
        }
        else if (rangeRandomX < -250.0f)
        {
            rangeRandomX = -250.0f;
        }

        return rangeRandomX;
    }

    private float RandomRangeZ()
    {
        rangeRandomZ = transform.position.z + Random.Range(-25, 25);

        if (rangeRandomZ > 250.0f)
        {
            rangeRandomZ = 250.0f;
        }
        else if (rangeRandomZ < -250.0f)
        {
            rangeRandomZ = -250.0f;
        }

        return rangeRandomZ;
    }
}
    