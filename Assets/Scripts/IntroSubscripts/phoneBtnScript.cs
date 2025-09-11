using UnityEngine;

public class phoneBtnScript : MonoBehaviour
{
    public IntroPhoneScript intro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Here");
        intro.Answer();
    }
}
