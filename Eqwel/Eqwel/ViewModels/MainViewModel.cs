using Eqwel.Service;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eqwel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ApiCaller _apiCaller = new ApiCaller();

        public MainViewModel()
        { 
        
        }
    }
}
