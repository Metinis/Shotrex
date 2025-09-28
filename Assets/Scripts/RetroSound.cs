using UnityEngine;

public class RetroSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBeep(float frequency = 440f, float duration = 0.2f)
    {
        int sampleRate = 44100;
        int sampleLength = (int)(sampleRate * duration);
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            // simple square wave
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * frequency * i / sampleRate));
        }

        AudioClip clip = AudioClip.Create("Beep", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }
    public void PlayShot()
    {
        int sampleRate = 44100;
        float duration = 0.15f;  // short
        int sampleLength = (int)(sampleRate * duration);
        float startFreq = 1200f; // start high
        float endFreq = 600f;    // drop quickly
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            // linear frequency drop
            float t = i / (float)sampleLength;
            float freq = Mathf.Lerp(startFreq, endFreq, t);

            // square wave for retro feel
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate));
        }

        AudioClip clip = AudioClip.Create("Shot", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }
    public void PlayHit()
    {
        int sampleRate = 44100;
        float duration = 0.2f;  // short
        int sampleLength = (int)(sampleRate * duration);
        float startFreq = 400f; // low pitch
        float endFreq = 200f;   // drops lower
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            // linear frequency drop over time
            float t = i / (float)sampleLength;
            float freq = Mathf.Lerp(startFreq, endFreq, t);

            // square wave for retro feel
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate));
        }

        AudioClip clip = AudioClip.Create("Hit", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }
    public void PlayPowerUp()
    {
        int sampleRate = 44100;
        float duration = 0.25f; // slightly longer
        int sampleLength = (int)(sampleRate * duration);
        float startFreq = 500f;  // medium-low
        float endFreq = 1000f;   // rises quickly
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            // linear frequency rise over time
            float t = i / (float)sampleLength;
            float freq = Mathf.Lerp(startFreq, endFreq, t);

            // square wave for retro sound
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate));
        }

        AudioClip clip = AudioClip.Create("PowerUp", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }
    public void PlayEnemyHit()
    {
        int sampleRate = 44100;
        float duration = 0.15f;  // short
        int sampleLength = (int)(sampleRate * duration);
        float startFreq = 600f; // mid-high
        float endFreq = 400f;   // drops a bit
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            float t = i / (float)sampleLength;
            float freq = Mathf.Lerp(startFreq, endFreq, t);

            // square wave for retro feel
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate));
        }

        AudioClip clip = AudioClip.Create("EnemyHit", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }
    public void PlayJump()
    {
        int sampleRate = 44100;
        float duration = 0.1f;    // very short
        int sampleLength = (int)(sampleRate * duration);
        float startFreq = 800f;    // start fairly high
        float endFreq = 1200f;     // rises a little
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            float t = i / (float)sampleLength;
            float freq = Mathf.Lerp(startFreq, endFreq, t);

            // square wave for retro feel
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate));
        }

        AudioClip clip = AudioClip.Create("Jump", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }
    public void PlayBoxBreak()
    {
        int sampleRate = 44100;
        float duration = 0.12f; // short
        int sampleLength = (int)(sampleRate * duration);
        float startFreq = 1000f; // high pitch
        float endFreq = 700f;    // drops slightly
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            float t = i / (float)sampleLength;
            float freq = Mathf.Lerp(startFreq, endFreq, t);

            // square wave for retro feel
            samples[i] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate));

            // optional: fade out quickly
            samples[i] *= 1.0f - t;
        }

        AudioClip clip = AudioClip.Create("BoxBreak", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);

        audioSource.PlayOneShot(clip);
    }



}