﻿using System.ComponentModel;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(HutongGames.PlayMaker.Actions.GetDistance))]
    public class GetDistanceEditor : CustomActionEditor
    {
        public override bool OnGUI()
        {
            return DrawDefaultInspector();
        }

        [Localizable(false)]
        public override void OnSceneGUI()
        {
            var action = target as HutongGames.PlayMaker.Actions.GetDistance;
            if (action == null) // shouldn't happen!
            {
                return;
            }

            var fromObject = action.Fsm.GetOwnerDefaultTarget(action.gameObject);
            var toObject = action.target;

            if (fromObject == null || toObject.IsNone || toObject.Value == null)
            {
                return;
            }

            var fromPos = fromObject.transform.position;
            var toPos = toObject.Value.transform.position;
            var distance = Vector3.Distance(fromPos, toPos);
            var label = string.Format("Get Distance:\n{0}", string.Format("{0:0.000}", distance));


            Handles.color = new Color(1, 1, 1, 0.5f);
            Handles.DrawLine(fromPos, toPos);
            Handles.Label((fromPos + toPos)*0.5f, label);
        }
    }
}
