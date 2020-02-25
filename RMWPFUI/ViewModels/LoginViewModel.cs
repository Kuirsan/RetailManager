using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMWPFUI.EventModels;
using RMWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMWPFUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper aPIHelper, IEventAggregator events)
        {
            _apiHelper = aPIHelper;
            _events = events;
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }


        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool result = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    result = true;
                }
                return result;
            }
        }

        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(UserName, Password);

                // Capture more information bout user
                await _apiHelper.GetLogedInUserInfo(result.Access_Token);

                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
