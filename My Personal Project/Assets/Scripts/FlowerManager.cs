using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlowerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pickUpMessage;
    [SerializeField] private GameObject flower;

    private GameManager gameManagerScript;
    private bool messageShown;

    // Start is called before the first frame update
    void Start()
    {
        pickUpMessage.gameObject.SetActive(false);
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        messageShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        if (Input.GetKeyDown(KeyCode.F) && messageShown)
        {
            gameManagerScript.CollectFlower();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpMessage.gameObject.SetActive(true);
            messageShown = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpMessage.gameObject.SetActive(false);
            messageShown = false;
        }
       
    }
}
