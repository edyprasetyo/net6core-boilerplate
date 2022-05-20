 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsGroupUser")]
     [PrimaryKey("KodeGroup", AutoIncrement = false)]
     public partial class MsGroupUserMdl
     {
     
         public string KodeGroup { get; set; }
     
         public string NamaGroup { get; set; }
     
         public bool bAdmin { get; set; }
     
         public bool bUserAdmin { get; set; }
     
         public bool bUser { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsGroupUserMdl GetData(string kodeGroup)
         {
             return MdlDtl.GetDataQuery<MsGroupUserMdl>("SELECT * FROM MsGroupUser WITH (NOLOCK,NOWAIT) WHERE KodeGroup = @0", kodeGroup);
         }
         public static MsGroupUserMdl GetDataTransaction(MdlDto oMdlDto, string kodeGroup)
         {
             return oMdlDto.GetData<MsGroupUserMdl>(kodeGroup);
         }
     }
 }

