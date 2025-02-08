using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Pryanik
{

    public interface IUserManager
    {
        public string GetUser();
        public void SetUser(string s);
    }
    public class UserManager : IUserManager
    {
        private string _user;

        public string GetUser() => _user;

        public void SetUser(string s)
        {
            _user = s;
        }
    }
}