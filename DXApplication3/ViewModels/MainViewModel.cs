using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using DXApplication3.Models;

namespace DXApplication3.ViewModels
{
    [POCOViewModel]
    public class MainViewModel
    {
        public IMessageBoxService MessageBoxService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }

        public virtual TableList TableList { get; set; }

        //We recommend that you not use public constructors to prevent creating the View Model without the ViewModelSource 
        protected MainViewModel()
        {
            TableList = TableList.CreateWithData();
        }

        //This is a helper method that uses the ViewModelSource class for creating a LoginViewModel instance 
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }

        public bool CanCreateRepos()
        {
            if (ViewModelBase.IsInDesignMode) return true;

            return TableList.Any(x => x.Selected);
        }

        public void CreateRepos()
        {
            foreach (var table in TableList.Where(x => x.Selected))
            {
                ClassWriter.CreateClassForDbTable(table.Name);
            }

        }
    }
}