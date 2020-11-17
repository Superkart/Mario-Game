
using UnityEngine;
using UnityEngine.UI;

public class GlobalCoins : MonoBehaviour
{
    public GameObject CoinDisplay;
    public static int CoinCount;
    public int InternalCoinCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        InternalCoinCount = CoinCount;
        CoinDisplay.GetComponent<Text> ().text = "Coins:" + CoinCount;
        
    }
}
