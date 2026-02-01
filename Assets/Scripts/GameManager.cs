using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    
    //Cortina inicial
    [SerializeField] GameObject cortina;
    [SerializeField] GameObject personaje;
    [SerializeField] GameObject[] elementosList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Confined;

        personaje.SetActive(false);
        cortina.SetActive(true);

        StartStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible=true;
            Cursor.lockState=CursorLockMode.None;
        }
    }

    void StartStage()
    {
        StartCoroutine(CorSelEscenario());
    }

    IEnumerator CorSelEscenario()
    {
        yield return new WaitForSeconds(3);
        personaje.SetActive(true);
        cortina.SetActive(false);
    }
}
