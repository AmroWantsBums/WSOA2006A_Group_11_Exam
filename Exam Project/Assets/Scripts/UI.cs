using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public PlayerController playerController;
    public Material InactiveMaterial;
    public Material ActiveMaterial;
    public RawImage LionImage;
    public RawImage BuffaloImage;
    public RawImage ElephantImage;
    public RawImage RhinoImage;
    public RawImage LeopardImage;
    public RawImage ActiveImage;
    public Texture LionTexture;
    public Texture BuffaloTexture;
    public Texture RhinoTexture;
    public GameObject ActiveImageGameObject;

    // Start is called before the first frame update
    void Start()
    {
        ActiveImageGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.LionAbilityActive)
        {
            LionImage.material = ActiveMaterial;
            BuffaloImage.material = InactiveMaterial;
            ElephantImage.material = InactiveMaterial;
            LeopardImage.material = InactiveMaterial;
            RhinoImage.material = InactiveMaterial;
            ActiveImageGameObject.SetActive(true);
            ActiveImage.texture = LionTexture;
        }

        if (playerController.BuffaloAbilityActive)
        {
            LionImage.material = InactiveMaterial;
            BuffaloImage.material = ActiveMaterial;
            ElephantImage.material = InactiveMaterial;
            LeopardImage.material = InactiveMaterial;
            RhinoImage.material = InactiveMaterial;
            RhinoImage.material = InactiveMaterial;
            ActiveImageGameObject.SetActive(true);
            ActiveImage.texture = BuffaloTexture;
        }

        if (playerController.RhinoAbilityActive)
        {
            LionImage.material = InactiveMaterial;
            BuffaloImage.material = InactiveMaterial;
            ElephantImage.material = InactiveMaterial;
            LeopardImage.material = InactiveMaterial;
            RhinoImage.material = ActiveMaterial;
            ActiveImageGameObject.SetActive(true);
            ActiveImage.texture = RhinoTexture;
        }
        /*
        if (playerController.LionAbilityActive)
        {
            LionImage.material = ActiveMaterial;
            BuffaloImage.material = InactiveMaterial;
            ElephantImage.material = InactiveMaterial;
            LeopardImage.material = InactiveMaterial;
            RhinoImage.material = InactiveMaterial;
        }

        if (playerController.LionAbilityActive)
        {
            LionImage.material = ActiveMaterial;
            BuffaloImage.material = InactiveMaterial;
            ElephantImage.material = InactiveMaterial;
            LeopardImage.material = InactiveMaterial;
            RhinoImage.material = InactiveMaterial;
        }*/
    }

    public void Reset()
    {
        LionImage.material = InactiveMaterial;
        BuffaloImage.material = InactiveMaterial;
        ElephantImage.material = InactiveMaterial;
        LeopardImage.material = InactiveMaterial;
        RhinoImage.material = InactiveMaterial;
        ActiveImageGameObject.SetActive(false);
    }
}
