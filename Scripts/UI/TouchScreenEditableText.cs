using System.Text;
using Core.AlphaSettings;
using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Scripts.UI
{
    [RequireComponent(typeof(Text))]
    public class TouchScreenEditableText : MonoBehaviour
    {
        private Text text;
        private TouchScreenKeyboard keyboard;

        public TouchScreenKeyboardType TouchScreenKeyboardType = TouchScreenKeyboardType.Default;
        public bool Autocorrection;
        public bool Multiline;
        public bool Secure;
        public bool Alert;

        public int MaxLength = int.MaxValue;
        private string nonSupportedTextSymbols;

        private string lastCheckedString;

        protected virtual void Awake()
        {
            text = GetComponentInChildren<Text>();

            nonSupportedTextSymbols = ProjectSettings.NonSupportedTextSymbols;
        }

        public void BeginTextEditing()
        {
            keyboard = TouchScreenKeyboard.Open(text.text, TouchScreenKeyboardType, Autocorrection, Multiline, Secure,
                Alert);
        }

        private bool KeyboardTextEqualsLastCheckedString()
        {
            string keyboardText = keyboard.text;
            if (keyboardText.Length != lastCheckedString.Length)
            {
                return false;
            }

            for (int index = 0; index < keyboardText.Length; ++index)
            {
                if (keyboardText[index] != lastCheckedString[index])
                {
                    return false;
                }
            }

            return true;
        }

        protected void Update()
        {
            if (keyboard != null)
            {
                if (keyboard.active)
                {
                    if (keyboard.text.Length > MaxLength)
                    {
                        keyboard.text = keyboard.text.Substring(0, MaxLength);
                    }
                    
                    if (!KeyboardTextEqualsLastCheckedString())
                    {
                        bool shitHappened = false;
                        var stringBuilder = new StringBuilder(keyboard.text);
                        for (int index = 0; index < stringBuilder.Length; ++index)
                        {
                            char symbol = stringBuilder[index];
                            if (IsSymbolNonSupported(symbol))
                            {
                                stringBuilder[index] = ProjectSettings.TextErrorSymbol;
                                if (!shitHappened)
                                {
                                    shitHappened = true;
                                }
                            }
                        }

                        if (shitHappened)
                        {
                            keyboard.text = stringBuilder.ToString();
                        }

                        lastCheckedString = keyboard.text;
                    }
                }
                else if (keyboard.status == TouchScreenKeyboard.Status.Done)
                {
                    text.text = keyboard.text;
                    keyboard = null;
                }
            }
        }

        private bool IsSymbolNonSupported(char symbol)
        {
            for (int index = 0; index < nonSupportedTextSymbols.Length; ++index)
            {
                if (nonSupportedTextSymbols[index] == symbol)
                {
                    return true;
                }
            }

            return false;
        }
    }
}