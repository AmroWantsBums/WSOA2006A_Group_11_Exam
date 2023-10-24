using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI TaskMessage;
    public GameObject Parent;
    public string Message;
    // Start is called before the first frame update
    void Start()
    {
        Parent = GameObject.Find("Content");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Debug.Log(Message);
            AddTask(Message);
        }
    }

    public void AddTask(string Task)
    {
        Instantiate(TaskMessage, Parent.transform);
        TaskMessage.text = Task;
        Destroy(gameObject);
    }
}
