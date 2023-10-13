using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingState : MonoBehaviour
{
    public Animator anim;
    public bool IsViewing;
    public GameObject ViewPaintingTxt;
    public GameObject HidePaintingTxt;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerController.CanView)
        {
            if (IsViewing)
            {
                HidePainting();
            }
            else
            {
                ShowPainting();
            }
        }

    }

    public void ShowPainting()
    {
        anim.SetBool("IsViewing", true);
        IsViewing = true;
        ViewPaintingTxt.SetActive(false);
        HidePaintingTxt.SetActive(true);
    }

    public void HidePainting()
    {
        anim.SetBool("IsViewing", false);
        IsViewing = false;
        ViewPaintingTxt.SetActive(true);
        HidePaintingTxt.SetActive(false);
        playerController.CanView = false;
        playerController.IsViewing = false;
    }
}
