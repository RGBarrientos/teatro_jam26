using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour
{

    [SerializeField] GameObject cortina;

    [SerializeField] GameObject personaje;

    [SerializeField] GameObject[] escenarioList;

    void Start()
    {
        cortina.SetActive(true);
        personaje.SetActive(false);
        foreach(var obj in escenarioList) {
            obj.SetActive(false);
        }

        startStage();
    }

    void Update()
    {
        
    }

    void startStage()
    {
        StartCoroutine(CorSelEscenario());
    }

    IEnumerator CorSelEscenario()
    {
        yield return new WaitForSeconds(5);
        var escenarioSel = Random.Range(0, escenarioList.Length);
        escenarioList[escenarioSel].SetActive(true);
        personaje.SetActive(true);
        cortina.SetActive(false);
    }

}
