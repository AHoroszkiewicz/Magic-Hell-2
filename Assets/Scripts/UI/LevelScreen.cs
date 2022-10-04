using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject itemList;
    private List<Item> items;
    private int item;
    [SerializeField] List<GameObject> buttons;

    private void Start()
    {
        items = itemList.GetComponent <ItemList>().itemList;
    }

    //private void Update()
    //{
    //    if (items.Count<buttons.Count)
    //    {
    //        Destroy(buttons[buttons.Count -1]);
    //        buttons.RemoveAt(buttons.Count -1);
    //    }
    //}

    public void LevelUpScreen()
    {
        Time.timeScale = 0f;
        levelMenu.SetActive(true);
        joystick.SetActive(false);

        for (int i = 0; i < buttons.Count; i++)
        {
            item = Random.Range(0, items.Count);
            while (items[item].item.GetComponent<Projectile>().GetLevel() >= 5)
            {
                items.RemoveAt(item);
                item = Random.Range(0, items.Count);
            }
            Image buttonSprite = buttons[i].GetComponent<Image>();
            buttonSprite.sprite = items[item].item.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void ItemLevelUp()
    {
        items[item].item.GetComponent<Projectile>().LevelUp();
    }

}
