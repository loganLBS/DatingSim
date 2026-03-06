using UnityEngine;
using UnityEngine.SceneManagement;
public class PhoneMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitTT()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
