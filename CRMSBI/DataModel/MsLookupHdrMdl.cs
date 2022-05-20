 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsLookupHdr")]
     [PrimaryKey("Kode", AutoIncrement = false)]
     public partial class MsLookupHdrMdl
     {
     
         public string Kode { get; set; }
     
         public string Keterangan { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsLookupHdrMdl GetData(string kode)
         {
             return MdlDtl.GetDataQuery<MsLookupHdrMdl>("SELECT * FROM MsLookupHdr WITH (NOLOCK,NOWAIT) WHERE Kode = @0", kode);
         }
         public static MsLookupHdrMdl GetDataTransaction(MdlDto oMdlDto, string kode)
         {
             return oMdlDto.GetData<MsLookupHdrMdl>(kode);
         }
     }
 }

