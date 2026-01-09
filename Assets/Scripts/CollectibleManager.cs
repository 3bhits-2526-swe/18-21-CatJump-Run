using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private TextMeshProUGUI collectibleCountText;
    [SerializeField] private int pickedUpCollectibles;
    [SerializeField] private string collectibleName = "Collectibles";
    public int maxCollectibles = 12;
    public bool GotEverything;
    public static CollectibleManager collectibleManager { get; private set; }

    void Awake()
    {
        collectibleManager = this;
        collectibleCountText.text = $"0/{maxCollectibles} {collectibleName}";
    }
    void Start()
    {

    }

    void Update()
    {

    }
    public void IncreaseCount()
    {
        pickedUpCollectibles++;
        collectibleCountText.text = $"{pickedUpCollectibles}/{maxCollectibles} {collectibleName}";
        if (pickedUpCollectibles >= maxCollectibles)
        {
            GotEverything = true;
        }
    }
}
