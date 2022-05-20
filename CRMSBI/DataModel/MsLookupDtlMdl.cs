 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsLookupDtl")]
     [PrimaryKey("Kode, KodeLookup", AutoIncrement = false)]
     public partial class MsLookupDtlMdl
     {
     
         public string Kode { get; set; }
     
         public string KodeLookup { get; set; }
     
         public int NoUrut { get; set; }
     
         public string NilaiLookup { get; set; }
     
         public string NilaiLookup2 { get; set; }
     
         public string NilaiLookup3 { get; set; }
     
         public string NilaiLookup4 { get; set; }
     
         public string DisplayLookup { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static MsLookupDtlMdl GetData(string kode, string kodeLookup)
         {
             return MdlDtl.GetDataQuery<MsLookupDtlMdl>("SELECT * FROM MsLookupDtl WITH (NOLOCK,NOWAIT) WHERE Kode = @0 AND KodeLookup = @1", kode, kodeLookup);
         }
         public static MsLookupDtlMdl GetDataTransaction(MdlDto oMdlDto, string kode, string kodeLookup)
         {
             return oMdlDto.GetData<MsLookupDtlMdl>(new {Kode = kode, KodeLookup = kodeLookup});
         }
     }
 }

