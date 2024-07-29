using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.UI.Mono
{
    public class MenuManager : MonoBehaviour
    {
        [FormerlySerializedAs("policeConfirmView")] [SerializeField] private PoliceConfirmView sdadassda;
        [FormerlySerializedAs("mainMenuView")] [SerializeField] private MainMenuView sadsadasd;
        [FormerlySerializedAs("uiViews")] [SerializeField] private UIView[] fdssfddsf;

        private void Start()
        {
            HideAllUIViews();
        
            int policy = PlayerPrefs.GetInt("Policy", 0);
            if (policy == 0)
            {
                sdadassda.Show();
            }
            else
            {
                sadsadasd.Show();
            }
        }

        private void HideAllUIViews()
        {
            foreach (var view in fdssfddsf)
            {
                view.Hide();
            }
        }
    }
}