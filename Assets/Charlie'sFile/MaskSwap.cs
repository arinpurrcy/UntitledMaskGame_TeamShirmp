using JetBrains.Annotations;
using UnityEngine;

public class MaskSwap : MonoBehaviour
{
    //Very basic, very primative
    public GameObject _purpleMask;
    public GameObject _greenMask;
    public GameObject _redMask;
    public GameObject _blueMask;

    //In case we want A section with no mask
    public void NoMask()
    {
        _purpleMask.SetActive(false);
        _greenMask.SetActive(false);
        _redMask.SetActive(false);
        _blueMask.SetActive(false);
    }

    //Then all the masks just set Actives
    public void PurpleMask()
    {
        _purpleMask.SetActive(true);
        _greenMask.SetActive(false);
        _redMask.SetActive(false);
        _blueMask.SetActive(false);
    }

    public void GreenMask()
    {
        _purpleMask.SetActive(false);
        _greenMask.SetActive(true);
        _redMask.SetActive(false);
        _blueMask.SetActive(false);
    }

    public void RedMask()
    {
        _purpleMask.SetActive(false);
        _greenMask.SetActive(false);
        _redMask.SetActive(true);
        _blueMask.SetActive(false);
    }

    public void BlueMask()
    {
        _purpleMask.SetActive(false);
        _greenMask.SetActive(false);
        _redMask.SetActive(false);
        _blueMask.SetActive(true);
    }
}
