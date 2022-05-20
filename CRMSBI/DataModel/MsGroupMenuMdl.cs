 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsGroupMenu")]
     [PrimaryKey("KodeGroup, KodeMenu", AutoIncrement = false)]
     public partial class MsGroupMenuMdl
     {
     
         public string KodeGroup { get; set; }
     
         public string KodeMenu { get; set; }
     
         public bool bView { get; set; }
     
         public bool bNew { get; set; }
     
         public bool bEdit { get; set; }
     
         public bool bDelete { get; set; }
     
         public bool bPrint { get; set; }
     
         public bool bProcess { get; set; }
     
         public bool bGenerate { get; set; }
     
         public bool bValidate { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsGroupMenuMdl GetData(string kodeGroup, string kodeMenu)
         {
             return MdlDtl.GetDataQuery<MsGroupMenuMdl>("SELECT * FROM MsGroupMenu WITH (NOLOCK,NOWAIT) WHERE KodeGroup = @0 AND KodeMenu = @1", kodeGroup, kodeMenu);
         }
         public static MsGroupMenuMdl GetDataTransaction(MdlDto oMdlDto, string kodeGroup, string kodeMenu)
         {
             return oMdlDto.GetData<MsGroupMenuMdl>(new {KodeGroup = kodeGroup, KodeMenu = kodeMenu});
         }
     }
 }

