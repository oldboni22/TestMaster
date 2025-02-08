using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pryanik
{

    public interface ISelectedTestManager
    {
        public void SetTestId(int id);
        public int GetTestId();
    }
    
    public class SelectedTestManager : ISelectedTestManager
    {
        private int _id;
        
        public void SetTestId(int id)
        {
            _id = id;
        }

        public int GetTestId() => _id;
    }
}