using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBasic : MonoBehaviour
{
    [SerializeField] private Clickable _laserClick;
    public Clickable LaserClick => _laserClick;
}
