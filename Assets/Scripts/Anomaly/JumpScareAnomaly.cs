using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Anomaly
{
    public class JumpScareAnomaly : BaseAnomaly
    {
        [SerializeField] private Image _screamer;
        
        private Coroutine _image = null;

        private void OnDisable()
        {
            _image = null;
        }

        public override void Scare()
        {
            if (_image != null) return;

            base.Scare();
            _image = StartCoroutine(ShowImage());
        }

        private IEnumerator ShowImage()
        {
            _screamer.enabled = true;
            float t = 0f;
            while (t <= ClipDuration)
            {
                t += Time.deltaTime;
                yield return null;
            }
            _screamer.enabled = false;
            _image = null;
        }
    }
}
