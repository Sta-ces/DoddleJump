using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public void ChangeColorText(string _hexColor)
    {
        _hexColor = _hexColor.Replace("#", "");

        Color myColor = new Color();
        ColorUtility.TryParseHtmlString("#"+_hexColor, out myColor);

        gameObject.GetComponent<Text>().color = myColor;
    }
}
