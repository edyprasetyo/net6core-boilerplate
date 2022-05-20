 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsUser")]
     [PrimaryKey("NoUser", AutoIncrement = false)]
     public partial class MsUserMdl
     {
     
         public string NoUser { get; set; }
     
         public string UserID { get; set; }
     
         public string Nama { get; set; }
     
         public string Email { get; set; }
     
         public string KodeGroup { get; set; }
     
         public string Password { get; set; }
     
         public bool bAktif { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsUserMdl GetData(string noUser)
         {
             return MdlDtl.GetDataQuery<MsUserMdl>("SELECT * FROM MsUser WITH (NOLOCK,NOWAIT) WHERE NoUser = @0", noUser);
         }
         public static MsUserMdl GetDataTransaction(MdlDto oMdlDto, string noUser)
         {
             return oMdlDto.GetData<MsUserMdl>(noUser);
         }
     }
 }

