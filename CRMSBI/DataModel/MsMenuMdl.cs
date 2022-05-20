 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsMenu")]
     [PrimaryKey("KodeMenu", AutoIncrement = false)]
     public partial class MsMenuMdl
     {
     
         public string KodeMenu { get; set; }
     
         public string JudulMenu { get; set; }
     
         public string ParentMenu { get; set; }
     
         public int UrutanMenu { get; set; }
     
         public bool bTampil { get; set; }
     
         public bool bParent { get; set; }
     
         public bool bPemisah { get; set; }
     
         public string NamaController { get; set; }
     
         public string NamaAction { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsMenuMdl GetData(string kodeMenu)
         {
             return MdlDtl.GetDataQuery<MsMenuMdl>("SELECT * FROM MsMenu WITH (NOLOCK,NOWAIT) WHERE KodeMenu = @0", kodeMenu);
         }
         public static MsMenuMdl GetDataTransaction(MdlDto oMdlDto, string kodeMenu)
         {
             return oMdlDto.GetData<MsMenuMdl>(kodeMenu);
         }
     }
 }

