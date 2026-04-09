using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "Item_ImageSO", menuName = "Scriptable Objects/Item_ImageSO")]
public class Item_ImageSO : ScriptableObject
{
    public SpriteLibraryAsset[] Item_Assets;
    public Vector2[] ColliderSize;
}
