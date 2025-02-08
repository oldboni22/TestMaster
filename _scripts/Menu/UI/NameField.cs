using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pryanik.Menu.UI
{


    public class NameField : MonoBehaviour
    {
        private string _admin;
        private IUserManager _userManager;
        
        [Inject]
        private void Init(IAdminManager adminManager, IUserManager userManager)
        {
            _admin = adminManager.GetAdminString();
            _userManager = userManager;
        }
        
        public void OnEditEnd(string s)
        {
            if (s == _admin)
            {
                Debug.Log("Admin");
            }
            else
            {
                _userManager.SetUser(s);
            }
        }
    }
}