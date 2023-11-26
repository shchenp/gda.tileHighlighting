using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTile : MonoBehaviour
{
   [SerializeField]
   private LayerMask _layer;

   [SerializeField]
   private Color _color;

   private void Update()
   {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out var hitInfo, 100f, _layer))
      {
         var hitObject = hitInfo.collider.gameObject;

         hitObject.GetComponent<Renderer>().material.color = _color;
      }
   }
}
