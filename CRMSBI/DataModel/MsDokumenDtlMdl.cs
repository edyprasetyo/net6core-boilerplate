 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("MsDokumenDtl")]
     [PrimaryKey("KodeDokumen, Periode", AutoIncrement = false)]
     public partial class MsDokumenDtlMdl
     {
     
         public string KodeDokumen { get; set; }
     
         public string Periode { get; set; }
     
         public int NoUrut { get; set; }
     
         public static MsDokumenDtlMdl GetData(string kodeDokumen, string periode)
         {
             return MdlDtl.GetDataQuery<MsDokumenDtlMdl>("SELECT * FROM MsDokumenDtl WITH (NOLOCK,NOWAIT) WHERE KodeDokumen = @0 AND Periode = @1", kodeDokumen, periode);
         }
         public static MsDokumenDtlMdl GetDataTransaction(MdlDto oMdlDto, string kodeDokumen, string periode)
         {
             return oMdlDto.GetData<MsDokumenDtlMdl>(new {KodeDokumen = kodeDokumen, Periode = periode});
         }
     }
 }

