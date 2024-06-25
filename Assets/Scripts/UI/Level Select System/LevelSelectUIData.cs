
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUIData : MonoBehaviour
{
   [field:SerializeField] public TextMeshProUGUI TitleText { get; set; }
   [field:SerializeField] public string ScenePath { get; set; }
   [field:SerializeField] public Image GameImage { get; set; }
   [field:SerializeField] public TextMeshProUGUI DevNameText { get; set; }
}
