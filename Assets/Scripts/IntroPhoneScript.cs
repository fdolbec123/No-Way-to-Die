using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPhoneScript : MonoBehaviour
{
    public GameObject phoneBtn;
    public DataToSave DataToSaveObject = new DataToSave();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    IEnumerator DoSomething(float duration)
    {
        // do something before
        Debug.Log("Before");

        // waits here
        yield return new WaitForSeconds(duration);
        phoneBtn.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true;
    }
    void Start()
    {
        DataToSaveObject.levelToGo = 0;
        SaveSystemScript.Save(DataToSaveObject);
        Debug.Log("Here");
        StartCoroutine(DoSomething(3));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Answer()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.transform.Rotate(new Vector3(0, 0, 0));
        phoneBtn.SetActive(false);
        DataToSaveObject.levelToGo = 1;
        SaveSystemScript.Save(DataToSaveObject);
    }
}