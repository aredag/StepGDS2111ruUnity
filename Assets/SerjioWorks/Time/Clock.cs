using UnityEngine;

namespace TimeClock
{
    public class Clock : MonoBehaviour
    {
        [SerializeField] private bool UTC;
        [SerializeField] private Transform hours;
        [SerializeField] private Transform minutes;
        [SerializeField] private Transform seconds;

        private void Update()
        {
            var now = UTC ? System.DateTime.UtcNow : System.DateTime.Now;
            hours.transform.localEulerAngles = Vector3.back * now.Hour * 15f;
            minutes.transform.localEulerAngles = Vector3.back * now.Minute * 6f;
            seconds.transform.localEulerAngles = Vector3.back * now.Second * 6f;
        }
    }
}