﻿using TouchScript.Gestures;
using TouchScript.Gestures.Simple;
using UnityEngine;
namespace ca.HenrySoftware.Deko
{
	public class DetectSimplePan : MonoBehaviour
	{
		public void OnEnable()
		{
			GetComponent<SimplePanGesture>().StateChanged += HandleSimplePanStateChanged;
		}
		public void OnDisable()
		{
			GetComponent<SimplePanGesture>().StateChanged -= HandleSimplePanStateChanged;
		}
		private void HandleSimplePanStateChanged(object s, TouchScript.Events.GestureStateChangeEventArgs e)
		{
			switch (e.State)
			{
				case Gesture.GestureState.Began:
				case Gesture.GestureState.Changed:
					SimplePanGesture target = s as SimplePanGesture;
					if (target.LocalDeltaPosition != Vector3.zero)
					{
						FlowView.Instance.Flow(target.LocalDeltaPosition.x);
					}
					break;
				case Gesture.GestureState.Ended:
					FlowView.Instance.Flow(FlowView.Instance.GetClosestIndex());
					break;
			}
		}
	}
}