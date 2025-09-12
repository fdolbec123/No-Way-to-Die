using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPhoneScript : MonoBehaviour
{
    public GameObject phoneBtn;
    public DataToSave DataToSaveObject = new DataToSave();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    IEnumerator DoSomething(float duration) // Function to start action after a define time
    {
        // do something before
        Debug.Log("Before");

        // waits here
        yield return new WaitForSeconds(duration);

        // code after the timer ended:
        phoneBtn.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true; // Start the animation of phone vibrating
    }
    void Start()
    {
        DataToSaveObject.levelToGo = 0;
        SaveSystemScript.Save(DataToSaveObject); //Calling the save function in the save manager (AKA SaveSystemScript)
        Debug.Log("Here");
        StartCoroutine(DoSomething(3)); // Starting the function containing a timer
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Answer()
    {
        gameObject.GetComponent<Animator>().enabled = false; // Stopping the animation of the phone vibrating
        gameObject.transform.Rotate(new Vector3(0, 0, 0)); // resetting position of the phone sprite
        phoneBtn.SetActive(false); // hiding the "answer phone call btn"
        DataToSaveObject.levelToGo = 1; // This temporary...
        SaveSystemScript.Save(DataToSaveObject);
    }
}