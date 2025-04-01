using Meta.WitAi.Events.UnityEventListeners;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using System.Collections;


public class Incantation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI textBox;

    [Header("LinkedScript")]
    public VoiceManager voiceManager;


    public string incantingWords = "";
    private float timeElaspse;
    private bool isActivate; 
    
    public GameObject spawnPoop; 
    private SpawnPointCreator spawnPointCreator;

    private bool isSpawning = false;
    void Start()
    {
        incantingWords = voiceManager.outText;
        spawnPointCreator = spawnPoop.GetComponent<SpawnPointCreator>();
        spawnPointCreator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (incantingWords != null && isSpawning == false)
        {
            if (incantingWords.ToLower() == "wakey wakey")
            {
                textBox.text = "Odour Farming";
                spawnPointCreator.num_spawnPoints = 10;
                spawnPointCreator.setupSpawnArea();
                isSpawning = true;
                //Debug.Log(isSpawning);
                //isActivate = true;
                //spawnPointCreator.enabled = true;
                //Instantiate(spawnPointCreator);
                //StartCoroutine(ExampleCoroutine());
            }
            if (incantingWords.ToLower() == "crash")
            {
                textBox.text = "Odour Maximas";
                spawnPointCreator.num_spawnPoints = 1000;
                spawnPointCreator.setupSpawnArea();
                //spawnPointCreator.enabled = true;
                //Instantiate(spawnPointCreator);
                //StartCoroutine(ExampleCoroutine());
            }
        }

        //if (isActivate == true)
        //{
        //    timeElaspse += Time.deltaTime;    

        //    if (timeElaspse > 3)
        //    {
        //        isActivate = false;
        //        textBox.text = "Incantation finished...";
        //        spawnPointCreator.enabled = false;
        //    }
        //}

        //incantingWords = "...";
        incantingWords = voiceManager.outText;


        isSpawning = false; 
    }

    IEnumerator ExampleCoroutine()
    {
        Instantiate(spawnPointCreator);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        //spawnPointCreator.enabled = false;
        Destroy(spawnPointCreator);
    }
}
