using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private TextMeshProUGUI collectibleCountText;
    [SerializeField] private int pickedUpCollectibles;
    [SerializeField] private int maxCollectibles = 12;
    [SerializeField] private string collectibleName = "Collectibles";
    public static CollectibleManager collectibleManager {get; private set;}

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
        pickedUpCollectibles ++;
        collectibleCountText.text = $"{pickedUpCollectibles}/{maxCollectibles} {collectibleName}";
        if(pickedUpCollectibles >= maxCollectibles)
        {
            InitiateWin();
        }
    }
    private void InitiateWin(){Debug.Log("WIN");}
}
