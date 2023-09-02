using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerType : MonoBehaviour
{
    [SerializeField] private PlayerTags playerTag;

    public PlayerTags PlayerTag => playerTag;
}
