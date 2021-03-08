using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class Location
    {
        #region FIELDS

        //public enum ModifiedForms { Beetle, Mole, Bunny, Jackalope }
        private string _name;
        private string _modifyForm;
        private string _modifyFormImg;
        private string _modifyChamberColor;
        private string _modifyMapLocatorTop;
        private string _modifyMapLocatorLeft;
        private string _description;
        private string _message;
        private bool _accessible;
       // private ModifiedForms _modifyForm;
        #endregion

        #region PROPERTIES

       
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }
        public string ModifyForm
        {
            get { return _modifyForm; }
            set { _modifyForm = value; }
        }
        public string ModifyFormImg
        {
            get { return _modifyFormImg; }
            set { _modifyFormImg = value; }
        }
        public string ModifyChamberColor
        {
            get { return _modifyChamberColor; }
            set { _modifyChamberColor = value; }
        }
        public string ModifyMapLocatorTop
        {
            get { return _modifyMapLocatorTop; }
            set { _modifyMapLocatorTop = value; }
        }
        public string ModifyMapLocatorLeft
        {
            get { return _modifyMapLocatorLeft; }
            set { _modifyMapLocatorLeft = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Location()
        {

        }

        #endregion

        #region METHODS

        public override string ToString()
        {
            return _name;
        }

        #endregion
    }
}
