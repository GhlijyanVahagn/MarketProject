using MarketManagment;
using MarketManagment.User;
using System;


namespace MarketHelpers
{
  

    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed public class Authorized : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly bool _autorized;

        // This is a positional argument
        public Authorized()
        {
            this._autorized = UsersManager.IsUserAutorized;
            
        }

        public bool IsAutorized
        {
            get { return _autorized; }
        }


    }
}
