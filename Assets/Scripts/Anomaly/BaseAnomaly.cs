using System;
using System.Collections;
using UnityEngine;

namespace Anomaly
{
    public class BaseAnomaly : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;

        public float ClipDuration => _clip.length;

        public event Action Detected;

        public virtual void Scare()
        {
            Detected?.Invoke();
            StartCoroutine(MakeSound());
        }

        private IEnumerator MakeSound()
        {
            _source.PlayOneShot(_clip);
            yield return new WaitForSeconds(ClipDuration);
            gameObject.SetActive(false);
        }
    }
}

