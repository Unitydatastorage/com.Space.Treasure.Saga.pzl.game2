using UnityEngine;
using VContainer;

namespace Source.UI.Mono
{
    public class UIView : MonoBehaviour
    {
        private UIView dsajidosaidsajo;

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Show(UIView prevUIView)
        {
            dsajidosaidsajo = prevUIView;
            dsajidosaidsajo.Hide();
            Show();
        }

        public void Return()
        {
            if (dsajidosaidsajo)
            {
                dsajidosaidsajo.Show();
                Hide();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}