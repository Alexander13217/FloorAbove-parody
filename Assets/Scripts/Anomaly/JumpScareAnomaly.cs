using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Anomaly
{
    public class JumpScareAnomaly : BaseAnomaly
    {
        [SerializeField] private Image _screamer;
        [SerializeField] private float _screamerDuration;

        private Coroutine _image = null;

        public override void Scare()
        {
            if (_image != null) return;

            _image = StartCoroutine(ShowImage());
        }

        private IEnumerator ShowImage()
        {
            _screamer.enabled = true;
            float t = 0f;
            while (t <= _screamerDuration)
            {
                t += Time.deltaTime;
                yield return null;
            }
            _screamer.enabled = false;
            _image = null;
            base.Scare();
        }
    }
}
