//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int id_modification { get; set; }
        public int MarkID { get; set; }
        public int ModelID { get; set; }
        public string pokolenie { get; set; }
        public Nullable<System.DateTime> YearAt { get; set; }
        public Nullable<System.DateTime> YearBefore { get; set; }
        public Nullable<int> SeriaID { get; set; }
        public int ModificationID { get; set; }
    
        public virtual Mark Mark { get; set; }
        public virtual Model Model { get; set; }
        public virtual Modification Modification { get; set; }
        public virtual Seria Seria { get; set; }
    }
}