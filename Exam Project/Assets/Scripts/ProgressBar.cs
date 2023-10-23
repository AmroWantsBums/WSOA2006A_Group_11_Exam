using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI TaskMessage;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTask(string Task)
    {
        Instantiate(TaskMessage, Parent.transform);
        TaskMessage.text = Task;
    }
}
