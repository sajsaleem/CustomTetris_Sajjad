using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseMenu : MonoBehaviour
{
    [SerializeField] private MenuType _menuType;
    [SerializeField] private List<Selectable> selectables;

    public MenuType MenuType { get => _menuType; }
    public List<Selectable> Selectables { get => selectables; }

    public virtual void Init()
    {

    }

    public virtual void MyEnable()
    {

    }

    public virtual void SetSelectablesActiveStatus(bool value)
    {
        for(int i = 0; i < selectables.Count; i++)
        {
            selectables[i].interactable = value;
        }
    }

    public virtual void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public abstract void Reset();
}
