using UnityEngine;
using System.Collections.Generic;

public class ItemSpawnManager : MonoBehaviour
{
    [Header("List of Item Prefabs")]
    public List<GameObject> itemPrefabs = new List<GameObject>();

    [Header("Parent Objects that contain SpawnPoints as Children")]
    public List<Transform> spawnPointParents = new List<Transform>();

    private void Start()
    {
        // We loop through each item and find a corresponding parent Transform that has children as spawn points.
        int count = Mathf.Min(itemPrefabs.Count, spawnPointParents.Count);

        for (int i = 0; i < count; i++)
        {
            GameObject itemPrefab = itemPrefabs[i];
            Transform parent = spawnPointParents[i];

            if (itemPrefab == null || parent == null)
            {
                Debug.LogWarning($"Item Prefab or SpawnPoint Parent missing at index {i}.");
                continue;
            }

            // Gather all children of the parent as spawn points.
            List<Transform> spawnPoints = new List<Transform>();
            for (int c = 0; c < parent.childCount; c++)
            {
                spawnPoints.Add(parent.GetChild(c));
            }

            if (spawnPoints.Count == 0)
            {
                Debug.LogWarning($"No spawn points found under {parent.name} for item {itemPrefab.name}.");
                continue;
            }

            // Select a random spawn point from the child's transforms
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform chosenPoint = spawnPoints[randomIndex];

            // Instantiate the item at the chosen spawn point
            Instantiate(itemPrefab, chosenPoint.position, chosenPoint.rotation);
        }
    }
}