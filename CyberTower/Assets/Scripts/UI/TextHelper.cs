using UnityEngine;
using TMPro;

public class TextHelper : MonoBehaviour {
    // You pass the reference of your text in the inspector
    public TMP_Text textObject;

    // You call this with an animation event
    public void SetText(string newText) {
        textObject.text = newText;
    }
}