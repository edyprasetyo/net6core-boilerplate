 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsDokumenHdr")]
     [PrimaryKey("KodeDokumen", AutoIncrement = false)]
     public partial class MsDokumenHdrMdl
     {
     
         public string KodeDokumen { get; set; }
     
         public string Keterangan { get; set; }
     
         public string Prefix { get; set; }
     
         public string Sufix { get; set; }
     
         public int PanjangNo { get; set; }
     
         public string ResetBy { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsDokumenHdrMdl GetData(string kodeDokumen)
         {
             return MdlDtl.GetDataQuery<MsDokumenHdrMdl>("SELECT * FROM MsDokumenHdr WITH (NOLOCK,NOWAIT) WHERE KodeDokumen = @0", kodeDokumen);
         }
         public static MsDokumenHdrMdl GetDataTransaction(MdlDto oMdlDto, string kodeDokumen)
         {
             return oMdlDto.GetData<MsDokumenHdrMdl>(kodeDokumen);
         }
     }
 }

