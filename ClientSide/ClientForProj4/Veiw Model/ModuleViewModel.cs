using LMSLibrary;
using LMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Devices;

namespace Project_3___3.Veiw_Model
{
    public class ModuleViewModel
    {
        public ModuleViewModel(List<Module> modules) {
            Module = new Module();
            Modules = modules;
        }

        public ModuleViewModel(List<Module> modules, String selected)
        {
            Module = new Module();
            for (int i = 0; i < modules.Count(); i++)
            {
                if (selected.IndexOf(modules[i].Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Module = modules[i];
                }
            }
            Modules = modules;
        }

        public Module Module { get; set; }
        public List<Module> Modules;

        public String Name
        {
            get { return Module.Name; }
            set { Module.Name = value; }
        }

        public String Description
        {
            get { return Module.Description; }
            set { Module.Description = value; }
        }

        public void AddModule()
        {
            Modules.Add(Module);
        }

        public void ModifyModule()
        {

        }

        public void RemoveModule()
        {
            Modules.Remove(Module);
        }

        public Module SelectModule()
        {
            return Module;
        }
    }
}
