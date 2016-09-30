﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pottery.Demo
{
	public sealed class Message : MonoBehaviour
	{
		private static Message _instance;

		public static Message GetInstance()
		{
			if (_instance == null) throw new NullReferenceException();
			return _instance;
		}

		public Text message;

		private void Awake() { _instance = this; }

		private Action onClose = delegate { };

		public void PopUp(string message, Action onClose)
		{
			CanvasController.GetInstance().ShowElement(3);
			this.message.text = message;
			this.onClose = onClose;
		}

		public void Close()
		{
			CanvasController.GetInstance().Back();
			message.text = "Null";
			onClose();
			onClose = delegate { };
		}
	}
}
