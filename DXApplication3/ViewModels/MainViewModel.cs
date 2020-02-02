using System;
using System.Collections.Generic;
using System.Windows.Documents;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

namespace DXApplication3.ViewModels
{
    [POCOViewModel]
    public class MainViewModel : ViewModelBase
    {
        public IMessageBoxService MessageBoxService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }

        public virtual string[] TableNames { get; set; }

        public List<string> Tables = new List<string> { "Abocon", "Abotrn", "Addrclen" };
        public virtual string Name { get; set; }

        public MainViewModel()
        {
            Name = "Martin";
            foreach (var table in Tables)
            {
                ClassWriter.CreateClassForDbTable(table);
            }
        }

        public bool CanCreateRepos()
        {
            return TableNames.Length > 0;
        }

        public void CreateRepos()
        {
            MessageBoxService.Show("here");
        }
    }
}