using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// View
/// </summary>
public class View : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void SetText(string t)
    {
        _text.text = t;
        Debug.Log(t);
    }
}
