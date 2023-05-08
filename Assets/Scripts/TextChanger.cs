using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI Text;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dash unlock")
        {
            Text.text = ("Press left shift to dash throught the air");
            Invoke("StopText", 1);
        }
        
    }

    void StopText()
    {
        Text.text = ("");
    }
}