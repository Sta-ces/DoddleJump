using UnityEngine;
using UnityEngine.Advertisements;

public class Money : MonoBehaviour {

	public void MoneyMoney()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            Advertisement.Show();
        #endif
    }
}
