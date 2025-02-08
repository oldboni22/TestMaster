using System;
using UnityEngine;



namespace Pryanik
{

    public interface IAdminManager
    {
        public string GetAdminString();
        public void SetAdminString(string s);
    }

    public class AdminManager : IAdminManager
    {

        private readonly string _key = "Admin";
        public AdminManager()
        {
            if(PlayerPrefs.GetString(_key) == String.Empty)
                SetAdminString("Admin");
        }
        
        public string GetAdminString() => PlayerPrefs.GetString(_key);
        
        public void SetAdminString(string s)
        {
            PlayerPrefs.SetString(_key,s);
            PlayerPrefs.Save();
        }
    }
}