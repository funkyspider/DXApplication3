using System;
using System.Collections.Generic;
using System.Windows.Documents;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

namespace DXApplication3.ViewModels
{
    [POCOViewModel]
    public class MainViewModel
    {
        public IMessageBoxService MessageBoxService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }


        public List<string> Tables = new List<string> { "Abocon", "Abotrn", "Addrclen" };
        public virtual string Name { get; set; }

        //We recommend that you not use public constructors to prevent creating the View Model without the ViewModelSource 
        protected MainViewModel()
        {
            Name = "Martin";
        }

        //This is a helper method that uses the ViewModelSource class for creating a LoginViewModel instance 
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }

        public bool CanCreateRepos()
        {
            if (ViewModelBase.IsInDesignMode) return true;

            return Tables.Count> 0;
        }

        public void CreateRepos()
        {
            MessageBoxService.Show("here");
        }
    }
}