namespace TesoApp.UIForms.ViewModels
{
    using System;
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
    }
}
