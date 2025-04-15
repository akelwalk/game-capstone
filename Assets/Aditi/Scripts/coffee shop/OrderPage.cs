using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Order : MonoBehaviour
{
    public TMP_Text customer;
    public TMP_Text order;
    public TMP_Text description;
    public TextAsset jsonOrders; 
    private GameData gameData;
    // Start is called before the first frame update
    void Awake()
    {
        if (jsonOrders != null)
        {
            gameData = JsonUtility.FromJson<GameData>(jsonOrders.text);
            List<string> drinkList = gameData.levels[MainManager.Instance.getLevel()].drinks;
            if (drinkList.Count > 1) {
                order.text = "Order: ???";
            }
            else {
                order.text = "Order: " + gameData.levels[MainManager.Instance.getLevel()].drinks[0];
            }
            description.text = gameData.levels[MainManager.Instance.getLevel()].customer.description;
            customer.text = gameData.levels[MainManager.Instance.getLevel()].customer.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
