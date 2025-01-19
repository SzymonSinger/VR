using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class ItemCollectManager : MonoBehaviour {
    [SerializeField] GameObject doorHandle;
    public GameplayHandler gameplayHandler;
    private CryingBaby cryingBaby;

    // A dictionary to hold which items are required
    // and whether they have been collected.
    private Dictionary<RequiredItem, bool> requiredItemsStatus = new Dictionary<RequiredItem, bool>()
    {
        { RequiredItem.Money,   false },
        { RequiredItem.Key,     false },
        { RequiredItem.Glasses, false },
    };

    // The baseline text for each item
    private string moneyText = "- Money";
    private string keyText = "- Key";
    private string glassesText = "- Glasses";

    public TextMeshProUGUI doorText;

    private void Start() {
        UpdateDoorText();
        cryingBaby = FindFirstObjectByType<CryingBaby>();
    }

    private void Update()
    {
        if (cryingBaby.happyBobo)
        {
            AllItemsCollected();
        }
    }

    public void CollectItem(GameObject collectedObject) {
        RequiredItem itemToCollect;

        var itemName = collectedObject.name;
        switch (itemName) {
            case "Money":
                itemToCollect = RequiredItem.Money;
                break;
            case "Key":
                itemToCollect = RequiredItem.Key;
                break;
            case "Glasses":
                itemToCollect = RequiredItem.Glasses;
                break;
            default:
                itemToCollect = RequiredItem.Glasses;
                break;
        }
        // If this item is part of our dictionary AND not yet collected
        if (requiredItemsStatus.ContainsKey(itemToCollect) && requiredItemsStatus[itemToCollect] == false) {
            requiredItemsStatus[itemToCollect] = true;
            Debug.Log($"Collected: {itemToCollect}");

            if (collectedObject != null) {
                Destroy(collectedObject);
            }
            UpdateDoorText();
        }
        else if (requiredItemsStatus.ContainsKey(itemToCollect) && requiredItemsStatus[itemToCollect]) {
            Debug.Log($"Item {itemToCollect} is already collected.");
        }
        else {
            Debug.Log($"{itemToCollect} is not a required item.");
        }
    }

    /// <summary>
    /// Rebuild the text to show a strike-through if collected,
    /// or plain text if not collected.
    /// </summary>
    private void UpdateDoorText() {
        // Build multi-line string
        string fullText = string.Empty;

        // Money
        fullText += requiredItemsStatus[RequiredItem.Money]
            ? $"<s>{moneyText}</s>\n"
            : $"{moneyText}\n";

        // Key
        fullText += requiredItemsStatus[RequiredItem.Key]
            ? $"<s>{keyText}</s>\n"
            : $"{keyText}\n";

        // Glasses
        fullText += requiredItemsStatus[RequiredItem.Glasses]
            ? $"<s>{glassesText}</s>\n"
            : $"{glassesText}\n";

        AllItemsCollected();

        doorText.text = fullText;
    }

    /// <summary>
    /// Checks if all items in our dictionary are marked collected.
    /// </summary>
    private bool AllItemsCollected() {
        foreach (var kvp in requiredItemsStatus) {
            if (!kvp.Value)
                return false;
        }

        if (cryingBaby.happyBobo)
        {
            doorHandle.SetActive(true);
        }
        return true;
    }

    public void TestGameComplete() {
        gameplayHandler.CompleteGame();
    }
}

public enum RequiredItem {
    Money,
    Key,
    Glasses
}
