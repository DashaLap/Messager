//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Messager.DBConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            this.ChatUser = new HashSet<ChatUser>();
            this.Mess = new HashSet<Mess>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ChatUser> ChatUser { get; set; }
        public virtual ICollection<Mess> Mess { get; set; }
    }
}
